namespace Team3.ModelViews.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Provides methods for managing and retrieving department information.
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// Gets a list of departments by name.
        /// </summary>
        /// <param name="name">The name (or partial name) of the department.</param>
        /// <returns>A list of departments matching the given name.</returns>
        List<Department> GetDepartmentsByName(string name);

        /// <summary>
        /// Retrieves the complete list of departments from the repository.
        /// </summary>
        /// <returns>A list of all departments.</returns>
        List<Department> GetDepartments();
    }
}
