using DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Contract;
using DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Implementation;

namespace DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Models
{
    public class FlightModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public bool ClearedToLand { get; internal set; }

        private readonly IFlightControl flightControl = new FlightControl();

        public FlightModel()
        {
            flightControl.RegisterFlight(this);
        }

        public void RequestLanding()
        {
            Console.WriteLine("Requesting landing permission");
            Task.Delay(500);
            flightControl.ClearFlightToLand(this);
            Console.WriteLine("Landing permission granted");
        }
    }
}
