using FunctionVisualizer.Functions.Validators.Tocken;
using System.Collections.Generic;
using System.Linq;
namespace FunctionVisualizer.Functions.Validators
{
    class ValidationRules
    {
        /// <summary>
        /// Задает правило следование токенов.
        /// После Токена ключа могут следовать только токены значения
        /// </summary>
        private Dictionary<TokenType, TokenType[]> _TableTokenPosition;

        public ValidationRules()
        {
            _TableTokenPosition = InitializeTokenTable();
        }        
        public TokenType[] this[TokenType key] { get => _TableTokenPosition[key]; }

        public bool TableContainsToken(TokenType key, TokenType value) => 
            _TableTokenPosition[key].Contains(value);

        //TODO: Изменить способ инициализации словоря правил
        private Dictionary<TokenType, TokenType[]> InitializeTokenTable()
        {
            return new Dictionary<TokenType, TokenType[]>()
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
        }
    }
}
