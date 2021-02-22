using FunctionVisualizer.Functions.Validators.Tocken;
using System.Collections.Generic;

namespace FunctionVisualizer.Functions.Validators
{
    public class ValidString
    {
        private List<string> _ErrorList;
        private string _FunctionString;
        private List<Token> _Tokens;
        private ValidationRules _ValidationRules;
        public bool IsValid { get; private set; }      

        public string FunctionString
        {
            get => _FunctionString; set
            {
                _ErrorList = new List<string>();
                value = CorectedString(value);
                SplittingIntoTokens(value);
                IsValid = Validation();
                _FunctionString = value;
            }
        }
        public static string CorectedString(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
                if (!char.IsWhiteSpace(str[i]))
                    result += str[i];
            result.ToUpper();
            return AddMultiplue(result);
        }
        private static string AddMultiplue(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length-1; i++)
            {
                result += str[i];
                if (Token.Identify(str[i]) == TokenType.Number & Token.Identify(str[i +1 ]) == TokenType.Variable ||
                    Token.Identify(str[i]) == TokenType.Variable & Token.Identify(str[i + 1]) == TokenType.Number)
                result += '*';               
            }
            return result;
        }
        public ValidString(string functionString) => _FunctionString = functionString;

        private bool Validation() => PositioninTokens() && ComplianceBraces() && ValiditySymbols();

        private bool PositioninTokens()
        {
            bool result = false;
            for (int i = 0; i < _Tokens.Count; i++)
            {
                if (!_ValidationRules.TableContainsToken(_Tokens[i].Type, _Tokens[i + 1].Type))
                {
                    result = true;
                    _ErrorList.Add("Неверно задана последовательность символов:" +
                        $" {_FunctionString[i]} находиться перед {_FunctionString[i + 1]}");
                }
            }
            return result;
        }
        private List<Token> SplittingIntoTokens(string str)
        {
            List<Token> result = new List<Token>();
            foreach (var item in FunctionString)            
                result.Add(new Token(item));
            return result;
        }
        /// <summary>
        /// Проверка соответствия скобок
        /// Перед каждой закрывающейся скобкой должна быть открывающаяся
        /// </summary>

        private bool ComplianceBraces()
        {
            bool result = true;
            int bracketBalance = 0;
            foreach (var item in _Tokens)
            {
                bracketBalance += (item.Type == TokenType.LeftBracket) ? 1 : 0;
                bracketBalance += (item.Type == TokenType.RigthBracket) ? -1 : 0;
                if (bracketBalance < 0)
                {
                    _ErrorList.Add("Ненайденная пара левая скобка - правая кобка");
                    result = false;
                }
            }
            return result;

        }       

        /// <summary>
        /// Проверка допустимых символов
        /// В список допустимых символов входят: + - * / . 0 1 2 3 4 5 6 7 8 9 ( ) X
        /// </summary>
        private bool ValiditySymbols()
        {
            for (int i = 0; i < _Tokens.Count; i++)
            {
                if (_Tokens[i].Type == TokenType.Unknown)
                {
                    _ErrorList.Add($"Встречен неизвестный символ: {_FunctionString[i]}");
                    return false;
                }
            }                
            return true;
        }
    }
}
