using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
   public class DepartmentDatabaseService : IDepartmentDatabaseService
    {
        private static DepartmentDatabaseService? _instance;
        private readonly Config _config;

        private DepartmentDatabaseService()
        {
            _config = Config.Instance;
        }

        public static DepartmentDatabaseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DepartmentDatabaseService();
                }
                return _instance;
            }
        }

        public List<Department> GetDepartments()
        {
            const string query = "SELECT * FROM departments;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    List<Department> departments = new List<Department>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department(
                                reader.GetInt32(0),
                                reader.GetString(1)
                            ));
                        }
                    }
                    return departments;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error getting departments", e);
            }
        }
    }
}
