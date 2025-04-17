// <copyright file="TreatmentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Repository.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Service class for handling treatment operations.
    /// </summary>
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository treatmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentService"/> class.
        /// </summary>
        /// <param name="treatmentRepository">The database service for treatment operations.</param>
        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            this.treatmentRepository = treatmentRepository;
        }

        /// <summary>
        /// Get the treatment by medical record id.
        /// </summary>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int treatmentId)
        {
            return this.treatmentRepository.GetTreatmentByMedicalRecordId(treatmentId);
        }
    }
}
