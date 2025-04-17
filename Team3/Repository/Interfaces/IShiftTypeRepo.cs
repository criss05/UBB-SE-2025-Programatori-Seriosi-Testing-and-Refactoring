// <copyright file="IShiftTypeRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for ShiftType repository.
    /// </summary>
    public interface IShiftTypeRepo
    {
        /// <summary>
        /// get all shift types.
        /// </summary>
        /// <returns>The list of all shift types.</returns>
        public List<ShiftType> GetAllShiftTypes();

        /// <summary>
        /// get the shift by it's type.
        /// </summary>
        /// <param name="shiftTypeId">The shift type id.</param>
        /// <returns>The shift type with the given id.</returns>
        public ShiftType? GetShiftType(int shiftTypeId);
    }
}
