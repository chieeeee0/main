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
    public partial class ChangePassword : Form
    {
        User user = null;
        public ChangePassword(User user)
        {
            this.user = user;
            InitializeComponent();
           
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

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnEnterChangepass_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmNewPassword.Text;

            
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.");
                return;
            }

            
            bool passwordChanged = user.ChangePasswordMethod(newPassword);

            if (passwordChanged)
            {
                DialogResult dialog = MessageBox.Show("Password changed successfully.", "Info");
                if (dialog == DialogResult.OK)
                {
                    Login loginform = new Login(user);
                    this.Hide();
                    loginform.Show();
                }
               
            }
        }
    }
}
