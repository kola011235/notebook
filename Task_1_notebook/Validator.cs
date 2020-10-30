using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_1_notebook
{
    class Validator
    {
        String phoneNumberPattern = @"^((\+7|7|8)+([0-9]){10})$";
        String namePattern = @"^[a-zA-Z]+$";

        public bool isValidName(string name)
        {
            return (Regex.IsMatch(name, namePattern));
        }
        public bool isValidPhoneNumber(string name)
        {
            return (Regex.IsMatch(name, phoneNumberPattern));
        }
        public bool isValidYearOfBirth(int year)
        {
            return (year > 1930) && (year < 2010);
        }
    }
}
