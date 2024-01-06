using DesignPatterns.ConsoleApp.StructuralPatterns.AdapterPattern.Adapter;
using DesignPatterns.ConsoleApp.StructuralPatterns.AdapterPattern.LegacyData;
using DesignPatterns.ConsoleApp.StructuralPatterns.AdapterPattern.NewData;

namespace DesignPatterns.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NewUser newUser = new NewUserAdapter(LegacyUser.GetUser());
            Console.WriteLine($"{newUser.Name}");
        }
    }
}