using System.Net.NetworkInformation;

namespace EvolutionOfMultithreading;

public class AsyncAwaitExamples
{
  public async Task CheckNetworkStatusAsync()
  {
    Task t = NetworkCheckInternalAsync();
    for (int i = 0; i < 8; i++)
    {
      System.Console.WriteLine("Top level method working");
      await Task.Delay(100);
    }
    await t;
  }

  private async Task NetworkCheckInternalAsync()
  {
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine($"Is network available? Answer: {NetworkInterface.GetIsNetworkAvailable()}");
      await Task.Delay(100);
    }
  }
}