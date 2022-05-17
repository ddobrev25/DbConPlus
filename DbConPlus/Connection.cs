using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConPlus
{
    public class Connection
    {
        protected string ConnectionString { get; set; }
        public Connection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
