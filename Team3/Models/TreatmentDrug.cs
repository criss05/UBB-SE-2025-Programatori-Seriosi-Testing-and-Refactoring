using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Models
{
    public class TreatmentDrug
    {
        public int Id { get; set; }
        public int TreatmentId { get; set; }
        public int DrugId {  get; set; }
        public double Quantity {  get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DateOnly StartDate { get; set; }
        public int NrDays {  get; set; }

        public TreatmentDrug(int id,int treatmentId,int drugId, double quantity, TimeOnly startTime, TimeOnly endTime, DateOnly startDate, int nrDays)
        {
            this.Id = id;
            this.TreatmentId=treatmentId;
            this.DrugId = drugId;
            this.Quantity = quantity;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.StartDate = startDate;
            this.NrDays = nrDays;
        }


        override
        public string ToString()
        {
            return $"Id: {Id}, TreatmentId:{TreatmentId}, DrugId: {DrugId}, Quantity: {Quantity}, StartTime: {StartTime},EndTime: {EndTime}, StartDate: {StartDate}, Days: {NrDays}";
        }
    }
}
