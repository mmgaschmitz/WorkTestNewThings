using FluentValidation.Validators;
using FluentValidation;

namespace TodoApi.Validation
{
    /// <summary>
    /// Algemene Custom validator tbv string fields, om op 2 woorden te controleren 
    /// te weten compareValueA en compareValueB, die mee worden gegeven als je deze validator toepast.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="fieldName"></typeparam>
    public class ContaintFieldTekst<T, fieldName> : PropertyValidator<T, string?>
    {
        private readonly string _CompareValueA;
        private readonly string _CompareValueB;

        public ContaintFieldTekst(string compareValueA, string compareValueB)
        {
            _CompareValueA = compareValueA;
            _CompareValueB = compareValueB;
        }

        public override bool IsValid(ValidationContext<T> context, string? field)
        {
            if (field != null)
            {
                if (!field.Contains(_CompareValueA) && !field.Contains(_CompareValueB))
                {
                    context.MessageFormatter.AppendArgument("CompareWoordA", _CompareValueA);
                    context.MessageFormatter.AppendArgument("CompareWoordB", _CompareValueB);
                    context.MessageFormatter.AppendArgument("CurrentValue", field);
                    return false;
                }
            }

            return true;
        }

        public override string Name => "ContaintFieldTekst";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "CustomError With Params en Default Message: {PropertyName} has the value '{CurrentValue}' but must contain one of the the words {CompareWoordA} or {CompareWoordB}.";
    }
}