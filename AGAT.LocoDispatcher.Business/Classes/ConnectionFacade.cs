using AGAT.LocoDispatcher.Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Business.Classes
{
    public static class ConnectionFacade
    {
        public static void SetConnectionString(string connection, string asusDbConnection)
        {
            if (!String.IsNullOrEmpty(connection.Trim()) && !String.IsNullOrEmpty(asusDbConnection.Trim()))
            {
                Data.Classes.ConnectionFacade.SetConnectionString(connection);
                AsusData.ConnectionFaccede.SetConnectionString(asusDbConnection);
            }
            else
            {
                throw new ArgumentNullException("Invalid connection string");
            }
        }
    }
}
