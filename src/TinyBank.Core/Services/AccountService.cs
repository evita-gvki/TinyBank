using System;
using TinyBank.Core;
using TinyBank.Core.Data;
using TinyBank.Core.Model;
using TinyBank.Core.Services.Options;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace TinyBank.Core.Services
{
    public class AccountService : IAccountService
    {
        private CrmDbContext _dbContext;
        
        public AccountService(CrmDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public async Task<Result<Account>> CreateAccountAsync(CreateAccountOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.AccountId))
            {
                //turn null;
                return new Result<Account>()
                {
                    ErrorMessage = "AccountId is required",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            if (options.CustomerId == 0)
            {
                return new Result<Account>()
                {
                    ErrorMessage = "Customer is required",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            var opt = new FindCustomerOptions()
            {
                CustomerId = options.CustomerId
            };

            var q = new CustomerService(_dbContext).FindCustomerAsync(opt).Result.Data;
            //var q = _customers.FindCustomer(opt);

            if (q == null)
            {
                return new Result<Account>()
                {
                    ErrorMessage = "Customer is not registered",
                    Code = Constants.ResultCode.NotFound
                };
            }

            var account = new Account()
            {
                AccountId = options.AccountId,
                CustomerId = options.CustomerId
            };

            _dbContext.Add(account);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new Result<Account>()
                {
                    Code = Constants.ResultCode.InternalServerError,
                    ErrorMessage = "Account could not be saved"
                };
            }

            return new Result<Account>()
            {
                Code = Constants.ResultCode.Success,
                Data = account
            };
        }
     

        public async Task<Result<Account>> FindAccountAsync (string acc_id)
        {
            if (string.IsNullOrWhiteSpace(acc_id))
            {
                return new Result<Account>()
                {
                ErrorMessage = "AccountId is required",
                Code = Constants.ResultCode.BadRequest
                };
             }

            var q = await _dbContext.Set<Account>()
                        .Where(a => a.AccountId == acc_id) 
                        .SingleOrDefaultAsync();

            if (q == null)
            {
                return new Result<Account>()
                {
                    Data = null,
                    Code = Constants.ResultCode.NotFound
                };

            }

            return new Result<Account>()
            {
                Data = q,
                Code = Constants.ResultCode.Success
            };

        }

        public async Task<Result<List<Account>>> FindAllCustomerAccountsAsync(int cust_id)
        {
            if (cust_id ==0 )
            {
                return new Result<List<Account>>()
                {
                    ErrorMessage = "CustomerId is required",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            var q =  await _dbContext.Set<Account>()
                .Where(a => a.CustomerId == cust_id)
                .ToListAsync();

            if (q == null)
            {
                return new Result<List<Account>>()
                {
                    Data = null,
                    Code = Constants.ResultCode.NotFound
                };

            }

            return new Result<List<Account>>()
            {
                Data = q,
                Code = Constants.ResultCode.Success
            };
        }

    }
}


