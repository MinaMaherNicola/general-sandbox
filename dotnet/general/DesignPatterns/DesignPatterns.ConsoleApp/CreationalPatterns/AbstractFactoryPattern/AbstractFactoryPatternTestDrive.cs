using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryContract.Factories.AbstractFactory;
using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Factories.ConcreteFactories;
using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ConcreteProducts.AfricanProducts;
using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ConcreteProducts.AlaskanProducts;
using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern
{
    public class AbstractFactoryPatternTestDrive
    {
        public static void Start()
        {
            IAbstractFactory factory;
            List<IHunter> hunters = new();
            List<IPrey> Preys = new();
            while (true)
            {
                Console.WriteLine($"\nWelcome to Hunter-Prey Simulation!, you created {hunters.Count} Hunters and {Preys.Count} Preys!\n" +
                    $"Please choose what type of animal would you like:\n1. African Lion\n2. African Gazelle\n3. Alaskan Wolf\n4. Alaskan Rabbit\n5. Exit");
                if (hunters.Any() && Preys.Any())
                {
                    Console.WriteLine("To make a hunter hunt a prey, please click 6!");
                }
                if (!int.TryParse(Console.ReadLine(), out int desiredAnimal))
                {
                    Console.WriteLine("Make sure to that your input is correct!\n");
                    continue;
                }
                switch (desiredAnimal)
                {
                    case 1:
                        factory = new AfricanAnimalsFactory();
                        hunters.Add(factory.CreateHunter());
                        continue;
                    case 2:
                        factory = new AfricanAnimalsFactory();
                        Preys.Add(factory.CreatePrey());
                        continue;
                    case 3:
                        factory = new AlaskanAnimalFactory();
                        hunters.Add(factory.CreateHunter());
                        continue;
                    case 4:
                        factory = new AlaskanAnimalFactory();
                        Preys.Add(factory.CreatePrey());
                        continue;
                    case 6:
                        if (!hunters.Any() && !Preys.Any())
                            continue;
                        IHunter hunter = hunters.First();
                        if (hunter is AfricanLion)
                        {
                            hunter.Hunt(Preys.First(p => p is AfricanGazelle));
                        }
                        else
                        {
                            hunter.Hunt(Preys.First(p => p is AlaskanRabbit));
                        }
                        continue;
                    default:
                        break;
                }
                break;
            }

        }
    }
}
