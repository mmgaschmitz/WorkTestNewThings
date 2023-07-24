using TodoApi.Validation;
using static TodoApi.Validation.PersonFluentValidator;

namespace TodoApi.Model
{
    [PersonFluentValidator(checkName: "Maurice", minAge: 50)]
    public class PersonFluent
    {
        public string? VoorNaam { get; set; }
        public string? AchterNaam { get; set; }
        public int? Leeftijd { get; set; }
    }
}
