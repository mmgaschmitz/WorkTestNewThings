
namespace FluentInterface
{
    // Volgorder afdwingen bv, eerst Kind dan (FirstName of LastName) en Adress en dan pas print(), 
    // zijn stages: Kind, names, adress, print, elke stage in 1 interface

    public interface ICanSetKind2
    {
        public ICanSetNames2 Kind2(string Kind);
    }

    public interface ICanSetNames2: ICansetAdress2
    {
        public ICanSetNames2 FirstName2(string firstName);
        public ICanSetNames2 LastName2(string lastName);

    }

    public interface ICansetAdress2
    {
        public ICanPrint2 Adress2(string address);
    }

    public interface ICanPrint2
    {
        public void Print2();
    }
    // Waarom can ik nog altijd alles kiezen
    public class CustomerStrict2: ICanSetKind2, ICanSetNames2, ICansetAdress2, ICanPrint2
    {
        // Try private or public, must be private => anders kun je alles al vullen in de constructor
        private readonly Context _context;

        // Private Constructor
        private CustomerStrict2()
        { 
            this._context = new Context();  
        }

        // starting point
        public static ICanSetKind2 CreateBuild() 
        {
            return new CustomerStrict2();
        }

        // set the value for properties
        public ICanSetNames2 FirstName2(string firstName)
        {
            _context.FirstName = firstName;
            return this;   // Hier wordt this retourneert, waarmee je de fluent chaning mee realiseert
        }

        public ICanSetNames2 LastName2(string lastName)
        {
            _context.LastName = lastName;
            return this;
        }

        public ICanSetNames2 Kind2(string Kind)
        {
            _context.Kind = Kind;
            return this;
        }

        public ICanPrint2 Adress2(string address)
        {
            _context.Address = address;
            return this;
        }

        // Prints the data to console
        public void Print2()
        {
            Console.WriteLine($"First name: {_context.FirstName} \nLast name: {_context.LastName} \nKind: {_context.Kind} \nAddress: {_context.Address}");
        }
    }
}
