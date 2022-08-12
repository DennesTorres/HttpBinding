using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace libTools.Bindings
{
    public class FromBodyBindingProviderConfig : IExtensionConfigProvider
    {
        private readonly ILogger<FromBodyBindingProvider> _logger;
        public FromBodyBindingProviderConfig(ILogger<FromBodyBindingProvider> log) => _logger = log;
        

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<FromBodyAttribute>().Bind(new FromBodyBindingProvider(_logger));

        }
    }
}
