using MySql.Data.MySqlClient;
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
        MySqlConnection connection = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        String connnectStr = "server=127.0.0.1;port=3306;user=root;password=lqn.091023; database=network;SslMode = none;";
        String sql = null;
        UserAccount account = null;
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
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("请填写有效的用户名和密码！");
            }
            else
            {
                try
                {
                    sql = "select * from useraccount where user_name='" + userName + "' and password='"+password+"'";
                    Console.WriteLine(sql);
                    connection = new MySqlConnection(connnectStr);
                    connection.Open();
                    command = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        account = new UserAccount();
                        account.UserId = reader.GetInt32("user_id");
                        account.NickName = reader.GetString("nick_name");
                        connection.Close();
                        this.Hide();
                        Form1 form1 = new Form1(account);
                        form1.Show();
                    }
                    else
                    {
                        connection.Close();
                        MessageBox.Show("用户名或密码错误！");
                    }
                    }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                }
            }
        }
    }
