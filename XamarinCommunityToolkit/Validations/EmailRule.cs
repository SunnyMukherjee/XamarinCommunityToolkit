using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using XamarinCommunityToolkit;

namespace XamarinCommunityToolkit.Validations
{
    public class EmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public EmailRule()
        {
            ValidationMessage = "Please enter a valid email.";
        }

        public bool Check(T value)
        {
            string checkString = Convert.ToString(value);
            bool isMatch = Regex.IsMatch(checkString, RegularExpressions.Email);
            return isMatch;
        }
    }
}
