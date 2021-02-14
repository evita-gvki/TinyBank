using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyBank.Core.Data;
using TinyBank.Core.Model;
using TinyBank.Core.Services.Options;


namespace TinyBank.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private CrmDbContext _dbContext;

        public TransactionService(CrmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Note: Initial implemementation. Will be modified
        // to return a more structured and informative type.
        
        public async Task<Result<Transaction>> CreateTransactionAsync(CreateTransactionOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.AccountId))
            {
                return new Result<Transaction>()
                {
                    ErrorMessage = "AccountId is empty",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            if (options.TrnAmount == 0)
            {
                return new Result<Transaction>()
                {
                    ErrorMessage = "TrnAmount is empty",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            if (options.Category  ==0)
            {
                return new Result<Transaction>()
                {
                    ErrorMessage = "Category is empty",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            if (options.CustomerId == 0)
            {
                return new Result<Transaction>()
                {
                    ErrorMessage = "CustomerId is empty",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            //υπάρχει καταχωρημένος ο πελάτης?
            var opt = new FindCustomerOptions()
            {
                CustomerId = options.CustomerId
            };

            var q = new CustomerService(_dbContext).FindCustomerAsync(opt).Result.Data;

            if (q == null)
            {
                return new Result<Transaction>()
                {
                    ErrorMessage = "Customer not registered",
                    Code = Constants.ResultCode.NotFound
                };
            }

            //υπάρχει καταχωρημένος ο λογαριασμός?
            var acc = new AccountService(_dbContext).FindAccountAsync(options.AccountId).Result.Data;
            if (acc == null)
            {
                return new Result<Transaction>()
                {
                    ErrorMessage = "Account not registered",
                    Code = Constants.ResultCode.NotFound
                };
            }
            
            if (options.Category.Equals(TrnCategory.Pistwsh)) 
            {
                var trn = new Transaction
                {
                    AccountId = options.AccountId,
                    TrnAmount = options.TrnAmount,
                    Category  = options.Category
                };

                acc.AddTrn(trn);
                _dbContext.Add(trn);
                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return new Result<Transaction>()
                    {
                        Code = Constants.ResultCode.InternalServerError,
                        ErrorMessage = "Transaction could not be saved"
                    };
                }

                return new Result<Transaction>()
                {
                    Data = trn,
                    Code = Constants.ResultCode.Success,
                };
            }

            if (options.Category.Equals(TrnCategory.Xrewsh) & (acc.TotalAmount - options.TrnAmount >= 0) &
                (q.CustomerId == acc.CustomerId))
            {
                var trn = new Transaction
                {
                    AccountId = options.AccountId,
                    TrnAmount = options.TrnAmount,
                    Category = options.Category
                };

                acc.AddTrn(trn);
                _dbContext.Add(trn);
               
                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return new Result<Transaction>()
                    {
                        Code = Constants.ResultCode.InternalServerError,
                        ErrorMessage = "Transaction could not be saved"
                    };
                }

                return new Result<Transaction>()
                {
                    Data = trn,
                    Code = Constants.ResultCode.Success,
                };
            }
            else
            {
                return new Result<Transaction>()
                {
                    Code = Constants.ResultCode.InternalServerError,
                    ErrorMessage = "Transaction could not be saved"
                };
            }
                        
        }
    }
}

