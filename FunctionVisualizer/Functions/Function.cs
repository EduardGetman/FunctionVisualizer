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
            Stack<InterpretedOperation> stackOperators = new Stack<InterpretedOperation>();
            InterpretedString interpStr = new InterpretedString(funcStr);
            for (int i = 0; i < interpStr.Length; i++)
            {
                InterpretedOperation operation;
                switch (interpStr.WordsToken[i])
                {
                    case TokenType.LeftBracket:
                        operation = new InterpretedOperation(interpStr.Words[i][0]);
                        stackOperators.Push(operation);
                        break;
                    case TokenType.RigthBracket:
                        while (stackOperators.Peek().Priority != OperatorsPriority.LBracket)
                        {
                            IExpression newOperator = new Operation(stackOperators.Pop().Func,
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
                        operation = new InterpretedOperation(interpStr.Words[i][0]);
                        if (stackOperators.Peek().Priority < operation.Priority &&
                            stackOperators.Peek().Priority != OperatorsPriority.LBracket && stackOperators.Count > 0)
                        {
                            IExpression newOperator = new Operation(stackOperators.Pop().Func,
                                stackValues.Pop(), stackValues.Pop());
                            stackValues.Push(newOperator);
                        }
                        stackOperators.Push(operation);
                        break;
                    default:
                        throw new Exception("Произошел неверный парсинг строки");
                }
            }
            return stackValues.Pop();
        }
    }
}