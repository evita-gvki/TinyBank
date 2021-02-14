using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Xunit;
using TinyBank.Core;
using TinyBank.Core.Model;
using TinyBank.Core.Test;
using TinyBank.Core.Services;
using TinyBank.Core.Data;
using Microsoft.EntityFrameworkCore;



namespace TinyBank.Core.Tests
{
    public class CustomerTests : IClassFixture<TinyBankFixture>
    {
        private ICustomerService _customers;
        private Data.CrmDbContext _dbContext;
        private IAccountService _accounts;
        private ITransactionService _transactions;

        public CustomerTests(TinyBankFixture fixture)
        {
            _customers = fixture.Scope.ServiceProvider
                .GetRequiredService<ICustomerService>();
            _dbContext = fixture.Scope.ServiceProvider
                .GetRequiredService<Data.CrmDbContext>();
            _accounts = fixture.Scope.ServiceProvider
                    .GetRequiredService<IAccountService>();
            _transactions = fixture.Scope.ServiceProvider
                    .GetRequiredService<ITransactionService>();
        }

        [Fact]
        //public void Add_Customer_Success()
        //{
        //    var options = new Services.Options.RegisterCustomerOptions()
        //    {
        //        Name = "Gregory",
        //        Surname = "Grigoriou",
        //        VatNumber = "888555222",
        //        Category = CustomerCategory.NomikoProswpo,
        //        PaymentMethod = PaymentMethods.Card
        //    };

        //    var customer = _customers.Register(options);

        //    Assert.NotNull(customer);

        //    var savedCustomer = _dbContext.Set<Customer>()
        //        .Where(c => c.CustomerId == customer.CustomerId)
        //        .SingleOrDefault();
        //    Assert.NotNull(savedCustomer);
        //    Assert.Equal(options.Name, savedCustomer.Name);
        //    Assert.Equal(options.Surname, savedCustomer.Surname);
        //    Assert.Equal(options.VatNumber, savedCustomer.VatNumber);
        //    Assert.Equal(options.Category, savedCustomer.Category);
        //    Assert.Equal(options.PaymentMethod, savedCustomer.PaymentMethod);
        //}

        //public void Add_Customer_Failure()
        //{
        //    var options = new Services.Options.RegisterCustomerOptions()
        //    {
        //        Name = "Gregory",
        //        Surname = "Grigoriou",
        //        VatNumber = "888555222",
        //        Category = CustomerCategory.NomikoProswpo,
        //     // PaymentMethod = PaymentMethods.Card
        //    };
        //      var customer = _customers.RegisterAsync(options);

        //    Assert.ThrowsAny<System.Exception>(
        //        () => {
        //            customer =null;
        //        });

        //}

        //public void Find_Customer_Failure()
        //{
        //    var options = new Services.Options.FindCustomerOptions()
        //    {
        //        //  Name = "Gregory",
        //        Surname = "Grigoriou",
        //        //  VatNumber = "888555222"                            
        //    };
        //    var customer = _customers.FindCustomerAsync(options);

        //    Assert.NotNull(customer);
        //    //if >1 exception??


        ////AccountsTests
        //public void Create_Account_Success()
        //{
        //    var options = new Services.Options.CreateAccountOptions()
        //    {
        //        AccountId = "4444444444",
        //        CustomerId = 1
        //    };
        //    var account = _accounts.CreateAccountAsync(options);

        //    Assert.NotNull(account);

        //    var savedAccount = _dbContext.Set<Account>()
        //        .Where(a => a.CustomerId == account.CustomerId)
        //        .Where(a => a.AccountId == account.AccountId)
        //        .SingleOrDefault();
        //    Assert.NotNull(savedAccount);
        //    Assert.Equal(options.AccountId, savedAccount.AccountId);
        //    Assert.Equal(options.CustomerId, savedAccount.CustomerId);
        //}

        //TransactionTests
        public void Create_Transaction_Success()
        {
            var options = new Services.Options.CreateTransactionOptions()
            {                
                AccountId = "4444444444",
                CustomerId = 1,
                 Category = TrnCategory.Xrewsh,
                 TrnAmount =300
            };
            var trn = _transactions.CreateTransactionAsync(options).Result.Data;

            Assert.NotNull(trn);

            var savedtrn = _dbContext.Set<Transaction>()
                .Where(t => t.TrnAmount == trn.TrnAmount)
                .Where(t => t.AccountId == trn.AccountId)
                .Where(t => t.Category ==  trn.Category)
             //   .Where(t =>t.Created == System.DateTimeOffset.Now)
                .SingleOrDefault();

            Assert.NotNull(savedtrn);
            Assert.Equal(options.AccountId, savedtrn.AccountId);
            Assert.Equal(options.Category, savedtrn.Category);
            Assert.Equal(options.TrnAmount, savedtrn.TrnAmount);
           
        }
}
}
