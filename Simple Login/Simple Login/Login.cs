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
    public partial class Login : Form
    {
        User user = null;
        public Login(User user)
        {
            InitializeComponent();
            this.user = user;   
        }

        private void Login_Load(object sender, EventArgs e)
        {
    
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (user.LoginMethodUsername(txtLoginUsername.Text))
            {
                if (user.VerifyPasswordHash(txtLoginPassword.Text, user.PasswordHash, user.PasswordSalt))
                {
                    DialogResult dialog = MessageBox.Show("Login Successful");
                    if (dialog == DialogResult.OK)
                    {
                        UserProfile userPage = new UserProfile(user);
                        userPage.Show();
                        this.Hide();
                    }
                }
            }
           
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.RoyalBlue;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassPage = new ForgotPassword(user);
            this.Hide();
            forgotPassPage.Show();
        }
    }
}
