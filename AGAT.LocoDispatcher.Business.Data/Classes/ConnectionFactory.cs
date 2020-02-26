using System;
using System.Collections.Generic;
using System.Text;

namespace AGAT.LocoDispatcher.Data.Classes
{
    public class ConnectionFactory
    {
        private string _connection;
        public void SetConnectionString(string connection)
        {
            _connection = connection;
        }
        public string GetConnectionString()
        {
            return _connection;
        }
    }
}
