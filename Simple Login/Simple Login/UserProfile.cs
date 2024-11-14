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
    public partial class UserProfile : Form
    {
        User user = null;
        public UserProfile(User user)
        {
            InitializeComponent();
            this.user = user;
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

        private void UserProfile_Load(object sender, EventArgs e)
        {
            lblFirstname.Text = user.Firstname;
            lblLastname.Text = user.Lastname;
            lblAge.Text = user.GetAge().ToString();
        }

        private void btnUserLogout_Click(object sender, EventArgs e)
        {
            Login loginform = new Login(user);
            this.Hide();
            loginform.Show();
        }
    }
}
