using Types;


// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine(args);

//static bool IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };

//var result = IsConferenceDay(DateTime.Now);

//result = IsConferenceDay(new DateTime(2020,5,20));
//result = IsConferenceDay(new DateTime(2020, 5, 21));


//string notNull = "Hello";
//string? nullable = default;
// notNull = nullable!; // null forgiveness

/*

int[] numbers = [0, 10, 20, 30, 40, 50];
int start = 1;
int amountToTake = 3;
int[] subset = numbers[start..(start + amountToTake)];
Display(subset);  // output: 10 20 30

int margin = 1;
int[] inner = numbers[margin..^margin];
Display(inner);  // output: 10 20 30 40

string line = "one two three";
int amountToTakeFromEnd = 5;
Range endIndices = ^amountToTakeFromEnd..^0;
string end = line[endIndices];
Console.WriteLine(end);  // output: three

void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));

*/
// 


List<int>? numbers = null;
(numbers ??= new List<int>()).Add(5);

double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
{
    return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
}

var sum = SumNumbers(new List<double[]> { new double[] { } }, 0);
sum = SumNumbers(new()  { new double[] { } }, 0);
sum = SumNumbers(new List<double[]> { new double[] { 10d, 20d, 30d, 40d, 60d }, new double[] { 1540d, 45320d, 34530d, 3440d} }, 0);
sum = SumNumbers(null, 0);
Console.WriteLine(sum);  // output: NaN


var a = new Kort();
a.Naam = "dd";
a.Getal = 12;

a = new Kort {Naam="dd", Getal=23 };


Kort b = new() {Naam="dd", Getal=33 };

// target type;
M(b ? 1 : 2);

void M(short);
void M(long);


Console.WriteLine("End");

