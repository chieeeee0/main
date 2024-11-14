using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Login
{
    public class User : PersonalInformation
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PinCode { get; set; }
        public string PasswordHash { get; set; }    
        public string PasswordSalt { get; set; }

        public User()
        {
            

        }
        public User(User user)
        {
            this.Email = user.Email;
            this.Username = user.Username;
            byte[] passwordHash, passwordSalt;
            this.PasswordHash = user.PasswordHash;
            this.PasswordSalt = user.PasswordSalt;
           
            this.PinCode = user.PinCode;
        }

        public void SetDefault(User user, string username, string password)
        {
            Email = user.Email;
            Username = username;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            

            byte[] passwordHash, salt;
            CreatePasswordHash(password, out passwordHash, out salt);
            SetPasswords(passwordHash, salt);

        }

        
        public bool LoginMethodUsername(string enteredUsername)
        {


            if (enteredUsername != Username)
            {
                MessageBox.Show("Incorrect username");
                return false;
            }
               return true;
        }

        public bool ForgotPasswordMethod(string inputEmail, string inputPincode)
        {
            if (Email != inputEmail && PinCode != inputPincode)
            {
                return false;
            }
            return true;
        }

        public bool ChangePasswordMethod(string newPassword)
        {
            
            byte[] newPasswordHash, newSalt;
            CreatePasswordHash(newPassword, out newPasswordHash, out newSalt);

            
            SetPasswords(newPasswordHash, newSalt);

            
            return true;
        }


        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);
            byte[] hash = Convert.FromBase64String(storedHash);

            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != hash[i])
                    {
                        MessageBox.Show("Incorrect password");
                        return false; 
                    }
                }
            }
            return true; 
        }
        public void SetPasswords(byte[] passwordHash, byte[] salt)
        {
            PasswordHash = Convert.ToBase64String(passwordHash);
            PasswordSalt = Convert.ToBase64String(salt);
        }

    }
}
