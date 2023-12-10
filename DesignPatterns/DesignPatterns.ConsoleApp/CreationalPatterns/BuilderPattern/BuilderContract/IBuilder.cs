using DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product.SubProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.BuilderContract
{
    public interface IBuilder
    {
        void BuildItems(List<Item> items);
        void BuildDiscounts(List<Discount> discounts);
    }
}
