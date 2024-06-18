using DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Products.ConcreteProducts
{
    public class TexasPizza : IPizza
    {
        public void EatPizza()
        {
            Console.WriteLine("Eating Texas Pizza");
        }
    }
}
