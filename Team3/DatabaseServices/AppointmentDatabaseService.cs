﻿using System;
using System.Data.SqlClient;
using Team3.Models;
//refactored the function names and also the database connection if it says connection you dont know it connects to what so changed it into DATABASE_CONNECTION_STRING


namespace Team3.DatabaseServices
{
    public class AppointmentDatabaseService :IAppointmentDBService
    {
        private static AppointmentDatabaseService? _instance;
        private static readonly object _lock = new object();
        private readonly Config _config;

        private AppointmentDatabaseService() {
            _config = Config.Instance;
        }

        public static AppointmentDatabaseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppointmentDatabaseService();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddNewAppointment(Appointment appointment)
        {
            const string query = "INSERT INTO appointments (id, doctor_id, patient_id, appointment_datetime, location) " +
                                 "VALUES (@id, @doctor_id, @patient_id, @appointment_datetime, @location)";
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
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
        public Appointment GetAppointmentById(int id)
        {
            const string query = "SELECT id, doctor_id, patient_id, appointment_datetime, location FROM Appointments WHERE id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
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
            catch (Exception exception)
            {
                throw new Exception("Error retrieving appointment", exception);
            }
        }
    }
}
