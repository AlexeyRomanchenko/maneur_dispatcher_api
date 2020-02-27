using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Classes
{
    public static class ConnectionFactory
    {
        private static string _connection;
        public static void SetConnectionString(string connection)
        {
            if (!String.IsNullOrWhiteSpace(connection))
            {
                _connection = connection.Trim();
                DatabaseContext context = new DatabaseContext();
            }
            else
            {
                throw new ArgumentNullException("Invalid connection string");
            }
        }
        public static string GetConnectionString()
        {
            if (!String.IsNullOrEmpty(_connection))
            {
                return _connection;
            }
            else
            {
                throw new FormatException($"connection string format is not valid connection string is {_connection}");
            }

        }
    }
}
