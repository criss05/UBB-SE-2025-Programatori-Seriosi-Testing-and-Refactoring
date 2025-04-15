namespace Team3.DatabaseServices.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Provides database operations for appointments.
    /// </summary>
    public class AppointmentDatabaseService : IAppointmentDatabaseService
    {
        private readonly string dbConnString;

        public AppointmentDatabaseService(string _dbConnString)
        {
            dbConnString = _dbConnString;
        }

        public void AddNewAppointment(Appointment appointment)
        {
            const string query = "INSERT INTO appointments (doctor_id, patient_id, appointment_datetime, location) " +
                                 "VALUES (@doctor_id, @patient_id, @appointment_datetime, @location)";
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DbConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        public Appointment GetAppointmentById(int id)
        {
            const string query = "SELECT id, doctor_id, patient_id, appointment_datetime, location FROM Appointments WHERE id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DbConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                                throw new Exception("Appointment not found");

                            return new Appointment(
                                (int)reader[1],
                                (int)reader[2],
                                (DateTime)reader[3],
                                reader[4].ToString());
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error retrieving appointment", exception);
            }
        }
    }
}
