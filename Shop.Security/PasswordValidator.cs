using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Shop.Security
{
    internal class PasswordValidator
    {
        private enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        private static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;
            if (password.Length >= 10)
                score++;
            if (password.Length >= 14)
                score++;
            if (Regex.Match(password, @"\d", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success &&
                Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @".[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }

        public string CheckIfPasswordIsStrongEnough(string password)
        {
            PasswordScore passwordStrengthScore = CheckStrength(password);

            switch (passwordStrengthScore)
            {
                case PasswordScore.Blank:
                case PasswordScore.VeryWeak:
                case PasswordScore.Weak:
                case PasswordScore.Medium:
                    throw new Exception("Hasło jest za słabe!");

                case PasswordScore.Strong:
                case PasswordScore.VeryStrong:
                    return password;

                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public string EncryptPassword(string password)
        {
            return string.Empty;
        }

        public string ValidatePassword(string password, string passwordBeingChecked)
        {
            return string.Empty;
        }

        public (byte[] salt, string password) CreateSaltAndPassword(string password)
        {
            byte[] salt; new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string encryptedPassword = Convert.ToBase64String(hashBytes);
            
            return (salt, encryptedPassword);
        }
    }
}

