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
    public partial class ForgotPassword : Form
    {
        User user = null;
        public ForgotPassword(User user)
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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!txtFPEmail.Text.EndsWith("@gmail.com" ) || txtFPEmail.Text != user.Email)
            {
                MessageBox.Show("Please enter a valid Gmail address", "Error");

            }
           
            else
            {
                if (user.ForgotPasswordMethod(txtFPEmail.Text, txtFPPincode.Text))
                {
                    ChangePassword changePasswordForm = new ChangePassword(user);
                    this.Hide();
                    changePasswordForm.Show();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login loginPage = new Login(user);
            this.Hide();
            loginPage.Show();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            txtFPPincode.MaxLength = 4;
        }
    }
}
