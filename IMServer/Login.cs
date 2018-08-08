using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMServer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register(this);
            this.Hide();
            register.Show();
        }

        private void btnLoginIn_Click(object sender, EventArgs e)
        {
            String userName = this.tbUserName.Text;
            String password = this.tbPassword.Text;
        }
    }
}
