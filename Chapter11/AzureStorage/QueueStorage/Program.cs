using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace QueueStorage.Producer
{
    internal class Program
    {
        private static void Main()
        {
            var storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("orders");
            
            queue.CreateIfNotExists();

            var message = new CloudQueueMessage($"New order ID: {Guid.NewGuid()}");
            queue.AddMessage(message);
        }
    }
}
