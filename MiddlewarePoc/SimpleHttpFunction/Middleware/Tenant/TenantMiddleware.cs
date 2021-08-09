using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleHttpFunction.Extensions;
using System;
using System.Threading.Tasks;

namespace SimpleHttpFunction.Middleware
{
    public class TenantMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly TestOptions _options;
        public TenantMiddleware(IOptions<TestOptions> options)
        {
            _options = options.Value;
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                var httpData = context.GetHttpRequestData();

                var log = context.GetLogger<TenantMiddleware>();
                log.LogInformation("INFO: TenantMiddleware executing?");
                log.LogDebug("DEBUG: TenantMiddleware executing.");
                log.LogError("ERROR: TenantMiddleware executing.");

                log.LogDebug("httpUrl: {url}, httpMethod: {method}", httpData.Url.ToString(), httpData.Method);

                await next.Invoke(context);
            }
            catch (Exception)
            {
                throw;
            }
        }      
    }
}
