using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BloodBankSystem
{
    class LoginModel
    {
       private static string userName;
        public static bool checkLoginUser(string username,string password)
        {
            userName = username;

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT *FROM users WHERE username=@user AND password=@pass";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user",username);
                cmd.Parameters.AddWithValue("@pass", password);
                MySqlDataReader reader =cmd.ExecuteReader();
                return reader.HasRows ;
            }
        }

        public static bool addUsers(string username, string phone, string password)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO users (username,phone_number ,password) VALUES (@user,@phone,@pass) ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@pass", password);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static DataTable GetUsers()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT id,username,phone_number FROM users";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable SearchUser(string keyword)
        {
            DataTable dt = new DataTable();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE username LIKE @keyword OR phone_number LIKE @keyword";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public static string GetUsername()
        {
            return userName;
        }
    }
}
