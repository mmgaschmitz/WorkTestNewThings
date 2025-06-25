using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentInterface
{
    // Alles kan door elkaar gebruikt worden
    internal class Customer
    {
        // Try private or public, must be private => anders kun je alles al vullen in de constructor
        private readonly Context _context = new (); // Initializes the context

        // set the value for properties
        public Customer FirstName(string firstName)
        {
            _context.FirstName = firstName;
            return this;   // Hier wordt this retourneert, waarmee je de fluent chaning mee realiseert
        }

        public Customer LastName(string lastName)
        {
            _context.LastName = lastName;
            return this;
        }

        public Customer Kind(string Kind)
        {
            _context.Kind = Kind;
            return this;
        }

        public Customer Address(string address)
        {
            _context.Address = address;
            return this;
        }

        // Prints the data to console
        public void Print()
        {
            Console.WriteLine($"First name: {_context.FirstName} \nLast name: {_context.LastName} \nKind: {_context.Kind} \nAddress: {_context.Address}");
        }
    }

}
