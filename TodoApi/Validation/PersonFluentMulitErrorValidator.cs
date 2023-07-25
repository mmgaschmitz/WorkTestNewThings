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
                                    .SetValidator(new ContaintFieldTekst<PersonFluentMuliError, string?>("Maurice", "Elvira"));

            // RuleFor(p => p.AchterNaam).NotEmpty();
            RuleFor(p => p.AchterNaam).Cascade(CascadeMode.Continue)
                                      .NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(20)
                                      .SetValidator(new ContaintFieldTekst<PersonFluentMuliError, string?>("Schmitz", "Jassen"));

            RuleFor(p => p.Leeftijd).InclusiveBetween(18, 65);

        }

        // Simpele versie zonder parameters
        private bool IsValidName(PersonFluent aPerson, string? name)
        {

            if (name is not null)
            {
                return name.All(Char.IsLetter);
            }
            return false;
        }


    }
}
