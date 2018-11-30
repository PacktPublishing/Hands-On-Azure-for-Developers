using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace HandsOnAzure.ServiceBus
{
    internal class Program
    {
        private static void Main()
        {
            MainAsync().GetAwaiter().GetResult();

            Console.ReadLine();
        }

        private static async Task MainAsync()
        {
            var client = new QueueClient("<connection-string>", "myfirstqueue");
            var message = "This is my message!";

            Console.WriteLine("Sending a message...");
            await client.SendAsync(new Message(Encoding.UTF8.GetBytes(message)) { SessionId = Guid.Empty.ToString()});
        }
    }
}
