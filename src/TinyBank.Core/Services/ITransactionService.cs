using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyBank.Core.Model;
using TinyBank.Core.Services.Options;


namespace TinyBank.Core.Services
{
    public interface ITransactionService
    {
        public Task<Result<Transaction>> CreateTransactionAsync(CreateTransactionOptions options);
    }
}
