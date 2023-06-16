using System.Net.NetworkInformation;

namespace ThreadingBasics
{
  public class ThreadsExamples
  {
    public List<string> contacts { get; private set; }
    private ReaderWriterLockSlim contactLock = new();

    public ThreadsExamples()
    {
      contacts = new();
    }
    public static void BackgroundThreadExample()
    {
      var bgThread = new Thread(() =>
      {
        while (true)
        {
          Console.WriteLine($"Is network available? {NetworkInterface.GetIsNetworkAvailable()}");
          Thread.Sleep(100);
        }
      });

      bgThread.IsBackground = true;
      bgThread.Start();
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine("Main thread working...");
        Task.Delay(500);
      }
      Console.WriteLine("Done");
      Console.ReadKey();
    }
    public static void ParameterizedThreadExample()
    {
      var bgThread = new Thread((object? data) =>
    {
      if (data is null) return;
      if (!int.TryParse(data.ToString(), out int maxCount)) return;

      for (int i = 0; i < maxCount; i++)
      {
        Console.WriteLine($"Is network available? {NetworkInterface.GetIsNetworkAvailable()}");
        Thread.Sleep(100);
      }
    });

      bgThread.IsBackground = true;
      bgThread.Start(12);
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine("Main thread working...");
        Task.Delay(500);
      }
      Console.WriteLine("Done");
      Console.ReadKey();
    }
    public static void ThreadSleepExample()
    {
      Console.WriteLine("Hello World!");
      var bgThread = new Thread((object? data) =>
      {
        if (data is null) return;
        if (!int.TryParse(data.ToString(), out int maxCount)) return;

        for (int i = 0; i < maxCount; i++)
        {
          Console.WriteLine($"Is network available? {NetworkInterface.GetIsNetworkAvailable()}");
          Thread.Sleep(10);
        }
      });
      bgThread.Start(12);
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine("Main thread working...");
        Thread.Sleep(100);
      }
      Console.WriteLine("Done");
      Console.ReadKey();
    }

    public void WriteNewContact(string newContact)
    {
      try
      {
        contactLock.EnterWriteLock();
        contacts.Add(newContact);
      }
      finally
      {
        contactLock.ExitWriteLock();
      }

    }
    public List<string> ReadContacts()
    {
      try
      {
        contactLock.EnterReadLock();
        return contacts;
      }
      finally
      {
        contactLock.ExitReadLock();
      }
    }
  }
}