using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace libTools.Bindings
{
    public class FromBodyValueProvider<T> : IValueProvider
    {
        private HttpRequest request;
        private ILogger logger;

        public FromBodyValueProvider(HttpRequest request, ILogger logger)
        {
            this.request = request;
            this.logger = logger;
        }

        public async Task<object> GetValueAsync()
        {
            try
            {
                string requestBody = await new StreamReader(this.request.Body).ReadToEndAsync();
                T result = JsonConvert.DeserializeObject<T>(requestBody);
                return result;
            }
            catch (System.Exception ex)
            {
                this.logger.LogCritical(ex, "Error deserializing object from body");

                throw ex;
            }
        }

        public Type Type => typeof(object);
        public string ToInvokeString() => string.Empty;
    }
}
