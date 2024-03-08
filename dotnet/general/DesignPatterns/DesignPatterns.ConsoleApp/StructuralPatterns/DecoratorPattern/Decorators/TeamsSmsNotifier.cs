namespace DesignPatterns.ConsoleApp.StructuralPatterns.DecoratorPattern.Decorators
{
    internal class TeamsSmsNotifier : SmsNotifier
    {
        public override void SendNotification(string message)
        {
            base.SendNotification(message);
            Console.WriteLine($"Sending this message via Teams: {message}");
        }
    }
}
