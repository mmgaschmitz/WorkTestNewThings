using System.ComponentModel.DataAnnotations;
using TodoApi.Model;

namespace TodoApi.Validation
{
    public class PersonValidatorAttribute : ValidationAttribute
    {
        // Extra optie binnen dit attribue
        public string CheckName { get; }
        public int MinAge { get; }
        public PersonValidatorAttribute(string checkName, int minAge)
        {
            CheckName = checkName;
            MinAge = minAge;

        }

        private string GetErrorMessageFoutieveLeeftijdBijStartName() => $"Model Validator Atribute Bij naam {CheckName} moet leeftijd {MinAge} zijn";
        private static string GetErrorMessageNaamIsLeeg() => $"Model Validator Atribute  Naam moet gevuld zij";
        private static string GetErrorMessageLeeftijdIsLeeg() => $"Model Validator Atribute  Leeftijd moet gevuld zij";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is not null)
            {
                var aPerson = (Person)validationContext.ObjectInstance;

                // velden check.
                if (aPerson.VoorNaam is null)
                {
                    return new ValidationResult(GetErrorMessageNaamIsLeeg());
                }

                if (aPerson.Leeftijd is null)
                {
                    return new ValidationResult(GetErrorMessageLeeftijdIsLeeg());
                }

                if (aPerson.VoorNaam is not null && aPerson.Leeftijd is not null &&
                    (aPerson.VoorNaam.Contains(CheckName) && aPerson.Leeftijd < MinAge))
                {
                    return new ValidationResult(GetErrorMessageFoutieveLeeftijdBijStartName());
                }
            }
            return ValidationResult.Success;
        }
    }
}
