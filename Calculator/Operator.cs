using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IOperation
    {
        public float Number1 { get; set; }
        public float Number2 { get; set; }

        public float calc();

    }
}
