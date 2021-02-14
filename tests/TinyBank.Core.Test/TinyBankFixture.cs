using System;
using System.Collections.Generic;
using System.Text;
using TinyBank.Core.Services.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace TinyBank.Core.Test
{
    public class TinyBankFixture: IDisposable
    {
        public IServiceScope Scope { get; private set; }

        public TinyBankFixture()
        {
                var config = new ConfigurationBuilder()
                    .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
                    .AddJsonFile("appsettings.json", false)
                    .Build();

                // Initialize Dependency container
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddAppServices(config);

                Scope = serviceCollection
                    .BuildServiceProvider()
                    .CreateScope();
         }

        public void Dispose()
        {
            Scope.Dispose();
        }
        
    }
}

