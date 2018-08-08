using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        MySqlConnection connection = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        String connnectStr = "server=127.0.0.1;port=3306;user=root;password=12345678; database=network;SslMode = none;";
        String sql = null;
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
                try
                {
                    sql = "select user_name from useraccount where user_name='" + userName+"'";
                    String sqlInsert = "insert useraccount values(null," + "'" + userName + "','" + userName + "','" + password + "')";
                    connection = new MySqlConnection(connnectStr);
                    connection.Open();
                    command = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("该用户名已被使用，请重新输入！");
                    }
                    else
                    {
                        connection.Close();
                        connection.Open();
                        command = new MySqlCommand(sqlInsert, connection);
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("注册成功！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
