using TinyBank.Core.Model;

using TinyBank.Core.Services.Options;
using System.Threading.Tasks;

namespace TinyBank.Core.Services
{
    public interface ICustomerService
    {
        public Task<Result<Customer>> RegisterAsync(RegisterCustomerOptions options);
        public Task<Result<Customer>> FindCustomerAsync(FindCustomerOptions options);

    }
}
