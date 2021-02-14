
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TinyBank.Core.Data;
using TinyBank.Core.Config;
using TinyBank.Core.Config.Extensions;
using TinyBank.Core.Services;


namespace TinyBank.Core.Services.Extensions
    {
        public static class ServiceCollectionExtensions
        {
            public static void AddAppServices(
                this IServiceCollection @this, IConfiguration configuration)
            {
                @this.AddSingleton<AppConfig>(
                    configuration.ReadAppConfiguration());

                @this.AddDbContext<CrmDbContext>(
                     (serviceProvider, optionsBuilder) => {
                         var appConfig = serviceProvider.GetRequiredService<AppConfig>();

                         optionsBuilder.UseSqlServer(appConfig.CrmConnectionString);
                     });

                @this.AddScoped<ICustomerService, CustomerService>();
                @this.AddScoped<IAccountService, AccountService>();
                @this.AddScoped<ITransactionService, TransactionService>();

            }
        }
    }



