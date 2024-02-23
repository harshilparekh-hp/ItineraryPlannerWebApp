using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IPDAL
{
    /// <summary>
    /// TripTaskRepository is responsible to connect to DB and executes command.
    /// </summary>
    public class TripTaskRepository
    {
        public List<TripTask> GetTripTasks(int tripId)
        {
            List<TripTask> tripTasks = new List<TripTask>();

            using(SqlConnection conn = new SqlConnection(Connection.ConnectionString)) 
            {
                string commandText = "usp_GetTasks";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@tripId", tripId);
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
                    tripTasks.Add(
                        new TripTask
                        {
                            TripId = Convert.ToInt32(dr["TripId"]),
                            TripTaskId = Convert.ToInt32(dr["TripTaskId"]),
                            TaskName = Convert.ToString(dr["TaskName"]),
                            TaskDescription = Convert.ToString(dr["TaskDescription"]),
                            TaskDueDate = Convert.ToDateTime(dr["TaskDueDate"]),
                        });
                }
            }

            return tripTasks;
        }
    }
}
