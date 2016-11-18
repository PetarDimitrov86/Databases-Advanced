namespace UsersDatabase.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Property)]
    class PasswordAttribute : ValidationAttribute
    {
        private readonly int _passMinLen;
        private readonly int _passMaxLen;

        public PasswordAttribute(int passwordMinLen = 0, int passwordMaxLen = 30)
        {
            this._passMinLen = passwordMinLen;
            this._passMaxLen = passwordMaxLen;
        }

        public bool ShouldContainLowercase { get; set; }

        public bool ShouldContainUppercase { get; set; }

        public bool ShouldContainDigit { get; set; }

        public bool ShouldContainSpecialSymbol { get; set; }

        public override bool IsValid(object value)
        {
            string passAsString = value as string;

            if (passAsString == null)
            {
                throw new ArgumentException("Property must be of type string.");
            }

            if (passAsString.Length < this._passMinLen | passAsString.Length > this._passMaxLen | this._passMinLen > this._passMaxLen)
            {
                return false;
            }

            if (this.ShouldContainDigit && !this.ContainsDigit(passAsString))
            {
                return false;
            }

            if (this.ShouldContainUppercase && !this.ContainsUppercase(passAsString))
            {
                return false;
            }

            if (this.ShouldContainLowercase && !this.ContainsLowercase(passAsString))
            {
                return false;
            }

            if (this.ShouldContainSpecialSymbol && !this.ContainsSpecialSymbol(passAsString))
            {
                return false;
            }

            return true;
        }

        private bool ContainsSpecialSymbol(string passAsString)
        {
            char[] specialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?' };
            foreach (char c in passAsString)
            {
                if (specialSymbols.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsLowercase(string passAsString)
        {
            if (passAsString.Count(char.IsLower) != 0)
            {
                return true;
            }

            return false;
        }

        private bool ContainsUppercase(string passAsString)
        {
            if (passAsString.Count(char.IsUpper) != 0)
            {
                return true;
            }

            return false;
        }

        private bool ContainsDigit(string passAsString)
        {
            if (passAsString.Count(char.IsDigit) != 0)
            {
                return true;
            }

            return false;
        }
    }
}
