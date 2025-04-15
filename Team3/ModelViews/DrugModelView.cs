namespace Team3.ModelViews
{
    using System;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// DrugModelView is a class that implements the IDrugModelView interface.
    /// </summary>
    public class DrugModelView : IDrugModelView
    {
        private readonly IDrugDatabaseService drugDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugModelView"/> class.
        /// Constructor for DrugModelView.
        /// </summary>
        /// <param name="dbConnString">The database connection string.</param>
        public DrugModelView(string dbConnString)
        {
            this.drugDatabaseService = new DrugDatabaseService(dbConnString);
        }

        /// <summary>
        /// Get the drug information by DrugId.
        /// </summary>
        /// <param name="drugId">The id of the drug.</param>
        /// <returns>The drug.</returns>
        public Drug GetDrugById(int drugId)
        {
            return this.drugDatabaseService.GetDrugById(drugId);
        }
    }
}
