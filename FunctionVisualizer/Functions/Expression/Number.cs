using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer.Functions.Expression
{
    public class Number : IExpression
    {
        private double _Value;

        public Number(double value) => Value = value;

        public double Value { get => _Value; set => _Value = value; }

        public double GetValue(double parametr) => Value;
    }
}