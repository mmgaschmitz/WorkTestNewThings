using System.ComponentModel.DataAnnotations;

namespace TodoApi.Validation
{
    public class PersonFieldValidatorAttribute : ValidationAttribute
    {
        // Extra optie binnen dit attribue
        public string StartNameWith { get; }
        public PersonFieldValidatorAttribute(string startNameWith)
        {
            StartNameWith = startNameWith;
        }

        private string GetErrorMessageFoutieveStartName() => $"PersonFieldValidator Naam moet beginnen met {StartNameWith}";
        private static string GetErrorMessageNaamIsLeeg() => $"PersonFieldValidator  Naam moet gevuld zij";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.MemberName is not null)
            {
                if (value is not null && value is string strValue) 
                {
                    if (!strValue.StartsWith(StartNameWith))
                    {
                        return new ValidationResult(GetErrorMessageFoutieveStartName());
                    }

                }
                else
                {
                    return new ValidationResult(GetErrorMessageNaamIsLeeg());
                }
            }
            else
            {
                throw new Exception("PersonFieldValidator Foutieve Membername: " + validationContext.MemberName);
            }

            return ValidationResult.Success;
        }
    }
}
