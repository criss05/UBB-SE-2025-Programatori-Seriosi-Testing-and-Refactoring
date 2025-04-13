// <copyright file="TreatmentModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Model view for Treatment.
    /// </summary>
    public class TreatmentModelView : ITreatmentModelView
    {
        private readonly ITreatmentDatabaseService treatmentModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentModelView"/> class.
        /// </summary>
        public TreatmentModelView()
        {
            this.treatmentModel = TreatmentDatabaseService.Instance;
        }

        /// <summary>
        /// Get the treatment by medical record id.
        /// </summary>
        /// <param name="treatemtnId">The id of the treatment.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int treatemtnId)
        {
            return this.treatmentModel.GetTreatmentByMedicalRecordId(treatemtnId);
        }
    }
}
