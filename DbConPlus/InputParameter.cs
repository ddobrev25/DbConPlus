using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConPlus
{
    public class InputParameter : Parameter
    {
        public object Value { get; set; }
        public InputParameter(string name, SqlDbType type, object value)
            : base(name, type)
        {
            Value = value;
        }
    }
}
