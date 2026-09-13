using System;
using System.Text.RegularExpressions;

namespace Hotel_Management_System.Utilities
{
    public static class ValidationHelper
    {
        public static bool IsRequired(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            try
            {
                var pattern = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
                return Regex.IsMatch(value, pattern);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPhone(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            var pattern = "^[0-9+()\\-\\s]{6,20}$";
            return Regex.IsMatch(value, pattern);
        }
    }
}
