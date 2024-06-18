using DesignPatterns.ConsoleApp.StructuralPatterns.DecoratorPattern.Contract;

namespace DesignPatterns.ConsoleApp.StructuralPatterns.DecoratorPattern.Concrete
{
    public class Notifier : INotify
    {
        public virtual void SendNotification(string message)
        {
            Console.WriteLine($"Sending this message via email: {message}");
        }
    }
}
