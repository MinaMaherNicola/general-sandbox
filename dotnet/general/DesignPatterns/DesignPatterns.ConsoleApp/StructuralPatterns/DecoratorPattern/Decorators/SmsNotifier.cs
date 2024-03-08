using DesignPatterns.ConsoleApp.StructuralPatterns.DecoratorPattern.Concrete;

namespace DesignPatterns.ConsoleApp.StructuralPatterns.DecoratorPattern.Decorators
{
    public class SmsNotifier : Notifier
    {
        public override void SendNotification(string message)
        {
            base.SendNotification(message);
            Console.WriteLine($"Sending this message via SMS: {message}");
        }
    }
}
