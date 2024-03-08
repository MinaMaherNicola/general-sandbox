using DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Models;

namespace DesignPatterns.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlightModel model = new();
            Console.WriteLine(model.ClearedToLand);
            model.RequestLanding();
            Console.WriteLine(model.ClearedToLand);
        }
    }
}