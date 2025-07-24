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
    public class Salad : Dish
    {
        private readonly string _veggies;
        private readonly string? _cheeses;
        private readonly string? _dressing;

        public Salad(string veggies, string? cheeses, string? dressing)
        {
            _veggies = veggies;
            _cheeses = cheeses;
            _dressing = dressing;
        }

        public override void Display()
        {
            Console.WriteLine("\nSalad:");
            Console.WriteLine($" Veggies: {_veggies}");
            Console.WriteLine($" Cheeses: {_cheeses}");
            Console.WriteLine($" Dressing: {_dressing}");
        }

        public override void DisplayMore()
        {
            Console.WriteLine("\nMORE Salad:");
            Console.WriteLine($" Veggies: {_veggies}");
            Console.WriteLine($" Cheeses: {_cheeses}");
            Console.WriteLine($" Dressing: {_dressing}");
        }
    }
}
