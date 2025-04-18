// <copyright file="DrugModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using Team3.Repository.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Services.Interfaces;

    /// <summary>
    /// DrugModelView is a class that implements the IDrugModelView interface.
    /// </summary>
    public class DrugModelView : IDrugModelView
    {
        private readonly IDrugService drugService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugModelView"/> class.
        /// Constructor for DrugModelView.
        /// </summary>
        /// <param name="_drugService">The database connection string.</param>
        public DrugModelView(IDrugService _drugService)
        {
            this.drugService = _drugService;
        }

        /// <summary>
        /// Get the drug information by DrugId.
        /// </summary>
        /// <param name="drugId">The id of the drug.</param>
        /// <returns>The drug.</returns>
        public Drug GetDrugById(int drugId)
        {
            return this.drugService.GetDrugById(drugId);
        }
    }
}
