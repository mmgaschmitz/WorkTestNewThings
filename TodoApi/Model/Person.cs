using System.ComponentModel.DataAnnotations;
using TodoApi.Validation;

namespace TodoApi.Model
{
    [PersonValidator(checkName:"Maurice", minAge:50)]
    public class Person:  IValidatableObject
    {
        [StringLength(20, MinimumLength=5, ErrorMessage = "VoorNaam moet minimaal 5 zijn en maximaal 20 ")]
        [Required]
        [Display(Name ="Uw voornaam")]
        [PersonFieldValidator(startNameWith:"My")]
        public string? VoorNaam { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Required]
        [Display(Name = "Uw achternaam")]
        [PersonFieldValidator(startNameWith: "MyA")]
        public string? AchterNaam { get; set; }
        // [Required]
        [Range(18,65)]
        // [PersonFieldValidator(startNameWith: "Kan dit wel")]  // Fpoutje
        public int? Leeftijd { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var aPerson = (Person)validationContext.ObjectInstance;
            if (aPerson is not null)
            {
                if (aPerson.VoorNaam is not null && aPerson.VoorNaam.Contains("Maurice") && aPerson.Leeftijd <= 50)
                {
                    yield return new ValidationResult(GetErrorMessagLeeftijdTeJong());

                }
            }
            else
            {
                yield return new ValidationResult(GetErrorMessagEenFout());  //onzin

            }
        }

        private static string  GetErrorMessagEenFout() => $"Validator Function in model Fout melding X geen person aanwezig "; // onzin
        private static string GetErrorMessagLeeftijdTeJong() => $"Validator Function in model  Fout melding maurice is te jong ";  
    }
}
