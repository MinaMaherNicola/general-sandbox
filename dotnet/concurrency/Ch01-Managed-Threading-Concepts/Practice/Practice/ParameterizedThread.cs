using System.Net.NetworkInformation;

namespace Practice
{
    public class ParameterizedThread
    {
        public static void Example(object? data)
        {
            if (data is null || !int.TryParse(data.ToString(), out int counter)) return;

            Thread bgThread = new Thread((object? data) =>
            {
                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine($"Is network up? Answer: {NetworkInterface.GetIsNetworkAvailable()}");
                    Thread.Sleep(100);
                }
            });
            bgThread.IsBackground = true;
            bgThread.Start(counter); // notice how you pass your data to the .Start() method

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread is working...");
                Thread.Sleep(500);
            }
            Console.WriteLine("Done");
        }
    }
}
