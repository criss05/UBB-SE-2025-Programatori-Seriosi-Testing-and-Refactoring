using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IAppointmentModelView
    {
        /// <summary>
        /// add an appointment
        /// </summary>
        /// <param name="appointment"></param>
        public void AddNewAppointment(Appointment appointment);

        /// <summary>
        /// get an appointment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Appointment GetAppointmentById(int id);
    }
}
