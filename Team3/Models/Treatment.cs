using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public int MedicalRecordId { get; set; }

        public Treatment(int id, int medicalRecordId)
        {
            this.Id = id;
            this.MedicalRecordId = medicalRecordId;
        }

        override
        public string ToString()
        {
            return $"Id: {Id}, MedicalRecordId: {MedicalRecordId}";

        }
    }
}
