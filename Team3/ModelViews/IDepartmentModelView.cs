using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IDepartmentModelView
    {
        /// <summary>
        /// Loads detailed department information.
        /// </summary>
        public void LoadDepartmentsInfo();


        /// <summary>
        /// Handles the date selection in the ComboBox.
        /// </summary>
        /// <param name="selectedDate"></param>
        public void DateSelectedComboBoxHandler(DateOnly selectedDate);

        /// <summary>
        /// Gets a list of departments by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentsByName(string name);

        /// <summary>
        /// Handles the back button navigation.
        /// </summary>
        public void BackButtonHandler();
    }
}
