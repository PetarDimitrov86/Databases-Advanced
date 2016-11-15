namespace UsersDatabase.Models
{
    using System.Linq;
    using System.Text.RegularExpressions;

    partial class User
    {
        private bool EmailIsValid(string email)
        {
            string regularExpressinString = @"\s([a-zA-Z0-9][a-zA-Z_\-.]*[a-zA-Z0-9])@([a-zA-Z-]+\.[a-zA-Z-]+(\.[a-zA-Z-]+)*)\b";
            Regex regex = new Regex(regularExpressinString);
            if (!regex.IsMatch(email))
            {
                return false;
            }

            return true;
        }

        private bool CheckIfDigitIsContained(string value)
        {
            int number = 0;
            foreach (char c in value)
            {
                if (int.TryParse(c.ToString(), out number))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckIfSpecialSymbolsIsContained(string value)
        {
            char[] specialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?' };
            foreach (char c in value)
            {
                if (specialSymbols.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckIfUpperLetterIsContained(string value)
        {
            foreach (char c in value)
            {
                if (c.ToString() == c.ToString().ToUpper())
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckIfLowLetterIsContained(string value)
        {
            foreach (char c in value)
            {
                if (c.ToString() == c.ToString().ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
