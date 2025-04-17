using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.Service.Interfaces
{
    /// <summary>
    /// Interface for TreatmentService.
    /// </summary>
    public interface ITreatmentService
    {
        /// <summary>
        /// Get the treatment by medical record id.
        /// </summary>
        /// <param name="treatmentId">The treatment id.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int treatmentId);
    }
}
