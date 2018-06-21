using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Serverless
{
    public static class GetSignalRConfiguration
    {
        private static AzureSignalR signalR = new AzureSignalR(
            Environment.GetEnvironmentVariable("SignalR"));

        [FunctionName("GetSignalRConfiguration")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route="config")]
            HttpRequest req,
            TraceWriter log)
        {
            return new OkObjectResult(
                new
                {
                    hubUrl = signalR.GetClientHubUrl("chatServerlessHub"),
                    accessToken = signalR.GenerateAccessToken("chatServerlessHub")
                });
        }
    }
}
