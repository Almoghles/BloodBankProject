using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BloodBankSystem
{
    class HomeModel
    {
        public static int GetDonorCount()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM donors";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int GetRequestCount()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM request";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static DataTable GetBloodStock()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT d.blood_type,IFNULL(SUM(d.quantity_blood),0)-IFNULL(r.requested,0) AS stock FROM donors d LEFT JOIN(SELECT blood_type,SUM(quantity_blood) AS requested FROM request GROUP BY blood_type) r ON d.blood_type=r.blood_type GROUP BY d.blood_type";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static int GetActualBloodStock()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT SUM(quantity_blood)-(SELECT SUM(quantity_blood) FROM request) FROM donors";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
