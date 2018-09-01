using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace IMClient
{
    class DBHelper
    {
        static String connnectStr = "server=127.0.0.1;port=3306;user=root;password=12345678; database=network;SslMode = none;";

        public static DataTable QueryData(string sqlStr, params MySqlParameter[] parameter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connnectStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
                    DataSet dt = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    cmd.Parameters.AddRange(parameter);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                    conn.Close();
                    return dt.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("查询数据异常" + ex.Message);
            }
        }

        public static bool UpdateData(string sqlStr, params MySqlParameter[] parameter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connnectStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
                    cmd.Parameters.AddRange(parameter);
                    var row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("更新数据异常" + ex.Message);
            }
        }

        public static bool DeleteData(string sqlStr, params MySqlParameter[] parameter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connnectStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
                    cmd.Parameters.AddRange(parameter);
                    var row = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("删除数据异常" + ex.Message);
            }
        }

        public static bool AddData(string sqlStr, params MySqlParameter[] parameter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connnectStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
                    cmd.Parameters.AddRange(parameter);
                    var row = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("添加数据异常" + ex.Message);
            }
        }
    }
}
