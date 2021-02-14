//using System.Linq;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using Xunit;
//using TinyBank.Core;
//using TinyBank.Core.Model;
//using TinyBank.Core.Test;
//using TinyBank.Core.Services;
//using TinyBank.Core.Data;

//namespace TinyBank.Core.Test
//{
//    class AccountTests
//    {
//        public class AccountsTests : IClassFixture<TinyBankFixture>
//        {
//            private IAccountService _accounts;
//            private Data.CrmDbContext _dbContext;

//            public AccountsTests(TinyBankFixture fixture)
//            {
//                _accounts = fixture.Scope.ServiceProvider
//                    .GetRequiredService<IAccountService>();
//                _dbContext = fixture.Scope.ServiceProvider
//                .GetRequiredService<Data.CrmDbContext>();
//            }

//            [Fact]
//            public void Create_Account_Success()
//            {
//                var options = new Services.Options.CreateAccountOptions()
//                {
//                    AccountId = "4444444444",
//                    CustomerId = 1
//                };
//                var account = _accounts.CreateAccount(options);

//                Assert.NotNull(account);

//                var savedAccount = _dbContext.Set<Account>()
//                    .Where(a => a.CustomerId == account.CustomerId)
//                    .Where(a => a.AccountId == account.AccountId)
//                    .SingleOrDefault();
//                Assert.NotNull(savedAccount);
//                Assert.Equal(options.AccountId, savedAccount.AccountId);
//                Assert.Equal(options.CustomerId, savedAccount.CustomerId);

//            }
//        }
//    }
//}


