using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product.SubProducts
{
    public class Discount
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
