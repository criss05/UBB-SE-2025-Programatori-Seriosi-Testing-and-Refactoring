using Microsoft.UI.Xaml.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DBServices;
using Team3.Models;


namespace Team3.DBServices
{
    public class DrugDBService : IDrugDBService
    {
        private static DrugDBService? _instance;
        private static readonly object _lock = new object();
        private readonly Config _config;

        private DrugDBService()
        {
            _config = Config.Instance;
        }

        public static DrugDBService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DrugDBService();
                    }
                }
                return _instance;
            }   
        }

        public Drug getDrug(int Id)
        {
            const string query = "SELECT * FROM drugs WHERE id = @id;";

            try
            {
                SqlConnection connection = new SqlConnection(Config.CONNECTION);


                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@id", Id);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Drug(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
       
            }
            catch (Exception e)
            {
                throw new Exception("Error getting drug", e);
            }

        }
    }
}
