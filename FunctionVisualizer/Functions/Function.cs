using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunctionVisualizer.Functions.Expression;
using FunctionVisualizer.Functions.Validators.Tocken;
using FunctionVisualizer.Functions.Validators;
using FunctionVisualizer.Functions.Interpretation;

namespace FunctionVisualizer.Functions
{
    public class Function
    {
        private IExpression _Expression;

        public double Calculate(double parametr) => _Expression.GetValue(parametr);
        public Function(ValidString funcStr)
        {
            if (!funcStr.IsValid)
                throw new Exception("Переданна невалидная строка");
            _Expression = Interpret(funcStr);
        }

        private IExpression Interpret(ValidString funcStr) 
        {
            Stack<IExpression> stackValues = new Stack<IExpression>();
            Stack<OperatorsType> stackOperators = new Stack<OperatorsType>();
            InterpretedString interpStr = new InterpretedString(funcStr);
            for (int i = 0; i < interpStr.Length; i++)
            {
                switch (interpStr.WordsToken[i])
                {
                    case TokenType.LeftBracket:
                        stackOperators.Push(OperatorsType.LBracket);
                        break;
                    case TokenType.RigthBracket:
                        while (stackOperators.Peek() != OperatorsType.LBracket)
                        {
                            IExpression newOperator = new Operation(SwitchOperation(stackOperators.Pop()),
                                stackValues.Pop(), stackValues.Pop());
                            stackValues.Push(newOperator);
                        }
                        stackOperators.Pop();
                        break;
                    case TokenType.Variable:
                        stackValues.Push(new Variable());
                        break;
                    case TokenType.Number:
                        stackValues.Push(new Number(Convert.ToDouble(interpStr.Words[i])));
                        break;
                    case TokenType.Operator:
                        OperatorsType _operator = interpStr.GetOperatorsType(i);
                        if (stackOperators.Peek() < _operator && stackOperators.Peek() != OperatorsType.LBracket)
                        {
                            IExpression newOperator = new Operation(SwitchOperation(stackOperators.Pop()),
                                stackValues.Pop(), stackValues.Pop());
                            stackValues.Push( newOperator);
                        }
                            stackOperators.Push(_operator);
                        break;                    
                    default:
                        throw new Exception("Произошел неверный парсинг строки");
                }
            }
            return stackValues.Pop();
        }
        private MathFunc SwitchOperation(OperatorsType type) 
        {
            if (type.ToString() == "Add") return MathFunc.Add;
            else if (type.ToString() == "Div") return MathFunc.Div;
            else if (type.ToString() == "Mul") return MathFunc.Mul;
            else if (type.ToString() == "Sub") return MathFunc.Sub;
            else throw new Exception("Ошибка алгоритма интерпритации." +
                        " В функцию попали неверные данные");
        }
    }
}