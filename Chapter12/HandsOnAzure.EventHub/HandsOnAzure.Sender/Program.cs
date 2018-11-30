using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace HandsOnAzure.Sender
{
    internal class Program
    {
        private const string ConnectionString = "<connection-string>";
        private const string KeyName = "<key-name>";
        private const string SASKey = "<sas-key>";
        private const string Namespace = "<namespace>";
        private const string HubName = "<hub-name>";

        private static void Main()
        {
            var eventHubSender = CreateSender();
            var eventHubClient = EventHubClient.CreateFromConnectionString(ConnectionString, HubName);

            try
            {
                while (true)
                {
                    var message = JsonConvert.SerializeObject(new { Id = Guid.NewGuid().ToString(), Date = DateTimeOffset.Now });
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, message);
                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(message)));

                    Task.Delay(100).Wait();
                }
                
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        private static EventHubSender CreateSender()
        {
            var publisher = "handsonazurepublisher";
            var token = SharedAccessSignatureTokenProvider.GetSharedAccessSignature(KeyName, SASKey,
                $"sb://{Namespace}.servicebus.windows.net/{HubName}/publishers/{publisher}", TimeSpan.FromHours(24));
            var connectionString =
                ServiceBusConnectionStringBuilder.CreateUsingSharedAccessSignature(
                    new Uri($"sb://{Namespace}.servicebus.windows.net"), HubName, publisher, token);
            var eventHubSender = EventHubSender.CreateFromConnectionString(connectionString);
            return eventHubSender;
        }
    }
}
