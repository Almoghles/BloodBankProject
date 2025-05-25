using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BloodBankSystem
{
    class DonorModel
    {
        public static bool AddDonor(string name, string age, string bloodType,string quantityBlood , DateTime dateTime, string phone)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO donors (name,age ,blood_type,quantity_blood,donation_date,phone) VALUES (@name ,@age,@bloodType,@quantityBlood,@dateTime ,@phone) ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@bloodType",bloodType );
                cmd.Parameters.AddWithValue("@quantityBlood",quantityBlood);
                cmd.Parameters.AddWithValue("@dateTime", dateTime );
                cmd.Parameters.AddWithValue("@phone", phone);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static DataTable GetDonor()
        {
            using(var conn= Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT *FROM donors";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable SearchDonor(string keyword)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM donors WHERE name LIKE @keyword OR blood_type LIKE @keyword";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword","%"+keyword+"%");
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static bool updateDonor(string id, string name, string age, string bloodtype, string quantity, DateTime date, string phone)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string quary = "UPDATE donors SET name=@name , age=@age, blood_type=@bloodtype, quantity_blood=@quantity,donation_date=@date,phone=@phone WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand(quary, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@bloodtype", bloodtype);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@id",id);


               return cmd.ExecuteNonQuery() >0;
            }
        }

        
    }
}
