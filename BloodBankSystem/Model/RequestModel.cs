using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BloodBankSystem
{
    class RequestModel
    {
        public static bool AddRequest(string name, string age, string bloodType,string quantityBlood, DateTime dateTime, string phone)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO request (patient_name,patient_age ,blood_type,quantity_blood,request_date,patient_phone) VALUES (@name ,@age,@bloodType,@quantityBlood,@dateTime ,@phone) ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@bloodType", bloodType);
                cmd.Parameters.AddWithValue("@quantityBlood", quantityBlood);
                cmd.Parameters.AddWithValue("@dateTime", dateTime);
                cmd.Parameters.AddWithValue("@phone", phone);
                return cmd.ExecuteNonQuery() > 0;

            }
        }
        public static DataTable GetRequest()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT *FROM request";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable SearchRequest(string keyword)
        {
            DataTable dt = new DataTable();
            using(MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM request WHERE patient_name LIKE @keyword OR blood_type LIKE @keyword";
                using(MySqlCommand cmd =new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword","%"+keyword+"%");
                    using(MySqlDataAdapter adapter =new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
