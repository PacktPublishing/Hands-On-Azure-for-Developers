using System.IO;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace HandsOnAzure.Function
{
    public static class Function3
    {
        [FunctionName("Function3")]
        public static HttpResponseMessage Function3_Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Function3/name/{name}")]
            HttpRequestMessage req, string name, TraceWriter log)
        {
            return req.CreateResponse();
        }

        [FunctionName("BlobInput")]
        public static void BlobInput(
            [QueueTrigger("myqueue-items")] string myQueueItem,
            [Blob("samples-workitems/{queueTrigger}", FileAccess.Read)] Stream myBlob,
            TraceWriter log)
        {
        }

        [FunctionName("ResizeImage")]
        public static void ResizeImage_Run(
            [BlobTrigger("sample-images/{name}")] Stream image,
            [Blob("sample-images-sm/{name}", FileAccess.Write)] Stream imageSmall,
            [Blob("sample-images-md/{name}", FileAccess.Write)] Stream imageMedium)
        {
            // There goes your code...
        }

        [FunctionName("QueueTrigger")]
        [return: Blob("output-container/{id}")]
        public static string QueueTrigger_Run([QueueTrigger("myqueue")] string input, TraceWriter log)
        {
            return "Some string...";
        }
    }
}
