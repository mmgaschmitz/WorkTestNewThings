using System.ComponentModel.DataAnnotations;
using TodoApi.Model;
using FluentValidation;
using FluentValidation.Validators;
using static System.Net.Mime.MediaTypeNames;

namespace TodoApi.Validation
{
    public class PersonFluentValidator : AbstractValidator<PersonFluent>
    {
        public PersonFluentValidator()
        {
            /* dubbele Controlles omdat ze meerder keer zijn opgenomen 
            RuleFor(p => p.VoorNaam).NotEmpty();
            RuleFor(p => p.VoorNaam).Cascade(CascadeMode.Stop).NotEmpty().MinimumLength(5).WithMessage("Rule Fluent VoorNaam moet minimaal 5 zijn en maximaal 20").MaximumLength(20).WithMessage("Rule Fluent VoorNaam moet minimaal 5 zijn en maximaal 20");
            // RuleFor(p => p.AchterNaam).NotEmpty();
            RuleFor(p => p.AchterNaam).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(p => p.Leeftijd).InclusiveBetween(18, 65);
            // Custom Inline Controle zonder paraters
            RuleFor(p => p.VoorNaam).Cascade(CascadeMode.Stop).NotEmpty().Must(a => a.Contains("Maurice")).WithMessage("Maurice Tesyt");

            // Custuom controle  zonder parameters via function
            RuleFor(p => p.VoorNaam).Cascade(CascadeMode.Stop).NotEmpty().Must(IsValidName).WithMessage("Maurice Tesyt");
            // Uitgebreide validator met invoer parameters
            RuleFor(p => p.VoorNaam).Cascade(CascadeMode.Stop).NotEmpty().SetValidator(new ContaintFieldTekst<PersonFluent, string?>("Maurice", "Elvira"));
            RuleFor(p => p.AchterNaam).Cascade(CascadeMode.Stop).NotEmpty().SetValidator(new ContaintFieldTekst<PersonFluent, string?>("Janssen", "Schmitz"));

             Einde dubbel */

            // RuleFor(p => p.VoorNaam).NotEmpty();
            // RuleFor(p => p.VoorNaam).Cascade(CascadeMode.Stop).NotEmpty().MinimumLength(5).WithMessage("Rule Fluent VoorNaam moet minimaal 5 zijn en maximaal 20").MaximumLength(20).WithMessage("Rule Fluent VoorNaam moet minimaal 5 zijn en maximaal 20");
            RuleFor(p => p.VoorNaam).Cascade(CascadeMode.Continue)
                                    .NotEmpty()
                                    .MinimumLength(5).WithMessage("Rule Fluent VoorNaam moet minimaal 5 zijn en maximaal 20")
                                    .MaximumLength(20).WithMessage("Rule Fluent VoorNaam moet minimaal 5 zijn en maximaal 20")
                                    .SetValidator(new ContaintFieldTekst<PersonFluent, string?>("Maurice", "Elvira"));

            // RuleFor(p => p.AchterNaam).NotEmpty();
            RuleFor(p => p.AchterNaam).Cascade(CascadeMode.Continue)
                                      .NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(20)
                                      .SetValidator(new ContaintFieldTekst<PersonFluent, string?>("Schmitz", "Jassen"))
                                      .Must(IsValidName).WithMessage("Rule IsValidNAme Interfield controle gaat fout");

            RuleFor(p => p.Leeftijd).InclusiveBetween(18, 65);
            RuleFor(p => p).Must(InterFieldChecks).WithMessage("Rule Fluent Interfield controle gaat fout");

        }

        private bool InterFieldChecks(PersonFluent aPerson)
        {
            string CheckName = "elvira";
            int MinAge = 30;

            if (aPerson.VoorNaam is not null && aPerson.Leeftijd is not null &&
                (aPerson.VoorNaam.Contains(CheckName) && aPerson.Leeftijd < MinAge))
            {
                return false;
            }
            return true;
        }


        // Simpele versie zonder parameters
        private static bool IsValidName(PersonFluent aPerson, string? name)
        {

            if (name is not null)
            {
                return name.All(Char.IsLetter);
            }
            return false;
        }


    }

    /// <summary>
    /// Het attribuut is eigenlijk niet nodig, en levert ook een foute uitvoer op mbt tot de opmaak
    /// Welke veld heeft welke fout is niet meer zichtbaar
    /// Omdat ValidationResult slechts 1 veld aan kan.
    /// </summary>

    public class PersonFluentValidatorAttribute : ValidationAttribute
    {
        // Extra optie binnen dit attribue
        public string CheckName { get; }
        public int MinAge { get; }
        public PersonFluentValidatorAttribute(string checkName, int minAge)
        {
            CheckName = checkName;
            MinAge = minAge;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var aPerson = (PersonFluent)validationContext.ObjectInstance;

            // Eerst veld controles
            var validator = validationContext.GetService(typeof(PersonFluentValidator)) as PersonFluentValidator
                            ?? throw new InvalidOperationException(GetErrorMessageFoutieveLeeftijdBijStartName());

            var result = validator.Validate(aPerson);

            // Inter veld controles, dit hoeft niet hier maar kan ook in de class PersonFluentValidator
            if (result.IsValid)
            {
                // nog interveld controlles, hier dan uiteindelijk niet handig
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

            return result.IsValid
                ? ValidationResult.Success
                : new ValidationResult(result.ToString());
        }

        private string? GetErrorMessageFoutieveLeeftijdBijStartName() => $"Model Fluent Validator Atribute Bij naam {CheckName} moet leeftijd {MinAge} zijn";
        private static string GetErrorMessageNaamIsLeeg() => $"Model Fluent Validator Atribute  Naam moet gevuld zij";
        private static string GetErrorMessageLeeftijdIsLeeg() => $"Model Fluent Validator Atribute  Leeftijd moet gevuld zij";

    }
}
