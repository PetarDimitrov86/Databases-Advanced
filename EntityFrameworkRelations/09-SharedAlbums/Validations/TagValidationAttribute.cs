using System;
using System.ComponentModel.DataAnnotations;

namespace _07_Tags.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TagValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = (string) value;
            if (!stringValue.StartsWith("#") || stringValue.Contains(" ") || stringValue.Length > 20)
            {
                return false;
            }
            return true;
        }
    }
}