using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer.Functions.Expression
{
    public class Variable : IExpression
    {
        public double Value { get; set; }

        public double GetValue(double parametr) => parametr;
    }
}