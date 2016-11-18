namespace UsersDatabase.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringifiedValue = value as string;

            if (!stringifiedValue.StartsWith("#"))
            {
                return false;
            }

            if (stringifiedValue.Length > 20)
            {
                return false;
            }

            if (stringifiedValue.Contains(" ") || stringifiedValue.Contains("    "))
            {
                return false;
            }

            return true;
        }
    }
}
