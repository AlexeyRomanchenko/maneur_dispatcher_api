using AGAT.LocoDispatcher.Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Classes
{
    public static class ConnectionFactory
    {
        public static void SetConnectionString(string connection)
        {
            if (!String.IsNullOrWhiteSpace(connection))
            {
                Data.Classes.ConnectionFactory.SetConnectionString(connection);
            }
            else
            {
                throw new ArgumentNullException("Invalid connection string");
            }
        }
        public static string GetConnectionString()
        {
            return Data.Classes.ConnectionFactory.GetConnectionString();
        }
    }
}
