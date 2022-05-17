using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DbConPlus
{
    public class OutputParamater : Parameter
    {
        public int? Size { get; set; }
        public byte? Precision { get; set; }
        public byte? Scale { get; set; }
        public OutputParamater(string name, SqlDbType type)
            : base(name, type)
        {
        }

        public OutputParamater(string name, SqlDbType type, int size)
            : base(name, type)
        {
            Size = size;
        }
        public OutputParamater(string name, SqlDbType type, byte precision, byte scale)
            : base(name, type)
        {
            Precision = precision;
            Scale = scale;
        }
    }
}
