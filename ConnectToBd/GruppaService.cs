using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gruppa.Models;

namespace ConnectToBd
{
        public class GruppaService
    {
        private readonly string _connectionString;

        public GruppaService()
        {
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\АйткожаЖ.CORP\source\repos\Gruppa\ConnectToBd\Database1.mdf;Integrated Security=True";
        }

        public List<Gruppa> GetAll()
        {
            var data = new List<Gruppa>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = "select * from Gruppa";

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string name = dataReader["Name"].ToString();                        

                        data.Add(new Gruppa
                        {
                            Id = id,
                            Name = name                           
                        });
                    }
                    dataReader.Close();
                }
                catch (SqlException exception)
                {
                    //TODO обработка
                    throw;
                }
                catch (Exception exception)
                {
                    //TODO обработка
                    throw;
                }
            }
            return data;
        }

        public void Add(Gruppa gruppa)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = $"insert into Users values('{gruppa.Name}')";
                    var affectedRows = command.ExecuteNonQuery();

                    if (affectedRows < 1) throw new Exception("Вставка не удалась");
                }
                catch (SqlException exception)
                {
                    //TODO обработка
                    throw;
                }
                catch (Exception exception)
                {
                    //TODO обработка
                    throw;
                }
            }
        }

        public void DeleteById(int id)
        {

        }

        public void Update (Gruppa gruppa)
        {

        }
    }
}
