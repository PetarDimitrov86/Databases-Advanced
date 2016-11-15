using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _02_User.Validations
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = (string)value;
            string forbiddenSymbols = "_-.";
            string pattern = @"([a-zA-Z0-9._-]+)@([a-zA-Z0-9.]+.[a-zA-Z0-9.]+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(stringValue);

            if (matches.Count < 1)
            {
                return false;
            }

            foreach (Match match in matches)
            {
                for (int i = 0; i < forbiddenSymbols.Length; i++)
                {
                    if (match.Groups[1].ToString().StartsWith(forbiddenSymbols[i].ToString()) || match.Groups[1].ToString().EndsWith(forbiddenSymbols[i].ToString()))
                    {
                        return false;
                    }
                }
                if (match.Groups[2].ToString().StartsWith(".") || match.Groups[2].ToString().EndsWith("."))
                {
                    return false;
                }
            }
            return true;
        }

        //    [AttributeUsage(AttributeTargets.Property)]
        //public class Email : ValidationAttribute
        //{
        //    public override bool IsValid(object value)
        //    {
        //      string email = (string) value;
        //      Regex emailRegex = new Regex(@"^[A-z][\w.]+@[\w]+.[A-z]{2,3}$");
        //        if (emailRegex.IsMatch(email))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}
    }
}