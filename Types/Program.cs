using Types;
using MathLib;

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

var mathInstance = new MathComp();
var mathResult = mathInstance.Add(100435435, 43543532);

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

//// target type;
// M = (b ? 1 : 2);

//void M(short);
//void M(long);

// Oude manier, zonder extra veld AchterNAam

var mylistOld = new RecordMauriceOld(
    Name: "maurice",
    Leeftijd: 52,
    LijstDrankjes: new DrankjeOld[] {
        new DrankjeOld (Naam : "Cola", Wens : "light", Aantal : 3),
        new DrankjeOld (Naam : "Cola", Wens : "extra suiker", Aantal : 2),
    }
    );



// Oude manier, zonder extra veld AchterNAam

var mylist = new RecordMaurice(
    Name: "maurice",
    Leeftijd: 52,
    LijstDrankjes: new Drankje[] {
        new Drankje (Naam : "Cola", Wens : "light", Aantal : 3),
        new Drankje (Naam : "Cola", Wens : "extra suiker", Aantal : 2),
    }
    );

// Zonder het nieuwe veld
var mylist2 = new RecordMaurice {
    Name = "maurice",
    Leeftijd = 44,
    LijstDrankjes = new Drankje[] { 
        new Drankje {Naam = "Cola", Wens = "light", Aantal = 3},
        new Drankje {Naam = "Cola3",  Aantal = 3},
        new Drankje {Naam = "Sinas",  Aantal = 3},
    }
};

//Met het nieuwe veld
var mylist3 = new RecordMaurice
{
    Name = "maurice",
    Leeftijd = 32,
    AchterNaam = "Schmitz",
    LijstDrankjes = new Drankje[] {
        new Drankje {Naam = "Cola", Wens = "light", Aantal = 3},
        new Drankje {Naam = "Cola2",  Aantal = 3},
        new Drankje {Naam = "Sinas", Aantal = 3},
    }
};


// ?. operator
DrankjeOld? mijndrankje = null;

if (mijndrankje?.Aantal == 10)
{
    Console.WriteLine("IS null: " + mijndrankje?.Aantal);
    Console.WriteLine("IS null: " + mijndrankje?.Aantal);
}
else
{
    Console.WriteLine("IS null: " + mijndrankje?.Aantal);
}

mijndrankje = new DrankjeOld("Limo",null, 10);

if (mijndrankje?.Aantal == 10)
{
    Console.WriteLine("IS not null and 10? " + mijndrankje.Aantal);
}



// nullable

string naam = "maurice";
string naamb = null;
string? naamc = null;

naamb = naamc ?? throw new Exception("hello");


Console.WriteLine(naam, naamb, naamc);

double getal = 232.33D;
// double getalb = null;  // Compile fout
double? getalc = null;

Console.WriteLine(getal.ToString(), getalc);

DateTime datum = DateTime.Now;
// DateTime datumb = null;  // Compile fout
DateTime? datumc = null;

Console.WriteLine(datum.ToString(), datumc.ToString());


Kort mijnobj = new();
Kort mijnobjB = null;
Kort? mijnobjC = null;

Console.WriteLine(mijnobj.Naam?.ToString()) ;
Console.WriteLine( mijnobjB?.Naam);
Console.WriteLine( mijnobjC?.Naam);

 mijnobjB = new();
 mijnobjC = new();
Console.WriteLine(mijnobjB?.Naam?.ToString());
Console.WriteLine(mijnobjC?.Naam?.ToString());




Console.WriteLine("End");