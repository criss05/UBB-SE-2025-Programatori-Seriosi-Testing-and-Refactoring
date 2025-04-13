// <copyright file="AppointmentDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.Models;

    /// <summary>
    /// this class takes data from the database.
    /// </summary>
    public class AppointmentDatabaseService : IAppointmentDatabaseService
    {
        private static readonly object LockObject = new object();
        private static AppointmentDatabaseService? instance;
        private readonly Config config;

        private AppointmentDatabaseService()
        {
            this.config = Config.Instance;
        }

        /// <summary>
        /// Gets singleton instance of the AppointmentDatabaseService class.
        /// </summary>
        public static AppointmentDatabaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (LockObject)
                    {
                        if (instance == null)
                        {
                            instance = new AppointmentDatabaseService();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Adds a new appointment to the database.
        /// </summary>
        /// <param name="appointment">The appointment object containing details to be added.</param>
        /// <exception cref="Exception">Thrown when an error occurs while adding the appointment.</exception>
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

        /// <summary>
        /// Retrieves an appointment from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the appointment to retrieve.</param>
        /// <returns>The appointment object corresponding to the specified ID.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving the appointment or if the appointment is not found.</exception>        [Obsolete]
        public Appointment GetAppointmentById(int id)
        {
            const string query = "SELECT id, doctor_id, patient_id, appointment_datetime, location FROM Appointments WHERE id = @id";
            try
            {
                using (
                   SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            return new Appointment(
                                (int)reader[0],
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
