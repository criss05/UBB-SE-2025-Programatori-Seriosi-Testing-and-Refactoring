using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.DatabaseServices;

namespace Team3.ModelViews
{
    class AppointmentModelView : IAppointmentModelView
    {

        private readonly IAppointmentDatabaseService appointmentModel;

        public AppointmentModelView()
        {
            this.appointmentModel = (IAppointmentDatabaseService?)AppointmentDatabaseService.Instance;
        }
        /// <summary>
        /// hello
        /// </summary>
        /// <param name="appointment"></param>
        public void AddNewAppointment(Appointment appointment)
        {
            this.appointmentModel.AddNewAppointment(appointment);
        }


        public Appointment GetAppointmentById(int id)
        {
            return this.appointmentModel.GetAppointmentById(id);
        }
    }
}
