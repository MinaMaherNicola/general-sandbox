using System.Net.NetworkInformation;

namespace Practice
{
    public static class ThreadPoolExample
    {
        public static async Task Example()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"Is network available? Answer: {NetworkInterface.GetIsNetworkAvailable()}");
                }
                Thread.Sleep(100);
            });

            for (int i = 0; i < 10; i++)
            {
                await Console.Out.WriteLineAsync("Main thread working");
                await Task.Delay(500);
            }
            await Console.Out.WriteLineAsync("Done");
        }
    }
}
