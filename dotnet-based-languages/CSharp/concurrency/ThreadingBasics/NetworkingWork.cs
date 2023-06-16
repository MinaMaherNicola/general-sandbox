using System.Net.NetworkInformation;

namespace ThreadingBasics
{
  public class NetworkingWork
  {
    public void CancelCheckNetworkStatus2(object data)
    {
      bool loop = true;
      CancellationToken cancellationToken = (CancellationToken)data;
      cancellationToken.Register(() =>
      {
        loop = false;
      });
      while (loop)
      {
        Console.WriteLine($"Is network up? {NetworkInterface.GetIsNetworkAvailable()}");
      }
    }
    public void CancelCheckNetworkStatus(object data)
    {
      CancellationToken cancellationToken = (CancellationToken)data;

      while (!cancellationToken.IsCancellationRequested)
      {
        Console.WriteLine($"Is network up? {NetworkInterface.GetIsNetworkAvailable()}");
      }
    }
    public void CheckNetworkStatus(object data)
    {
      for (int i = 0; i < 12; i++)
      {
        Console.WriteLine($"{(string)data}. Is network up? {NetworkInterface.GetIsNetworkAvailable()}");
      }
    }
  }
}