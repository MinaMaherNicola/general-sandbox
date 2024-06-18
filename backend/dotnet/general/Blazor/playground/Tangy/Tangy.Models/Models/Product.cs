namespace Tangy.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<ProductProperty> Properties { get; set; }
    }
}
