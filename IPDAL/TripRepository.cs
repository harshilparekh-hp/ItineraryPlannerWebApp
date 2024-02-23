using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDAL
{
    /// <summary>
    /// TripRepository is responsible to connect to DB and executes command.
    /// </summary>
    public class TripRepository
    {
        /// <summary>
        /// Getting all trips from the db
        /// </summary>
        /// <returns></returns>
        public List<Trip> GetTrips()
        {
            // 1. connect to db

            List<Trip> trips = new List<Trip>();

            // 1. connect to db with the help of 'using'
            // so that at the end, the system can destroy the connection objects
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {

                // 2. fire sql query
                string commandText = "usp_GetAllTrips";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                // at this point, ADO.NET will fire query using command.
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand); // at this point, ADO.NET will fire query using command.

                DataTable dt = new DataTable();
                // at this point, query is fired and the data table has been filled with data/records/(Trips).
                adapter.Fill(dt); // at this point, query is fired and the data table has been filled with data/records/(Trips).

                // Fill method does below 5 things :
                // 1. Open to connection
                // 2. Execute the command
                // 3. Retrieve the result
                // 4. Fill the datatable
                // 5. Close the connection


                // 3. convert ADO.NET object to Entities (Trip)
                foreach (DataRow dr in dt.Rows)
                {
                    trips.Add(
                        new Trip
                        {
                            TripId = Convert.ToInt32(dr["TripId"]),
                            Destination = Convert.ToString(dr["Destination"]),
                            Description = Convert.ToString(dr["Description"]),
                            StartDate = Convert.ToDateTime(dr["StartDate"]),
                            EndDate = Convert.ToDateTime(dr["EndDate"])
                        });
                }

                return trips;
            }
        }

        /// <summary>
        /// Adding a new trip into db.
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public bool AddTrip(Trip trip)
        {
            using(SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertTrip", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // parameter to be accepted by store procedure
                sqlCommand.Parameters.AddWithValue("@Destination", trip.Destination);
                sqlCommand.Parameters.AddWithValue("@Description", trip.Description);
                sqlCommand.Parameters.AddWithValue("@StartDate", trip.StartDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", trip.EndDate);


                conn.Open();
                // execute non query will fire the query/execute store procedure
                // and will return 1 if the operation is successful, 0 if unsuccessful.
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                    return true;
                else
                    return false;

            }
        }

        /// <summary>
        /// Update trip in DB.
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public bool UpdateTrip(Trip trip)
        {
            using(SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                string commandText = "usp_UpdateTrip";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@TripId", trip.TripId);
                sqlCommand.Parameters.AddWithValue("@Destination", trip.Destination);
                sqlCommand.Parameters.AddWithValue("@Description", trip.Description);
                sqlCommand.Parameters.AddWithValue("@StartDate", trip.StartDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", trip.EndDate);

                conn.Open();
                // execute non query will fire the query/execute store procedure
                // and will return 1 if the operation is successful, 0 if unsuccessful.
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Repository method which deletes the trip from db
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public bool DeleteTrip(int tripId)
        {
            using(SqlConnection conn = new SqlConnection(Connection.ConnectionString)) 
            {
                string commandText = "usp_DeleteTrip";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@tripId", tripId);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if(i > 0) 
                    return true;
                else 
                    return false;

            }
        }

    }
}
