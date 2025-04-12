using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Entities;
using Team3.Models;

namespace Team3.ModelViews
{
    class AppointmentModelView
    {
        private readonly AppointmentDatabaseService appointmentModel;
        public AppointmentModelView()
        {
            this.appointmentModel = AppointmentDatabaseService.Instance;
        }
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
