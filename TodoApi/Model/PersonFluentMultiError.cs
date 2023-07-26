using TodoApi.Validation;
using static TodoApi.Validation.PersonFluentValidator;

namespace TodoApi.Model
{
    public class PersonFluentMuliError
    {
        public string? VoorNaam { get; set; }
        public string? AchterNaam { get; set; }
        public int? Leeftijd { get; set; }
        public SubContact Contact { get; set; } 
    }

    public class SubContact
    {
        public string? Mail { get; set; }
        public string? Telefoon { get; set; }
    }

}
