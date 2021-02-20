using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunctionVisualizer.Functions.Expression;
using FunctionVisualizer.Functions.Validators.Tocken;

namespace FunctionVisualizer.Functions
{
    public class Function
    {
        private IExpression _Expression;

        public double Calculate(double parametr) => _Expression.GetValue(parametr);
        public Function(string funcStr) => _Expression = Interpret(funcStr);

        private IExpression Interpret(string funcStr) 
        {
            throw new NotImplementedException();
        }
    }
}