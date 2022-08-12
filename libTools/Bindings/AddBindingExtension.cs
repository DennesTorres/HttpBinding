using Microsoft.Azure.WebJobs;
using System;

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
