using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.Entities;

namespace Team3.Models
{
    public class DepartmentDBService
    {
        private static DepartmentDBService? _instance;
        private readonly Config _config;

        private DepartmentDBService()
        {
            _config = Config.Instance;
        }

        public static DepartmentDBService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DepartmentDBService();
                }
                return _instance;
            }
        }

        public List<Department> GetDepartments()
        {
            const string query = "SELECT * FROM departments;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.CONNECTION))
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
