using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;

namespace SbTrigger01
{
    public static class SbTrigger02
    {
  
       static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        [FunctionName("SbTrigger02")]
        public static void Run([ServiceBusTrigger("BasicQueue", Connection = "servicebus001968_RootManageSharedAccessKey_SERVICEBUS")]string myQueueItem, ILogger log)
        {

            builder.DataSource = "myazuresql001968.database.windows.net";
            builder.UserID = "sqladmin001968";
            builder.Password = "@Myazuresql001968";
            builder.InitialCatalog = "mySampleDatabase";

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();

                string query = "INSERT INTO [SalesLT].[messages] (message) VALUES(@Message)";
                SqlCommand cmd = new SqlCommand(query, conn);
                System.Diagnostics.Trace.TraceError(myQueueItem);
                cmd.Parameters.AddWithValue("@Message", myQueueItem);

                cmd.ExecuteNonQuery();
            }

                log.LogInformation($" {myQueueItem}");
        }
    }
}
