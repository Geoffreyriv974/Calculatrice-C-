using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Div : IOperation
    {
        public Div(float number1, float number2)
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

            if (Number2 == 0)
            {
                throw new DivideByZeroException("Impossble de diviser par 0 !");
            }

            return Number1 / Number2;
        }

    }
}
