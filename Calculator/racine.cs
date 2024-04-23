using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Racine : IOperation
    {
        public Racine(float number1)
        {
            this.Number1 = number1;
        }

        public float Number1
        {
            get; set;
        }

        public float Number2
        {
            get; set;
        }

        public float calc()
        {
            float result = (float)Math.Sqrt(Number1);
            return result;
        }

    }
}
