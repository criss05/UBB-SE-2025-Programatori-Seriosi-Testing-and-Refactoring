// <copyright file="IDepartmentModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for the Department Model View.
    /// </summary>
    public interface IDepartmentModelView
    {
        /// <summary>
        /// Loads detailed department information.
        /// </summary>
        public void LoadDepartmentsInfo();

        /// <summary>
        /// Handles the date selection in the ComboBox.
        /// </summary>
        /// <param name="selectedDate">The selected date.</param>
        public void DateSelectedComboBoxHandler(DateOnly selectedDate);

        /// <summary>
        /// Gets a list of departments by name.
        /// </summary>
        /// <param name="name">The name of the department.</param>
        /// <returns>The departments with the given name.</returns>
        public List<Department> GetDepartmentsByName(string name);

        /// <summary>
        /// Handles the back button navigation.
        /// </summary>
        public void BackButtonHandler();
    }
}
