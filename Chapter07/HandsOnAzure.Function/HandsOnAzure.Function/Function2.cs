using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace HandsOnAzure.Function
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static void Function2_Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]
            string myQueueItem, TraceWriter log)
        {
        }
    }
}
