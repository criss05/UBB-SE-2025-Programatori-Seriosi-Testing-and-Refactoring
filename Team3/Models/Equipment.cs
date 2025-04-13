// <copyright file="Equipment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an equipment item.
    /// </summary>
    public class Equipment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="equipmentId">The id of the equipment.</param>
        public Equipment(int equipmentId)
        {
            this.EquipmentId = equipmentId;
        }

        /// <summary>
        /// Gets or sets the equipment ID.
        /// </summary>
        public int EquipmentId { get; set; }
    }
}
