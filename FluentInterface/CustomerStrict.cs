namespace FluentInterface
{
    // Volgorder afdwingen bv, eerst Kind dan (FirstName of LastName) en Adress en dan pas print(), 
    // zijn stages: Kind, names, adress, print, elke stage in 1 interface

    public interface ICanSetKind
    {
        public ICanSetNames Kind(string Kind);
    }

    public interface ICanSetNames
    {
        public ICansetAdress FirstName(string firstName);
        public ICansetAdress LastName(string lastName);
   }

    public interface ICansetAdress 
    {
        public ICanPrint Adress(string address);
    }

    public interface ICanPrint
    {
        public void Print();
    }

    public class CustomerStrict: ICanSetKind, ICanSetNames, ICansetAdress, ICanPrint
    {
        // Try private or public, must be private => anders kun je alles al vullen in de constructor
        private readonly Context _context = new(); // Initializes the context

        // set the value for properties
        public ICanSetNames Kind(string Kind)
        {
            _context.Kind = Kind;
            return this;
        }

        public ICansetAdress FirstName(string firstName)
        {
            _context.FirstName = firstName;
            return this;   // Hier wordt this retourneert, waarmee je de fluent chaning mee realiseert
        }

        public ICansetAdress LastName(string lastName)
        {
            _context.LastName = lastName;
            return this;
        }


        public ICanPrint Adress(string address)
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
