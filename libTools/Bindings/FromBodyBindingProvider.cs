using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace libTools.Bindings
{
    public class FromBodyBindingProvider : IBindingProvider
    {
        private readonly ILogger logger;
        public FromBodyBindingProvider(ILogger logger)
        {
            this.logger = logger;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = CreateBodyBinding(logger, context.Parameter.ParameterType);
            return Task.FromResult(binding);
        }

        private IBinding CreateBodyBinding(ILogger log,Type T)
        {
            var type = typeof(FromBodyBinding<>).MakeGenericType(T);
            var a_Context = Activator.CreateInstance(type, new object[] { log });
            return (IBinding)a_Context;
        }
    }
}
