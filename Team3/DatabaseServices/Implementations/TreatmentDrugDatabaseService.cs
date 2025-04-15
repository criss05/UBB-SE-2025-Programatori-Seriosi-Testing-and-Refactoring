namespace Team3.DatabaseServices.Implementations
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    public class TreatmentDrugDatabaseService : ITreatmentDrugDatabaseService
    {
        private readonly string dbConnString;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentDrugDatabaseService"/> class.
        /// </summary>
        /// <param name="_dbConnString">The connection string for the database.</param>
        public TreatmentDrugDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        /// <summary>
        /// Adds a new treatment drug record to the database.
        /// </summary>
        /// <param name="treatmentDrug">The treatment drug to be added.</param>
        public void AddNewTreatmentDrug(TreatmentDrug treatmentDrug)
        {
            const string query = "INSERT INTO treatments_drugs(id, treatment_id, drug_id, quantity, starttime, endtime, startdate, nrdays) " +
                                 "VALUES (@id, @treatment_id, @drug_id, @quantity, @starttime, @endtime, @startdate, @nrdays)";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", treatmentDrug.Id);
                    command.Parameters.AddWithValue("@treatment_id", treatmentDrug.TreatmentId);
                    command.Parameters.AddWithValue("@drug_id", treatmentDrug.DrugId);
                    command.Parameters.AddWithValue("@quantity", treatmentDrug.Quantity);
                    command.Parameters.AddWithValue("@starttime", treatmentDrug.StartTime);
                    command.Parameters.AddWithValue("@endtime", treatmentDrug.EndTime);
                    command.Parameters.AddWithValue("@startdate", treatmentDrug.StartDate);
                    command.Parameters.AddWithValue("@nrdays", treatmentDrug.NrDays);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error adding treatment drug", exception);
            }
        }

        /// <summary>
        /// Retrieves the list of treatment drugs by treatment ID.
        /// </summary>
        /// <param name="treatmentId">The ID of the treatment.</param>
        /// <returns>A list of treatment drugs.</returns>
        public List<TreatmentDrug> GetTreatmentDrugsById(int treatmentId)
        {
            const string query = "SELECT * FROM treatments_drugs WHERE treatment_id = @treatment_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@treatment_id", treatmentId);

                    List<TreatmentDrug> treatmentDrugList = new List<TreatmentDrug>();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        treatmentDrugList.Add(new TreatmentDrug(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            Convert.ToDouble((decimal)reader[3]),
                            TimeOnly.FromTimeSpan(reader.GetFieldValue<TimeSpan>(4)),
                            TimeOnly.FromTimeSpan(reader.GetFieldValue<TimeSpan>(5)),
                            DateOnly.FromDateTime(reader.GetFieldValue<DateTime>(6)),
                            reader.GetInt32(7)
                        ));
                    }

                    return treatmentDrugList;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error retrieving treatment drugs", exception);
            }
        }
    }
}
