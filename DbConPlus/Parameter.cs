using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DbConPlus
{
    public class Parameter
    {
        public string Name { get; protected set; }
        public SqlDbType Type { get; protected set; }
        public Parameter(string name, SqlDbType type)
        {
            Name = name;
            Type = type;
        }
    }
}
