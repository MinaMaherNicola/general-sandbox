using DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Contract;
using DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Models;

namespace DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Implementation
{
    internal class FlightControl : IFlightControl
    {
        private readonly Dictionary<Guid, FlightModel> currentFlights = new();
        public void ClearFlightToLand(FlightModel flight)
        {
            if (currentFlights.ContainsKey(flight.Id))
            {
                currentFlights[flight.Id].ClearedToLand = true;
            }
        }

        public void RegisterFlight(FlightModel flight)
        {
            if (!currentFlights.ContainsKey(flight.Id))
            {
                currentFlights.Add(flight.Id, flight);
            }
        }
    }
}
