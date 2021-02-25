using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionVisualizer.Functions.Expression;

namespace FunctionVisualizer.Functions.Interpretation
{
    public struct InterpretedOperation
    {
        OperatorsPriority priority;
        MathFunc func;
        public OperatorsPriority Priority { get => priority;}
        public MathFunc Func { get => func;}
        public InterpretedOperation(char ch) 
        {
            switch (ch)
            {
                case '+':
                    priority = OperatorsPriority.Add;
                    func = MathFunc.Add;
                    break;
                case '-':
                    priority = OperatorsPriority.Sub;
                    func = MathFunc.Sub;
                    break;
                case '*':
                    priority = OperatorsPriority.Mul;
                    func = MathFunc.Mul;
                    break;
                case '/':
                    priority = OperatorsPriority.Div;
                    func = MathFunc.Div;
                    break;
                case '(':
                    priority = OperatorsPriority.LBracket;
                    func = MathFunc.Undefined;
                    break;
                case ')':
                    priority = OperatorsPriority.RBracket;
                    func = MathFunc.Undefined;
                    break;
                default:
                    throw new Exception("Слово по индексу не является оператором");
            }
        }
    }
}
