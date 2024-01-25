namespace eventsPractice
{
  public class DelegatesPractice
  {
    public static void RunExample()
    {
      ShowMessage showMessage = ShowInfo;
      showMessage("This is info");

      showMessage = ShowError;
      showMessage("This is an error");

    }
    delegate void ShowMessage(string message);

    private static void ShowInfo(string message)
    {
      System.Console.WriteLine($"Info: {message}");
    }

    private static void ShowError(string message)
    {
      System.Console.WriteLine($"Error: {message}");
    }
  }
}