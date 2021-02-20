using System;
using System.Collections.Generic;

namespace FunctionVisualizer.Functions.Expression
{
    public class Operation : IExpression
    {
        private MathFunc _Func;
        private List<IExpression> _Expression;

        public Operation(MathFunc func, params IExpression[] expression)
        {
            _Expression = new List<IExpression>();
            _Func = func;
            _Expression.AddRange(expression);
        }

        public double GetValue(double parametr) => Calculate(parametr);
        private double Calculate(double parametr)
        {
            if (_Expression.Count == 2)
                switch (_Func)
                {
                    case MathFunc.Add:
                        return _Expression[0].GetValue(parametr) + _Expression[1].GetValue(parametr);
                    case MathFunc.Sub:
                        return _Expression[0].GetValue(parametr) - _Expression[1].GetValue(parametr);
                    case MathFunc.Mul:
                        return _Expression[0].GetValue(parametr) * _Expression[1].GetValue(parametr);
                    case MathFunc.Div:
                        return _Expression[0].GetValue(parametr) / _Expression[1].GetValue(parametr);
                }
            else
                throw new Exception($"Несоответствие количество параметров функции {MathFunc.Add}");
            throw new Exception($"Отсутствует подходящая реализация вычисления функции: {MathFunc.Add}");
        }
    }
}