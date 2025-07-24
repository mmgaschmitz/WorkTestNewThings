using Decorator.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorators
{
    /// <summary>
    /// The Abstract Base Decorator
    /// </summary>
    public abstract class AbstractDecorator : Dish
    {
        protected Dish _dish;

        protected AbstractDecorator(Dish dish)
        {
            _dish = dish;
        }

        public override void Display()
        {
            _dish.Display();
        }
        public override void DisplayMore()
        {
            _dish.Display();
        }
    }
}
