using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Mult : IOperation
    {
        public Mult(float number1, float number2)
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
            return Number1 * Number2;
        }

    }
}
