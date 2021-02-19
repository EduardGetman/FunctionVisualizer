using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer.Functions.Expression
{
    public class Number : IExpression
    {
        double _Value;
        public double GetValue(double parametr) => _Value;
    }
}