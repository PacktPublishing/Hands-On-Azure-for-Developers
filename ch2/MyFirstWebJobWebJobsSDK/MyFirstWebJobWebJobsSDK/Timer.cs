using System;
using System.IO;
using Microsoft.Azure.WebJobs;

namespace MyFirstWebJobWebJobsSDK
{
    public class Timer
    {
        public static void TimerFunction(
            [TimerTrigger("* */1 * * * *")] TimerInfo timer,
            TextWriter logger)
        {
            logger.WriteLine($"Message triggered at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
