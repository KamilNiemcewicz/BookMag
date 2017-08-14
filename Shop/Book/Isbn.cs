using System;

namespace Shop.Book
{
    public static class IsbnValidator
    {
        public static bool TryValidate(string isbn)
        {
            var result = false;

            if (string.IsNullOrEmpty(isbn))
                return false;

            if (isbn.Contains("-"))
                isbn = isbn.Replace("-", "");

            switch (isbn.Length)
            {
                case 10: result = IsValidIsbn10(isbn); break;
                case 13: result = IsValidIsbn13(isbn); break;
                default:
                    throw new Exception("ISBN musi mieæ 10 lub 13 znaków.");
            }

            return result;
        }

        private static bool IsValidIsbn10(string isbn10)
        {
            var result = false;
            if (string.IsNullOrEmpty(isbn10))
                return false;

            if (isbn10.Contains("-"))
                isbn10 = isbn10.Replace("-", "");
            
            // Length must be 10 and only the last character could be a char('X') or a numeric value,
            // otherwise it's not valid.
            if (isbn10.Length != 10 || !long.TryParse(isbn10.Substring(0, isbn10.Length - 1), out long j))
                return false;

            char lastChar = isbn10[isbn10.Length - 1];

            // Using the alternative way of calculation
            var sum = 0;
            for (var i = 0; i < 9; i++)
                sum += int.Parse(isbn10[i].ToString()) * (i + 1);

            // Getting the remainder or the checkdigit
            var remainder = sum % 11;

            // If the last character is 'X', then we should check if the checkdigit is equal to 10
            if (lastChar == 'X')
            {
                result = (remainder == 10);
            }
            // Otherwise check if the lastChar is numeric
            // Note: I'm passing sum to the TryParse method to not create a new variable again
            else if (int.TryParse(lastChar.ToString(), out sum))
            {
                // lastChar is numeric, so let's compare it to remainder
                result = (remainder == int.Parse(lastChar.ToString()));
            }

            return result;
        }

        private static bool IsValidIsbn13(string isbn13)
        {
            var result = false;

            if (!string.IsNullOrEmpty(isbn13))
            {
                if (isbn13.Contains("-")) isbn13 = isbn13.Replace("-", "");

                long temp;
                if (isbn13.Length != 13 || !long.TryParse(isbn13, out temp)) return false;

                var sum = 0;
                for (int i = 0; i < 12; i++)
                {
                    sum += int.Parse(isbn13[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                }

                var remainder = sum % 10;
                var checkDigit = 10 - remainder;
                if (checkDigit == 10) checkDigit = 0;

                result = (checkDigit == int.Parse(isbn13[12].ToString()));
            }

            return result;
        }
    }
}