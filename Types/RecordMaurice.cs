using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public record RecordMauriceOld(    
        // in dit voorbeeld kun je string? AchterNaam later toeovoegen de Pietje, Pietje2 en Pietje3 ook.
        string Name,
        int Leeftijd,
        // string? AchterNaam,  // moet eigenlijk zomaar kunnen, omdat dit veld optioneel is, maar gaat toch fout.
        // int Pietje2, // Dit levert een default value van 0 op, dit wil je niet doen. je mist dan het verplichte 
        //int? Pietje3,  // Dit levert een default value van null op
        DrankjeOld[] LijstDrankjes
    );

    public record DrankjeOld
    (
        string Naam,
        string? Wens,
        int Aantal 
    );


    public record RecordMaurice
    {
        // in dit voorbeeld is string? AchterNaam later toegevoegd en de Pietje, Pietje2 en Pietje3 ook.
        [Obsolete("In de toekomst niet meer gebruiken. Om uitbreiding van optionele velden in de interface niet meteen een breaking change krijgt. " +
            "Door het gebruik van records met alleen een default constructor")]
        [SetsRequiredMembers]
        public RecordMaurice(string Name, int Leeftijd, Drankje[] LijstDrankjes)  // Constructor om niet gewijzigd versie nog te gebruiken
        {
            this.Name = Name;
            this.Leeftijd = Leeftijd;
            this.LijstDrankjes = LijstDrankjes;
        }
        public RecordMaurice() 
        {
        }  

        public required string Name { get; init; }
        public required int Leeftijd { get; init; }
        public string? AchterNaam { get; init; } // optioneel mag gewoon
        //public required int Pietje { get; init; }  // Dit toevoegen is  wel een breaking change.
        public int Pietje2 { get; init; }  // Dit levert een default value van 0 op, dit wil je niet doen. je mist dan het verplichte 
        public int? Pietje3 { get; init; }  // Dit levert een default value van null op

        public Drankje[] LijstDrankjes { get; init; } = [];  
    }

    
    public record Drankje
    {
        [SetsRequiredMembers]
        public Drankje(string Naam, string? Wens, int Aantal)
        {
            this.Naam = Naam;
            this.Wens = Wens;   
            this.Aantal = Aantal;
        }

        public Drankje()
        {
        }
        public required string Naam { get; init; }
        public string? Wens { get; init; }
        public required int Aantal { get; init; }
    }
}
