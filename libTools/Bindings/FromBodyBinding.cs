using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace libTools.Bindings
{
    public class FromBodyBinding<T> : IBinding
    {
        private readonly ILogger logger;
        public FromBodyBinding(ILogger logger)
        {
            this.logger = logger;
        }
        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            // Get the HTTP request
            var request = context.BindingData["req"] as HttpRequest;
            return Task.FromResult<IValueProvider>(new FromBodyValueProvider<T>(request, logger));
        }

        public bool FromAttribute => true;


        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            return null;
        }

        public ParameterDescriptor ToParameterDescriptor() => new ParameterDescriptor();
    }
}
