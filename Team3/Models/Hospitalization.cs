using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Models
{
    public class Hospitalization
    {


        public int Id { get; set; }

        public int RoomId { get; set; }

        public int PatientId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }


        public Hospitalization(int id, int roomId, int patientId, DateTime startDateTime, DateTime endDateTime)
        {
            Id = id;
            RoomId = roomId;
            PatientId = patientId;
            StartDateTime = endDateTime;
            EndDateTime = endDateTime;
        }

    }
}
