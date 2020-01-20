using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SbTrigger01
{
    public static class SbTrigger02
    {
        [FunctionName("SbTrigger02")]
        public static void Run([ServiceBusTrigger("BasicQueue", Connection = "servicebus001968_RootManageSharedAccessKey_SERVICEBUS")]string myQueueItem, ILogger log)
        {
            log.LogInformation($" {myQueueItem}");
        }
    }
}
