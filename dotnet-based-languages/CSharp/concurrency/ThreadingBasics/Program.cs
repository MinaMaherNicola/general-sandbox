using ThreadingBasics;

NetworkingWork networkingWork = new();

Thread pingThread = new Thread(networkingWork.CancelCheckNetworkStatus2!);
CancellationTokenSource cancellationTokenSrc = new CancellationTokenSource();
pingThread.Start(cancellationTokenSrc.Token);

for (int i = 0; i < 10; i++)
{
  Console.WriteLine("Main thread is here");
  Thread.Sleep(100);
}
cancellationTokenSrc.Cancel();
pingThread.Join();
cancellationTokenSrc.Dispose();
Console.WriteLine("Done");
Console.ReadKey();