namespace Photography.Models.CustomAttributes
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string pattern = @"\+[0-9]{1,3}\/[0-9]{8,10}";

            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(value.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
