// <copyright file="AppointmentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Provides database operations for appointments.
    /// </summary>
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the database.</param>
        public AppointmentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Add a new appointment.
        /// </summary>
        /// <param name="appointment">The appointment to be added.</param>
        /// <exception cref="Exception">Throw error if failed.</exception>
        public void AddNewAppointment(Appointment appointment)
        {
            const string query = "INSERT INTO appointments (doctor_id, patient_id, appointment_datetime, location) " +
                                 "VALUES (@doctor_id, @patient_id, @appointment_datetime, @location)";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
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
            catch (Exception exception)
            {
                throw new Exception("Error adding appointment", exception);
            }
        }

        /// <summary>
        /// Get an appointment by ID.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        /// <returns>The appointment with the given id.</returns>
        /// <exception cref="Exception">Throw error if failed.</exception>
        public Appointment GetAppointmentById(int appointmentId)
        {
            const string query = "SELECT id, doctor_id, patient_id, appointment_datetime, location FROM Appointments WHERE id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", appointmentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new Exception("Appointment not found");
                            }

                            return new Appointment(
                                (int)reader[0],
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
