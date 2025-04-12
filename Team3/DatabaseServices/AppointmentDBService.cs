using System;
using System.Data.SqlClient;
using Team3.Entities;

namespace Team3.Models
{
    public class AppointmentDBService
    {
        private static AppointmentDBService? _instance;
        private static readonly object _lock = new object();
        private readonly Config _config;

        private AppointmentDBService() {
            _config = Config.Instance;
        }

        public static AppointmentDBService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppointmentDBService();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddAppointment(Appointment appointment)
        {
            const string query = "INSERT INTO appointments (id, doctor_id, patient_id, appointment_datetime, location) " +
                                 "VALUES (@id, @doctor_id, @patient_id, @appointment_datetime, @location)";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.CONNECTION))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", appointment.Id);
                        command.Parameters.AddWithValue("@doctor_id", appointment.DoctorId);
                        command.Parameters.AddWithValue("@patient_id", appointment.PatientId);
                        command.Parameters.AddWithValue("@appointment_datetime", appointment.AppointmentDateTime);
                        command.Parameters.AddWithValue("@location", appointment.Location);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding appointment", e);
            }
        }

        public Appointment GetAppointment(int id)
        {
            const string query = "SELECT id, doctor_id, patient_id, appointment_datetime, location FROM Appointments WHERE id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.CONNECTION))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            return new Appointment((int)reader[0], 
                                (int)reader[1],
                                (int)reader[2],
                                (DateTime)reader[3], 
                                reader[4].ToString());
  
                        }
                    }
                }

                throw new Exception("Appointment not found");
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving appointment", e);
            }
        }
    }
}
