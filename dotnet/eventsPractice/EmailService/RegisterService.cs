namespace eventsPractice;

public class RegisterService
{
  // this is the invokation behavior store
  public EventHandler<UserRegisterationEventArgs>? UserRegisterationHandler { get; set; }

  // this is the event invoker
  protected virtual void OnNewUser(UserRegisterationEventArgs e)
  {
    UserRegisterationHandler?.Invoke(this, e);
  }

  // this is a service method that will do some operations then invoke an event
  public void RegisterUser(string email)
  {
    OnNewUser(new UserRegisterationEventArgs(email));
  }
}