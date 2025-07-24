using Decorator.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorators
{
    public class AvailabilityDecorator : AbstractDecorator
    {
        public int AvailableItems { get; set; }
        protected List<string> customers = new();

        public AvailabilityDecorator(Dish dish, int available) : base(dish)
        {
            AvailableItems = available;
        }

        public void OrderItem(string name)
        {
            if (AvailableItems > 0)
            {
                customers.Add(name);
                AvailableItems--;
            }
            else
                Console.WriteLine($"\nNot enough ingredients for {name}'s dish");
        }

        public override void Display()
        {
            base.Display();

            foreach (string customer in customers)
                Console.WriteLine($"Ordered by {customer}");
        }
        public override void DisplayMore()
        {
            base.DisplayMore();

            foreach (string customer in customers)
                Console.WriteLine($"Ordered by {customer}");
        }
    }
}
