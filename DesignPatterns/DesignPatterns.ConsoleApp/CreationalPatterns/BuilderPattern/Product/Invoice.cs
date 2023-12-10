using DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product.SubProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product
{
    public class Invoice
    {
        public List<Item> Items { get; set; }
        public List<Discount> Discounts { get; set; }
    }
}
