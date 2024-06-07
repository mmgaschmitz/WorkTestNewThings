using System;

public record PersonRec(string FirstName, string LastName);

public record PersonRecAndersNotProtected
{ 
    public required string FirstName {  get; set; }  // set of init
    public string LastName { get; set; }  // wel of geen Nullable ?

    public string ShortName { get; set; }

};

public record PersonRecAndersProtected
{
    // met of zondxer constructor gemixed met {get; init;}
    //public PersonRecAndersProtected(string lastName)
    //{ 
    //    this.LastName = lastName;
    //}

    // Combinatie niet handig, kies voor {get; init} of readonly
    // Required als extra veld 
    public required string FirstName { get; init; }  // set of init  , required gaat over verplicht vullen of toch een nullabel maken
    public string? LastName { get; init; }   // required and readonly => {get; init;}

    // public readonly string? LastName;   // required and readonly => {get; init;}
    public int Leeftijd { get; init; }
    public int Leeftijd2 { get; set; }
    public required int Leeftijd3 { get; set; }

    public required string? ShortName { get; set; }  // required icm {get; set;} vs required icm {get;  init;}

};


public record class PersonRecClass(string FirstName, string LastName);
public record struct PersonRecStruct(string FirstName, string LastName);


namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var Rec1 = new PersonRec("Maurice", "Schmitz");
            Rec1 = new PersonRec("Maurice2", "Schmitz2");
            // kan niet
            // Rec1.FirstName = "Maurice Changed";
            var Rec2 = new PersonRecClass("Maurice", "Schmitz");
            // kan niet
            // Rec2.FirstName = "Maurice Changed";
            var Rec3 = new PersonRecStruct("Maurice", "Schmitz");
            Rec3.FirstName = "Maurice Changed";

            var Rec4 = Rec2;
            var Rec5 = Rec3;

            PersonRecStruct Rec6;
            //Rec6.FirstName = "Elvira";
            Rec6 = new();
            Rec6.FirstName = "Elvira";

            PersonRecClass Rec7;
            //Rec6.FirstName = "Elvira";
            Rec7 = new PersonRecClass("Elvira", "Sijsytermans");
            // Rec7.FirstName = "Elvira";


            // Zelf in controle
            PersonRecAndersNotProtected Record10;
            PersonRecAndersNotProtected Record11;
            PersonRecAndersNotProtected Record12;

            Record10 = new PersonRecAndersNotProtected() { FirstName = "Maurice", LastName = "Sxhmitz" };
            Record10.ShortName = "Msc";
            Record10.FirstName = "Maurice Changed";
            Record10 = new PersonRecAndersNotProtected() { FirstName = "Maurice2", LastName = "Sxhmitz2" };

            // Andere manieren van initialisatie
            Record11 = new PersonRecAndersNotProtected { FirstName = "Maurice", LastName = "Sxhmitz" };
            Record11.ShortName = "Msc";
            Record12 = new PersonRecAndersNotProtected { FirstName = "Maurice", LastName = "Schmitz", ShortName = "MSc" };

            // nu init ipv set voor de helft
            PersonRecAndersProtected Record20;
            // var Record20 = new PersonRecAndersProtected(FirstName: "Maurice", LastName: "Schmitz");
            //var Record20 = new PersonRecAndersProtected(LastName: "Schmitz");
            // var Record20 = new PersonRecAndersProtected { LastName=  "Schmitz"};
            // var Record20 = new PersonRecAndersProtected { FirstName= "Maurice", LastName= "Schmitz"};
            // var Record20 = new PersonRecAndersProtected { FirstName = "Maurice", LastName = "Schmitz", ShortName = "MSc" };
            // Record20 = new PersonRecAndersProtected { FirstName = "Maurice", LastName = "Schmitz" };
            // Record20.ShortName = "Msc3";
            // Dit kan niet meer
            // Record20.FirstName = "Maurice Changed";
            //Record20 = new PersonRecAndersProtected() { FirstName = "Maurice2", LastName = "Sxhmitz2" };
            Record20 = new PersonRecAndersProtected {FirstName="Elvira", LastName ="Sijstermans", Leeftijd =21, Leeftijd3=30, ShortName="Els" };
            Record20 = new PersonRecAndersProtected { FirstName = "Elvira", LastName = "Sijstermans", Leeftijd3 = 32, ShortName = "Els" };
            Record20 = new PersonRecAndersProtected { FirstName = "Elvira", LastName = "Sijstermans", Leeftijd3 = 21, Leeftijd2 = 23, ShortName = "Els" };
            // kan niet
            // Record20.Leeftijd = 34;
            Record20.Leeftijd2 = 45;
            Record20.Leeftijd3 = 45;


            Console.WriteLine("Einde");
        }
    }
}