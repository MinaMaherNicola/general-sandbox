namespace EventDrivenProgramming;
public class Person
{
  public EventHandler? PokeHandlerSub { get; set; }
  public int Anger { get; set; }

  public void Poke()
  {
    if (PokeHandlerSub is null) return;

    Anger++;


    if (Anger > 3)
    {
      PokeHandlerSub.Invoke(this, EventArgs.Empty);
    }
  }
}