using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using ReliableActor.Interfaces;

namespace ReliableActor.Client
{
    class Program
    {
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            IReliableActor actor = ActorProxy.Create<IReliableActor>(ActorId.CreateRandom(), new Uri("fabric:/ReliableActors/ReliableActorService"));
            while (true)
            {
                var count = await actor.GetCountAsync(CancellationToken.None);
                Console.Write($"Current count is: {count}\r\n");
                await actor.SetCountAsync(++count, CancellationToken.None);

                Thread.Sleep(1000);
            }
        }
    }
}
