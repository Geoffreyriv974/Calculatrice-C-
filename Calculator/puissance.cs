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
    public class Puissance : IOperation
    {
        public Puissance(float number1, float number2)
        {
            this.Number1 = number1;
            this.Number2 = number2;
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
            float result = Number1;
            for (int i = 0; i < Number2 -1; i++)
            {
                result *= Number1;
            }
            return result;
        }

    }
}
