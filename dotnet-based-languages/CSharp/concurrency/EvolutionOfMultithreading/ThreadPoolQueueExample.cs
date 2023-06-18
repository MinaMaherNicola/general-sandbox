namespace EvolutionOfMultithreading;

public class ThreadPoolQueueExample
{
  public void QueueThreadPool()
  {
    ThreadPool.QueueUserWorkItem((o) =>
    {
      for (int i = 0; i < 20; i++)
      {
        bool isNetworkUp = System.Net.NetworkInformation.
        NetworkInterface.GetIsNetworkAvailable();
        Console.WriteLine($"Is network available? Answer: {isNetworkUp}");
        Thread.Sleep(100);
      }
    });

    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine("Main Thread");
      Thread.Sleep(100);
    }
  }
}