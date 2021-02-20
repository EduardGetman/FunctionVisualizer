using FunctionVisualizer.Functions.Validators.Tocken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionVisualizer.Functions.Validators
{
    class VerifiedString
    {
        private List<string> _ErrorList;
        private string _FunctionString;
        private List<Token> _Tokens;
        ValidationRules _ValidationRules;
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

        public VerifiedString(string functionString) => _FunctionString = functionString;

        private bool Validation() => PositioninTokens() && ComplianceBraces() && ValiditySymbols();

        private bool PositioninTokens()
        {
            bool result = false;
            for (int i = 0; i < _Tokens.Count; i++)
            {
                if (!_ValidationRules.TablePosition[_Tokens[i].Type].Contains(_Tokens[i + 1].Type))
                {
                    result = true;
                    _ErrorList.Add("Неверно задана последовательность символов:" +
                        $" {_FunctionString[i]} находиться перед {_FunctionString[i + 1]}");
                }
            }
            return result;
        }
        public static string CorectedString(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
                if (!char.IsWhiteSpace(str[i]))
                    result += str[i];
            return result.ToUpper();
        }

        private List<Token> SplittingIntoTokens(string str)
        {
            List<Token> result = new List<Token>();
            foreach (var item in FunctionString)            
                result.Add(new Token(item));
            return result;
        }
        private void SplittingIntoTokens() => _Tokens = SplittingIntoTokens(_FunctionString);
        /// <summary>
        /// Проверка соответствия скобок
        /// Перед каждой закрывающейся скобкой должна быть открывающаяся
        /// </summary>
        bool ComplianceBraces()
        {
            bool result = true;
            List<TokenType> BracketTockens = new List<TokenType>();
            foreach (var item in _Tokens)
                if (item.Type == TokenType.LeftBracket || item.Type == TokenType.RigthBracket)
                    BracketTockens.Add(item.Type);
            while (0 < BracketTockens.Count)
            {
                int leftBracket = -1;
                int rigthBracket = -2;
                for (int i = 0; i < BracketTockens.Count; i++)
                {
                    leftBracket = BracketTockens[i] == TokenType.LeftBracket ? i : leftBracket;
                    rigthBracket = BracketTockens[i] == TokenType.RigthBracket ? i : rigthBracket;
                    if (BracketsFounds(leftBracket, rigthBracket))
                    {
                        BracketTockens.RemoveAt(leftBracket);
                        BracketTockens.RemoveAt(rigthBracket);
                    }
                }
                if (!BracketsFounds(leftBracket, rigthBracket))
                {
                    _ErrorList.Add("Ненайденная пара левая скобка - правая кобка");
                    result = false;
                }
            }
            return result;

        }
        private bool BracketsFounds(int left, int rigth) => left < rigth && left >= 0 && rigth >= 0;

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
