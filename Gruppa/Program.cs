using System;
using System.Data.SqlClient;
using System.Data;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                AttachDbFilename=C:\Users\АйткожаЖ.CORP\source\repos\Gruppa\Gruppa\Database1.mdf;
                                 Integrated Security=True";
            
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Ошибка подключения:{0}", se.Message);
                return;
            }

            Console.WriteLine("Соедение успешно произведено");

            SqlCommand cmdCreateTable = new SqlCommand("CREATE TABLE " +
            "Gruppa (Id int not null" +
            ", Name char(60) not null,)", connection);
            try
            {
                cmdCreateTable.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Ошибка при создании таблицы");
                return;
            }

            Console.WriteLine("Таблица создана успешно");

            connection.Close();
            connection.Dispose();
        }

    }
}