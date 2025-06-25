// See https://aka.ms/new-console-template for more information
using FluentInterface;

Console.WriteLine("Hello, World!");


// Standaard Link voorbeeld waar fluent interface wordt gebruikt
var translations = new Dictionary<string, string>
{
    {"cat", "chat"},
    {"dog", "chien"},
    {"fish", "poisson"},
    {"aap", "translate aap"},
    {"bird", "oiseau"}
};

// Find translations for English words containing the letter "a",
// sorted by length and displayed in uppercase
IEnumerable<string> query = translations
    .Where(t => t.Key.Contains('a'))
    .OrderBy(t => t.Value.Length)
    .Select(t => t.Value.ToUpper());

Console.WriteLine(query);

// The same query constructed progressively:
var filtered = translations.Where(t => t.Key.Contains('a'));
var sorted = filtered.OrderBy(t => t.Value.Length);
var finalQuery = sorted.Select(t => t.Value.ToUpper());

Console.WriteLine(finalQuery);


// Test 2
// Object creation
Customer c1 = new();
// Using the method chaining to assign & print data with a single line
c1.Print();
c1.FirstName("vinod")
    .LastName("srivastav")
    .Kind("male")
    .Address("bangalore")
    .Print();

// Test 3
// Object creation test
// Customer c2 = new Customer { _context = new Context{ Address ="adres", FirstName="first", LastName="last", Kind = "m" } };
Customer c2 = new();
// Using the method chaining to assign & print data with a single line
c2.Print();
c2.FirstName("2vinod")
    .LastName("2srivastav")
    .Kind("2male")
    .Address("2bangalore")
    .Print();


// Test3 met volgorder afdwingen

CustomerStrict c3 = new();
c3.Kind("dd").FirstName("ds").Adress("sdsds").Print();

var c4 = CustomerStrict2.CreateBuild();
c4.Kind2("dd").FirstName2("433").LastName2("DSD").FirstName2("CORE322").Adress2("DSD").Print2();
c4.Kind2("dd").FirstName2("ds").LastName2("ff").FirstName2("ds").Adress2("fddf").Print2();
//Best way,
var c5 = CustomerStrict2.CreateBuild().Kind2("dd").FirstName2("dsds").Adress2("dd");
c5.Print2();

// Zonder ergens op te slaan. maar wat heb je dan er aan?
CustomerStrict2.CreateBuild().Kind2("dd").FirstName2("dsds").Adress2("dd").Print2();
