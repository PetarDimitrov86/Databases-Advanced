using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _07_Tags.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = (string)value;
            int lowercaseLetterCount = 0;
            int uppercaseLetterCount = 0;
            int digitCount = 0;
            int specialSymbolCount = 0;
            string specialSymbols = "!@#$%^&*()_+<>?";
            for (int i = 0; i < stringValue.Length; i++)
            {
                if (char.IsUpper(stringValue[i]))
                {
                    uppercaseLetterCount++;
                }
                else if (char.IsLower(stringValue[i]))
                {
                    lowercaseLetterCount++;
                }
                else if (char.IsDigit(stringValue[i]))
                {
                    digitCount++;
                }
                else if (specialSymbols.Contains(stringValue[i]))
                {
                    specialSymbolCount++;
                }
            }

            if (uppercaseLetterCount == 0 || lowercaseLetterCount == 0 || digitCount == 0 || specialSymbolCount == 0)
            {
                return false;
            }
            return true;
        }
    }
}
