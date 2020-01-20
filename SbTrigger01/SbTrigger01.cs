using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SbTrigger01
{
    public static class SbTrigger01
    {
        [FunctionName("SbTrigger01")]
        public static void Run([ServiceBusTrigger("BasicQueue", Connection = "connection")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
