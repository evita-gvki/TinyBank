using TinyBank.Core.Model;
using TinyBank.Core.Services.Options;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TinyBank.Core.Services
{
    public interface IAccountService
    {
        public Task<Result<Account>> CreateAccountAsync(CreateAccountOptions options);
        public Task<Result<Account>> FindAccountAsync(string acc_id);
        public Task<Result<List<Account>>> FindAllCustomerAccountsAsync(int cust_id);
    }
}
