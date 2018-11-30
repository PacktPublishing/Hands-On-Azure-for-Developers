using Microsoft.Azure.WebJobs;

namespace MyFirstWebJobWebJobsSDK
{
    class Program
    {
        static void Main()
        {
            var config = new JobHostConfiguration();
            config.UseTimers();

            var host = new JobHost(config);

            host.Call(typeof(Manual).GetMethod("ManualFunction"), new { value = "Hello world!" });

            host.RunAndBlock();
        }
    }
}
