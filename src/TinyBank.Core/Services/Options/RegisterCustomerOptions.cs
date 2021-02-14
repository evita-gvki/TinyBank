using TinyBank.Core.Model;
namespace TinyBank.Core.Services.Options
{
    public class RegisterCustomerOptions
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string VatNumber { get; set; }
        public CustomerCategory Category { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
    }
}
