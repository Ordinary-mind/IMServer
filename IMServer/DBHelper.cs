using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IMClient
{
    class DBHelper
    {
        static String connnectStr = "server=127.0.0.1;port=3306;user=root;password=lqn.091023; database=network;SslMode = none;";

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

        public static List<T> QueryToList<T>(string sql,params MySqlParameter[] parameters) where T:new()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connnectStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    DataSet dt = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    cmd.Parameters.AddRange(parameters);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                    conn.Close();
                    DataTable table = dt.Tables[0];
                    List<T> entities = new List<T>();

                    foreach (DataRow row in table.Rows)
                    {
                        T entity = new T();
                        foreach (var item in entity.GetType().GetProperties())
                        {
                            if (row.Table.Columns.Contains(item.Name))
                            {
                                if (DBNull.Value != row[item.Name])
                                {
                                    item.SetValue(entity,ChangeType(row[item.Name], item.PropertyType), null);
                                }
                            }
                        }
                        entities.Add(entity);
                    }
                    return entities;
                }
            }catch(Exception e)
            {

            }
            return null;
        }

        private static object ChangeType(object value, Type conversionType)
        {
            // Note: This if block was taken from Convert.ChangeType as is, and is needed here since we're
            // checking properties on conversionType below.
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            } // end if

            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType

            if (conversionType.IsGenericType &&
              conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                } // end if

                // It's a nullable type, and not null, so that means it can be converted to its underlying type,
                // so overwrite the passed-in conversion type with this underlying type
                System.ComponentModel.NullableConverter nullableConverter = new System.ComponentModel.NullableConverter(conversionType);

                conversionType = nullableConverter.UnderlyingType;
            } // end if

            // Now that we've guaranteed conversionType is something Convert.ChangeType can handle (i.e. not a
            // nullable type), pass the call on to Convert.ChangeType
            return Convert.ChangeType(value, conversionType);
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
