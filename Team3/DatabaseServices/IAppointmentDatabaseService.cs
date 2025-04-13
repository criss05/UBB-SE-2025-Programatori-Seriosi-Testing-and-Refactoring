using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public interface IAppointmentDatabaseService
    {
        /// <summary>
        /// Add an appointment to the database
        /// </summary>
        /// <param name="appointment"></param>
        public void AddNewAppointment(Appointment appointment);

        /// <summary>
        /// Get an appointment from the database based to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Appointment GetAppointmentById(int id);
    }
}
