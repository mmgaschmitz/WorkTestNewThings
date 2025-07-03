using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Components
{
    /// <summary>
    /// A ConcreteComponent class
    /// </summary>
    public class Pasta : Dish
    {
        private readonly string _pasta;
        private readonly string _sauce;

        public Pasta(string pasta, string sauce)
        {
            _pasta = pasta;
            _sauce = sauce;
        }

        public override void Display()
        {
            Console.WriteLine("\nPasta: ");
            Console.WriteLine($" Pasta: {_pasta}");
            Console.WriteLine($" Sauce: {_sauce}");
        }

        public override void DisplayMore()
        {
            Console.WriteLine("\nMORE Pasta: ");
            Console.WriteLine($" Pasta: {_pasta}");
            Console.WriteLine($" Sauce: {_sauce}");
        }
    }
}