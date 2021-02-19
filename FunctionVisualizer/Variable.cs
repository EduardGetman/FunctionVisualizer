using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer
{
    public class Variable : IExpression
    {
        public double GetValue(double parametr) => parametr;
    }
}