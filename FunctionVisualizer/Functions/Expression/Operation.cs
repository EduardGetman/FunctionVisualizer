using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer.Functions.Expression
{
    public class Operation : IExpression
    {
        MathFunc func;
        List<IExpression> expression;

        public Operation(MathFunc func, params IExpression[] expression)
        {
            this.func = func;
            this.expression.AddRange(expression);
        }

        public double GetValue(double parametr) => Calculate(parametr);
        private double Calculate(double parametr)
        {
            if (expression.Count == 2)
                switch (func)
                {
                    case MathFunc.Add:
                        return expression[0].GetValue(parametr) + expression[1].GetValue(parametr);
                    case MathFunc.Sub:
                        return expression[0].GetValue(parametr) - expression[1].GetValue(parametr);
                    case MathFunc.Mul:
                        return expression[0].GetValue(parametr) * expression[1].GetValue(parametr);
                    case MathFunc.Div:
                        return expression[0].GetValue(parametr) / expression[1].GetValue(parametr);
                }
            else
                throw new Exception($"Несоответствие количество параметров функции {MathFunc.Add}");
            throw new Exception($"Отсутствует подходящая реализация вычисления функции: {MathFunc.Add}");
        }
    }
}