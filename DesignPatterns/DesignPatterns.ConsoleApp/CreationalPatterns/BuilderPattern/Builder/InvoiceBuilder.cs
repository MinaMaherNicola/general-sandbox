using DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.BuilderContract;
using DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product;
using DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product.SubProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Builder
{
    public class InvoiceBuilder : IBuilder
    {
        private readonly Invoice invoice = new();

        public void BuildDiscounts(List<Discount> discounts)
        {
            invoice.Discounts = discounts;
        }

        public void BuildItems(List<Item> items)
        {
            invoice.Items = items;
        }
    }
}
