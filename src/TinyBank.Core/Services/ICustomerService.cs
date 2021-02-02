using TinyBank.Core.Model;

using TinyBank.Core.Services.Options;

namespace TinyBank.Core.Services
{
    public interface ICustomerService
    {
        public Customer Register(RegisterCustomerOptions options);
    }
}
