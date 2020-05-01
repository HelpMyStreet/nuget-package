using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Azure.Services.AppAuthentication;

namespace HelpMyStreet.Utils.DBConnection
{
    public static class SqlConnectionExtensions
    {
        public static void AddAzureToken(this SqlConnection connection)
        {
            if (connection.DataSource.Contains("database.windows.net"))
            {
                connection.AccessToken = new AzureServiceTokenProvider().GetAccessTokenAsync("https://database.windows.net/").Result;
            }
        }
    }
}
