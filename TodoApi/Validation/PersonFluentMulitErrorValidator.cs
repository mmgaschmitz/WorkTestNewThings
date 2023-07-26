using System.ComponentModel.DataAnnotations;
using TodoApi.Model;
using FluentValidation;
using FluentValidation.Validators;

namespace TodoApi.Validation
{
    public class PersonFluentMultiErrorValidator : AbstractValidator<PersonFluentMuliError>
    {
        public PersonFluentMultiErrorValidator()
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
                                    .Must(IsValidName).WithMessage("Naam mag alleen letters bevatten")
                                    .SetValidator(new ContaintFieldTekst<PersonFluentMuliError, string?>("Maurice", "Elvira"));

            // RuleFor(p => p.AchterNaam).NotEmpty();
            RuleFor(p => p.AchterNaam).Cascade(CascadeMode.Continue)
                                      .NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(20)
                                      .Must(IsValidName).WithMessage("Naam mag alleen letters bevatten")
                                      .SetValidator(new ContaintFieldTekst<PersonFluentMuliError, string?>("Schmitz", "Jassen"));


            RuleFor(p => p.Leeftijd).InclusiveBetween(18, 65);
            RuleFor(p => p).NotNull().Must(CheckAgeAtName).WithMessage("Schmitz moet ouder zijn dan 50");

        }

        // Simpele versie zonder parameters
        private bool IsValidName(PersonFluentMuliError aPerson, string? name)
        {

            if (name is not null)
            {
                return name.All(Char.IsLetter);
            }
            return false;
        }

        /// <summary>
        /// Controlles tussen velden zonder serve en geen async
        /// </summary>
        /// <param name="comPref"></param>
        /// <returns></returns>
        private bool CheckAgeAtName(PersonFluentMuliError aPerson)
        {

            if (aPerson is not null && aPerson.AchterNaam is not null && aPerson.AchterNaam.Contains("Schmitz") && aPerson.Leeftijd >= 50)
            {
                return true;
            }
            return false;
        }
    }
}
