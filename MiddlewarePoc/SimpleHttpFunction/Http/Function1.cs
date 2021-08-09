using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace SimpleHttpFunction.Http
{
    public class Function1
    {
        [Function("Function1")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req,
                                                       FunctionContext context)
        {
            var logger = context.GetLogger(nameof(Function1));
            logger.LogInformation("Retrieving Client Id");


            var okResponse = req.CreateResponse(System.Net.HttpStatusCode.OK);
            await okResponse.WriteAsJsonAsync(nameof(Function1.Run));

            return okResponse;
        }
    }
}
