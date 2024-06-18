namespace eventsPractice;

// this is the event and the data that will be held by the event
public class UserRegisterationEventArgs
{
  public string Email { get; set; } = null!;

  public UserRegisterationEventArgs(string email)
  {
    Email = email;
  }
}