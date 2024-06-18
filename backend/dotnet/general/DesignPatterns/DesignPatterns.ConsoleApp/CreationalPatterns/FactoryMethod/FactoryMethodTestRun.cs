using DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Factories.ConcreteFactories;
using DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Factories.FactoryContract;
using DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod
{
    public class FactoryMethodTestRun
    {
        public static void TestFactoryMethod()
        {
            IPizzaFactory factory;
            while (true)
            {
                Console.WriteLine("Welcome to Pizza Shop!, please choose what type of pizza would you like:\n1. New York Pizza\n2. Texas Pizza\n3. Exit");
                if (!int.TryParse(Console.ReadLine(), out int desiredPizza))
                {
                    Console.WriteLine("Make sure to that your input is correct!");
                    continue;
                }
                switch (desiredPizza)
                {
                    case 1:
                        factory = new NYPizzaFactory();
                        IPizza nyPizza = factory.BakePizza();
                        nyPizza.EatPizza();
                        break;
                    case 2:
                        factory = new TexasPizzaFactory();
                        IPizza texasPizza = factory.BakePizza();
                        texasPizza.EatPizza();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Thank you for visiting!");
                break;
            }
        }
    }
}
