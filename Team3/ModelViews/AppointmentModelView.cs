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

        private readonly AppointmentDBService appointmentModel;

        public AppointmentModelView()
        {
            this.appointmentModel = AppointmentDBService.Instance;
        }


        public void AddAppointment(Appointment appointment)
        {
            this.appointmentModel.AddAppointment(appointment);
        }


        public Appointment GetAppointment(int id)
        {
            return this.appointmentModel.GetAppointment(id);
        }
    }
}
