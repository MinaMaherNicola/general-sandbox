namespace DesignPatterns.ConsoleApp.StructuralPatterns.CompositePattern.Contract
{
    public interface ICalculatePrice
    {
        decimal Price { get; set; }
        decimal CalculatePrice();
    }
}
