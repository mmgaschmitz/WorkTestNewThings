using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Components
{
    /// <summary>
    /// The abstract Component class
    /// </summary>
    public abstract class Dish
    {
        public abstract void Display();
        public abstract void DisplayMore();
    }
}
