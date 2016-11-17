namespace UsersDatabase
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string emailString = (string) value;
            if (emailString == null)
            {
                throw new ArgumentException("The email is not of string type.");
            }

            string regularExpressinString = @"([a-zA-Z0-9][a-zA-Z_\-.]*[a-zA-Z0-9])@([a-zA-Z-]+\.[a-zA-Z-]+(\.[a-zA-Z-]+)*)";
            Regex regex = new Regex(regularExpressinString);
            if (!regex.IsMatch(emailString))
            {
                return false;
            }

            return true;  
        }
    }
}
