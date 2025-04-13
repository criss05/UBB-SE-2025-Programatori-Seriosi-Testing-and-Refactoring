// <copyright file="IMedicalRecordModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///     This interface defines the contract for a medical record model view.
    /// </summary>
    public interface IMedicalRecordModelView
    {
        /// <summary>
        /// Get medical record by ID.
        /// </summary>
        /// <param name="id">The id of the medical repot.</param>
        /// <returns>The medical report.</returns>
        public MedicalRecord GetMedicalRecordById(int id);
    }
}
