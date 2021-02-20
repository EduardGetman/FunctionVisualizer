using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer.Functions.Expression
{
    public class Number : IExpression
    {
        private double _Value;

        public Number(double value) => _Value = value;

        public double GetValue(double parametr) => _Value;
    }
}