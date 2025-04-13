// <copyright file="DrugModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// DrugModelView is a class that implements the IDrugModelView interface.
    /// </summary>
    public class DrugModelView : IDrugModelView
    {
        private readonly IDrugDatabaseService drugModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugModelView"/> class.
        /// Constructor for DrugModelView.
        /// </summary>
        public DrugModelView()
        {
            this.drugModel = DrugDatabaseService.Instance;
        }

        /// <summary>
        /// Get the drug information by DrugId.
        /// </summary>
        /// <param name="drugId">The id of the drug.</param>
        /// <returns>The drug.</returns>
        public Drug GetDrugById(int drugId)
        {
            return this.drugModel.getDrugById(drugId);
        }
    }
}
