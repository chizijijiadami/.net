using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using MyWebApp.Model;
namespace MyWebApp.SqlRepository
{
    public class UserRepository
    {
        public static List<User> GetUsers()
        {
            String connetStr = ConfigurationManager.ConnectionStrings["mysqldb"].ToString();
            String sql = "select * from link;";
            List<User> UserLists = new List<User>();

            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User UserList = new User();
                    UserList.ID = Convert.ToInt32(reader["id"]);
                    UserList.Name = reader["name"].ToString();
                    UserList.Age = Convert.ToInt32(reader["age"]);
                    UserLists.Add(UserList);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return UserLists;
        }
    }
}
