using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Shop.Users
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string Email { get; private set; }
        public string Password { get; private set; }
        private byte[] Salt { get; set; }
        public bool IsValid { get; set; }
        public virtual IList<IRole> Roles { get; set; } = new List<IRole>();

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetPassword(string password)
        {
            PasswordValidator pv = new PasswordValidator();
            var values = pv.CreateSaltAndPassword(password);
            Salt = values.Item1;
            Password = values.Item2;
        }

        public void SetEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                Email = email;
            }
            catch (FormatException)
            {
                throw new Exception("This email is not valid.");
            }
        }
       
        public void AddRole(IRole role)
        {
            Roles.Add(role);
        }

        public void RemoveRole(IRole role)
        {
            Roles.Remove(role);
        }

        public bool HasRole(IRole role)
        {
            return Roles.Contains(role);
        }
    }
}

