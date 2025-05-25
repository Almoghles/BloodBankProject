using MySql.Data.MySqlClient;


namespace BloodBankSystem
{
    class Database
    {
        private static string connectionString = "Server=127.0.0.1;Port=3306;Database=blood_bank;Uid=root;Password=;";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
}
    }
