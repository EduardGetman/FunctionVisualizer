using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunctionVisualizer.Functions.Expression;
using FunctionVisualizer.Functions.Validators.Tocken;
using FunctionVisualizer.Functions.Validators;
namespace FunctionVisualizer.Functions
{
    public class Function
    {
        private IExpression _Expression;

        public double Calculate(double parametr) => _Expression.GetValue(parametr);
        public Function(ValidString funcStr) => _Expression = Interpret(funcStr);

        private IExpression Interpret(ValidString funcStr) 
        {
            throw new NotImplementedException();
        }
    }
}