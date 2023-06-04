namespace EventDrivenProgramming;
internal class Program
{
  private static void Main(string[] args)
  {
    Person p = new();
    p.PokeHandlerSub = PokeHarryHandler;

    p.Poke();
    p.Poke();
    p.Poke();
    p.Poke();
  }

  public static void PokeHarryHandler(object? sender, EventArgs e)
  {
    if (sender is null) return;

    Person? p = sender as Person;
    if (p is null) return;

    Console.WriteLine("Harry is angery " + p.Anger);
  }
}