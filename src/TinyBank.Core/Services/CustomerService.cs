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
    public class CustomerService : ICustomerService
    {
        // ToDo->ReadOnly
        private CrmDbContext _dbContext;

        public CustomerService(CrmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Note: Initial implemementation. Will be modified
        // to return a more structured and informative type.
        public async Task<Result<Customer>> RegisterAsync(RegisterCustomerOptions options)
        {
            if (string.IsNullOrWhiteSpace(options?.VatNumber))
            {
                //  return null;
                return new Result<Customer>()
                {
                    ErrorMessage = "VatNumber is empty",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            if (options.VatNumber.Length != 9)
            {
                //return null;
                return new Result<Customer>()
                {
                    ErrorMessage = "VatNumber requires 9 digits",
                    Code = Constants.ResultCode.BadRequest 
                };

            }

            if (string.IsNullOrWhiteSpace(options.Surname) ||
              string.IsNullOrWhiteSpace(options.Name))
            {
                return new Result<Customer>()
                {
                    ErrorMessage = "Name or Surname is empty",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            if (options.Category == 0)
            {
                return new Result<Customer>()
                {
                    ErrorMessage = "Category is empty",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            if (options.PaymentMethod == 0)
            {
                return new Result<Customer>()
                {
                    ErrorMessage = "Payment Method is empty",
                    Code = Constants.ResultCode.BadRequest
                };
            }

            var customer = new Customer()
            {
                Name = options.Name,
                Surname = options.Surname,
                VatNumber = options.VatNumber,
                Category = options.Category,
                PaymentMethod = options.PaymentMethod
            };

            _dbContext.Add(customer);
            try
            {
                await _dbContext.SaveChangesAsync();
            }catch (Exception)
                {
                return new Result<Customer>()
                {
                    Code = Constants.ResultCode.InternalServerError,
                    ErrorMessage = "Customer could not be saved"
                };
            }


            return new Result<Customer>()
            {
                Code = Constants.ResultCode.Success,
                Data = customer
            };
        }

        public async Task<Result<Customer>> FindCustomerAsync(FindCustomerOptions options)
        {
            var q = _dbContext.Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Name))
            {
                q = q.Where(c => c.Name == options.Name);
            }

            if (!string.IsNullOrWhiteSpace(options.Surname))
            {
                q = q.Where(c => c.Surname == options.Surname);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                q = q.Where(c => c.VatNumber == options.VatNumber);
            }

            if (options.CustomerId != 0)
            {
                q = q.Where(c => c.CustomerId == options.CustomerId);
            }

             var result = await q.SingleOrDefaultAsync();

            if (result == null)
            {   
                return new Result<Customer>()
                {
                    Data = null,
                    Code = Constants.ResultCode.NotFound
                };

            }
            return new Result<Customer>()
            {
                Data = result,
                Code = Constants.ResultCode.Success
            };

         }
    }
}
