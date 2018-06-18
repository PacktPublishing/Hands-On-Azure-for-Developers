using System.IO;
using Microsoft.Azure.WebJobs;

namespace MyFirstWebJobWebJobsSDK
{
    public class Manual
    {
        [NoAutomaticTrigger]
        public static void ManualFunction(
            TextWriter logger,
            string value)
        {
            logger.WriteLine($"Received message: {value}");
        }
    }
}
