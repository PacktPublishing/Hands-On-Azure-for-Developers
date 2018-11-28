using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;

namespace HandsOnAzure.ServiceBus.Reader
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
            var client = new QueueClient("<connection-string>",
                "myfirstqueue");
            client.RegisterSessionHandler((session, message, ct) => Task.FromResult(new SessionHandler()), args => Task.CompletedTask);

            var receiver =
                new MessageReceiver(
                    "<connection-string>",
                    "myfirstqueue");

            while (true)
            {
                var message = await receiver.ReceiveAsync();
                if(message == null) continue;

                Console.WriteLine($"New message: [{message.ScheduledEnqueueTimeUtc}] {Encoding.UTF8.GetString(message.Body)}");

                await receiver.DeadLetterAsync(message.SystemProperties.LockToken, "HandsOnAzure - test");
                await Task.Delay(100);

                var dtqname = EntityNameHelper.FormatDeadLetterPath("myfirstqueue");
            }
        }

        private static async Task MessageHandler(IMessageSession session, Message msg, CancellationToken cancelToken)
        {
            Console.WriteLine(msg.MessageId + " " + msg.SessionId);
            await session.CompleteAsync(msg.SystemProperties.LockToken);
        }
    }

    class SessionHandler : IMessageSession
    {
        public Task CloseAsync()
        {
            throw new NotImplementedException();
        }

        public void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            throw new NotImplementedException();
        }

        public void UnregisterPlugin(string serviceBusPluginName)
        {
            throw new NotImplementedException();
        }

        public string ClientId { get; }
        public bool IsClosedOrClosing { get; }
        public string Path { get; }
        public TimeSpan OperationTimeout { get; set; }
        public ServiceBusConnection ServiceBusConnection { get; }
        public IList<ServiceBusPlugin> RegisteredPlugins { get; }
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            throw new NotImplementedException();
        }

        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, MessageHandlerOptions messageHandlerOptions)
        {
            throw new NotImplementedException();
        }

        public Task CompleteAsync(string lockToken)
        {
            throw new NotImplementedException();
        }

        public Task AbandonAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            throw new NotImplementedException();
        }

        public Task DeadLetterAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            throw new NotImplementedException();
        }

        public Task DeadLetterAsync(string lockToken, string deadLetterReason, string deadLetterErrorDescription = null)
        {
            throw new NotImplementedException();
        }

        public int PrefetchCount { get; set; }
        public ReceiveMode ReceiveMode { get; }
        public Task<Message> ReceiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Message> ReceiveAsync(TimeSpan operationTimeout)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Message>> ReceiveAsync(int maxMessageCount)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Message>> ReceiveAsync(int maxMessageCount, TimeSpan operationTimeout)
        {
            throw new NotImplementedException();
        }

        public Task<Message> ReceiveDeferredMessageAsync(long sequenceNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Message>> ReceiveDeferredMessageAsync(IEnumerable<long> sequenceNumbers)
        {
            throw new NotImplementedException();
        }

        public Task CompleteAsync(IEnumerable<string> lockTokens)
        {
            throw new NotImplementedException();
        }

        public Task DeferAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            throw new NotImplementedException();
        }

        public Task RenewLockAsync(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime> RenewLockAsync(string lockToken)
        {
            throw new NotImplementedException();
        }

        public Task<Message> PeekAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Message>> PeekAsync(int maxMessageCount)
        {
            throw new NotImplementedException();
        }

        public Task<Message> PeekBySequenceNumberAsync(long fromSequenceNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Message>> PeekBySequenceNumberAsync(long fromSequenceNumber, int messageCount)
        {
            throw new NotImplementedException();
        }

        public long LastPeekedSequenceNumber { get; }
        public Task<byte[]> GetStateAsync()
        {
            throw new NotImplementedException();
        }

        public Task SetStateAsync(byte[] sessionState)
        {
            throw new NotImplementedException();
        }

        public Task RenewSessionLockAsync()
        {
            throw new NotImplementedException();
        }

        public string SessionId { get; }
        public DateTime LockedUntilUtc { get; }
    }
}
