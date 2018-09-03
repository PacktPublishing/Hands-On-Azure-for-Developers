using System;
using Microsoft.ServiceBus.Messaging;

namespace HandsOnAzure.Receiver
{
    internal class Program
    {
        private const string EventHubConnectionString = "<connection-string>";
        private const string EventHubName = "<hub-name>";
        private const string StorageAccountName = "<storage-name>";
        private const string StorageAccountKey = "<storage-key>";

        private static void Main()
        {
            var storageConnectionString =
                $"DefaultEndpointsProtocol=https;AccountName={StorageAccountName};AccountKey={StorageAccountKey}";

            var eventProcessorHostName = Guid.NewGuid().ToString();
            var eventProcessorHost = new EventProcessorHost(eventProcessorHostName, EventHubName, EventHubConsumerGroup.DefaultGroupName, EventHubConnectionString, storageConnectionString);
            Console.WriteLine("Registering EventProcessor...");

            var options = new EventProcessorOptions();
            options.ExceptionReceived += (sender, e) => { Console.WriteLine(e.Exception); };
            eventProcessorHost.RegisterEventProcessorAsync<MyFirstEventProcessor>(options).Wait();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();
            eventProcessorHost.UnregisterEventProcessorAsync().Wait();
        }
    }
}
