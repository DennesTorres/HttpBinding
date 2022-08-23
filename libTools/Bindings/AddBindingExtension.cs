using Microsoft.Azure.WebJobs;
using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

namespace libTools.Bindings
{
    public static class AddBindingExtension
    {
        public static IWebJobsBuilder AddBodyBindingProvider(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            
            builder.AddExtension<FromBodyBindingProviderConfig>();
            return builder;
        }
    }
}
