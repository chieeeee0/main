using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Login
{
    public partial class Registration : Form
    {
        User user = new User();
        public Registration()
        {
            InitializeComponent();
        }

        public Registration(User user)
        {
            this.user = user;
        }
        


        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.OrangeRed;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.White;
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Aquamarine;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.White;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.RoyalBlue;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.White;
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            User userForm = new User();
            userForm.Username = txtRegisterUsername.Text;
            userForm.Firstname = txtRegisterFirstname.Text;
            userForm.Lastname = txtRegisterLastname.Text;
            userForm.PinCode = txtPinCode.Text;
            userForm.Email = txtRegisterEmailAddress.Text;
            userForm.Birthdate = dtpBirthdate.Value;

            
            
            user.SetDefault(userForm, txtRegisterUsername.Text , txtRegisterPassword.Text);

            if (!txtRegisterEmailAddress.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Please enter a valid Gmail address", "Error");
            }
            else
            {
                if (txtRegisterPassword.Text != txtRegisterConfirmPassword.Text)
                {
                    MessageBox.Show("Password do not match", "Error");
                }
                else
                {
                    Login login = new Login(user);
                    login.Show();
                    this.Hide();
                }
                Console.WriteLine(user.PasswordHash);
                Console.WriteLine(user.PasswordSalt);
            }  
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            user.Birthdate = dtpBirthdate.Value;
         

            txtRegisterPassword.MaxLength = 12;
            txtRegisterConfirmPassword.MaxLength = 12;
            txtPinCode.MaxLength = 4;          
        }
    }
}
