using System;
using Microsoft.WindowsAzure.Storage;

namespace QueueStorage.Consumer
{
    internal class Program
    {
        private static void Main()
        {
            var storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("orders");

            var message = queue.GetMessage();
            Console.WriteLine(message.AsString);
            Console.ReadLine();
        }
    }
}
