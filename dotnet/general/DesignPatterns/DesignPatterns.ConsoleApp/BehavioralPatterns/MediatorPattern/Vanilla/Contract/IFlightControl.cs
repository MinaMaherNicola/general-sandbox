using DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Models;

namespace DesignPatterns.ConsoleApp.BehavioralPatterns.MediatorPattern.Vanilla.Contract
{
    internal interface IFlightControl
    {
        void RegisterFlight(FlightModel flight);
        void ClearFlightToLand(FlightModel flight);
    }
}
