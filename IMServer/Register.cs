using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IMServer
{
    public partial class Register : Form
    {
        Login main;
        MySqlConnection connection;
        public Register()
        {

        }
        public Register(Login login)
        {
            main = login;
            InitializeComponent();
        }

        private void btnLoginIn_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String userName = this.tbUserName.Text;
            String password = this.tbPassword.Text;
            String rePassword = this.tbRePassword.Text;
            if (!password.Equals(rePassword))
            {
                MessageBox.Show("两次输入密码不一致");
            }
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(rePassword))
            {
                MessageBox.Show("填写信息不完整！");
            }
            else
            {

            }
        }
    }
}
