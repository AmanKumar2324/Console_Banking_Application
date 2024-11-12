using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Banking_Application.Utils
{
    public static class Validator
    {
        // Validate if a string is null, empty, or whitespace
        public static bool IsValidInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
