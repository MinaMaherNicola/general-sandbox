namespace eventsPractice
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      RegisterService registerService = new();
      registerService.UserRegisterationHandler += SendNewUserWelcomeEmail;
      registerService.RegisterUser("minamahernicola@outlook.com");
    }

    // this is event invokation behavior
    private static void SendNewUserWelcomeEmail(object? sender, UserRegisterationEventArgs e)
    {
      System.Console.WriteLine($"Sending welcome email to user {e.Email}");
    }
  }
}