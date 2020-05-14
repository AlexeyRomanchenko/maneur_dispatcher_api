using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.AsusData
{
    public static class ConnectionFaccede
    {
        private static string _connectionString;
        public static void SetConnectionString(string connectionString)
        {
            try
            {
                _connectionString = connectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
