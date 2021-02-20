using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionVisualizer.Functions.Validators.Tocken;

namespace FunctionVisualizer.Functions.Validators
{
    class FunctionValidator
    {
        private List<string> _ErrorList;
        private List<Token> _Tokens;
        private string _FunctionString;
        /// <summary>
        /// Задает правило следование токенов.
        /// После Токена ключа могут следовать только токены значения
        /// </summary>
        private Dictionary<TokenType, TokenType[]> _TableTokenPosition;

        //TODO:Сделать с этим что-то. Очевидно что не стоит хранить правила в коде
        private void InitializeTokenTable() => _TableTokenPosition = new Dictionary<TokenType, TokenType[]>()
        {
            [TokenType.Dot] = new TokenType[] { TokenType.Number },
            [TokenType.LeftBracket] = new TokenType[] {TokenType.Number,
                                                         TokenType.LeftBracket,
                                                         TokenType.RigthBracket,
                                                         TokenType.Variable},
            [TokenType.Number] = new TokenType[] { TokenType.Operator,
                                                     TokenType.RigthBracket,
                                                     TokenType.Dot},
            [TokenType.Operator] = new TokenType[] {  TokenType.Number,
                                                   TokenType.LeftBracket,
                                                   TokenType.Variable },
            [TokenType.RigthBracket] = new TokenType[] { TokenType.Operator,
                                                           TokenType.RigthBracket },
            [TokenType.Variable] = new TokenType[] { TokenType.Variable,
                                                       TokenType.RigthBracket },

        };
        public string FunctionString
        {
            get => _FunctionString; set
            {
                _FunctionString = value;
                SplittingIntoTokens();
            }
        }

        public FunctionValidator(string functionString)
        {
            _ErrorList = new List<string>();
            _Tokens = new List<Token>();
            FunctionString = functionString;
            InitializeTokenTable();
            SplittingIntoTokens();
        }
        /// <summary>
        /// Коректируюет строку функции.
        /// </summary>
        /// <returns> Строка верхнего регистра и без пробелов</returns>
        public static string CorectedString(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
                if (!char.IsWhiteSpace(str[i]))
                    result += str[i];
            return result.ToUpper();
        }
        private void SplittingIntoTokens()
        {
            foreach (var item in FunctionString)
            {
                Token token = new Token(item);
                if (token.Type == TokenType.Unknown)
                    _ErrorList.Add($"Встречен неизвестный символ: {item}");
                _Tokens.Add(token);
            }
        }

        public bool IsBadString()
        {
            return PositioninTokens() || ComplianceBraces() || ValiditySymbols();
        }
        /// <summary>
        /// Проверка позиций токенов.
        /// Правила позиционирования токенов задаются таблицей
        /// </summary>
        bool PositioninTokens()
        {
            bool result = false;
            for (int i = 0; i < _Tokens.Count; i++)
            {
                if (!_TableTokenPosition[_Tokens[i].Type].Contains(_Tokens[i + 1].Type))
                {
                    result = true;
                    _ErrorList.Add("Неверно задана последовательность символов:" +
                        $" {_FunctionString[i]} находиться перед {_FunctionString[i + 1]}");
                }
            }
            return result;
        }
        /// <summary>
        /// Проверка соответствия скобок
        /// Перед каждой закрывающейся скобкой должна быть открывающаяся
        /// </summary>
        bool ComplianceBraces()
        {
            bool result = false;
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
                    result = true;
                }
            }
            return result;

        }
        private bool BracketsFounds(int left, int rigth) => left < rigth && left >= 0 && rigth >= 0;
        /// <summary>
        /// Проверка допустимых символов
        /// В список допустимых символов входят: + - * / . 0 1 2 3 4 5 6 7 8 9 ( ) X
        /// </summary>
        bool ValiditySymbols()
        {
            foreach (var item in _Tokens)
                if (item.Type == TokenType.Unknown)
                    return false;
            return true;
        }
    }
}
