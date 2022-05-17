using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConPlus
{
    public class Query
    {
        public string Command { get; private set; }
        public Query(string command)
        {
            Command = command;
        }
    }
}
