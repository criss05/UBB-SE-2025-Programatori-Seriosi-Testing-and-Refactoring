// <copyright file="User.cs" company="PlaceholderCompany">
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
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <param name="name">The name of the user.</param>
        /// <param name="role">The role of the user.</param>
        public User(int id, string name, string role)
        {
            this.Id = id;
            this.Name = name;
            this.Role = role;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Returns a string representation of the user.
        /// </summary>
        /// <returns>string representation of the user.</returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}, Role: {this.Role}";
        }
    }
}
