using TinyBank.Core;
using TinyBank.Core.Data;
using TinyBank.Core.Model;
using TinyBank.Core.Services.Options;

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
        public Customer Register(RegisterCustomerOptions options)
        {
            if (string.IsNullOrWhiteSpace(options?.VatNumber))
            {
                return null;
            }

            if (options.VatNumber.Length != 9)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Surname) ||
              string.IsNullOrWhiteSpace(options.Name))
            {
                return null;
            }

            var customer = new Customer()
            {
                Name = options.Name,
                Surname = options.Surname,
                VatNumber = options.VatNumber
            };

            _dbContext.Add(customer);
            _dbContext.SaveChanges();

            return customer;
        }
    }
}
