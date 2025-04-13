// <copyright file="Drug.cs" company="PlaceholderCompany">
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
    /// Represents a drug with its properties.
    /// </summary>
    public class Drug
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Drug"/> class.
        /// </summary>
        /// <param name="id">The id of the drug.</param>
        /// <param name="name">The name of the drug.</param>
        /// <param name="administration">The way o administration.</param>
        public Drug(int id, string name, string administration)
        {
            this.Id = id;
            this.Name = name;
            this.Administration = administration;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the drug.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the drug.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the administration method of the drug.
        /// </summary>
        public string Administration { get; set; }

        /// <summary>
        /// Returns a string representation of the drug.
        /// </summary>
        /// <returns>string representation of the drug.</returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}, Administration: {this.Administration}";
        }
    }
}
