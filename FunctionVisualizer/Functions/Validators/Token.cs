using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionVisualizer.Functions.Validators.Tocken
{
    class Token
    {
        private TokenType _Type;

        internal TokenType Type { get => _Type; set => _Type = value; }

        public Token(TokenType type) => this.Type = type;
        public Token(char ch) => Type = Identify(ch);
        public static TokenType Identify(char ch) 
        {
            if (IsLeftBracket(ch)) return TokenType.LeftBracket;
            else if (IsRigthBracket(ch)) return TokenType.RigthBracket;
            else if (IsNumber(ch)) return TokenType.Number;
            else if (IsOperator(ch)) return TokenType.Operator;
            else if (IsVariable(ch)) return TokenType.Variable;
            else if (IsDot(ch)) return TokenType.Dot;
            else return TokenType.Unknown;
        }
        static bool IsLeftBracket(char ch) => ch == '(';
        static bool IsRigthBracket(char ch) => ch == ')';
        static bool IsVariable(char ch) => ch >= 'A' && ch <= 'Z';
        static bool IsNumber(char ch) => ch >= '0' && ch <= '9';
        static bool IsOperator(char ch) => ch == '+' || ch == '-' || ch == '/' || ch == '*';
        static bool IsDot(char ch) => ch == '.';
    }
}
