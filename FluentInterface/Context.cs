using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentInterface
{
    // Defines the data context
    internal class Context
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Kind { get; set; }
        public string? Address { get; set; }
    }
}
