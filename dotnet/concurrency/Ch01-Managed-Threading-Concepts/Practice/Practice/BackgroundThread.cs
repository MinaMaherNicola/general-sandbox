using System.Net.NetworkInformation;

namespace Practice
{
    public static class BackgroundThread
    {
        public static void Example()
        {
            Thread bgThread = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine($"Is network up? Answer: {NetworkInterface.GetIsNetworkAvailable()}");
                    Thread.Sleep(100);
                }
            });
            bgThread.IsBackground = true;
            bgThread.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread is working...");
                Thread.Sleep(500);
            }
            Console.WriteLine("Done");
        }
    }
}
