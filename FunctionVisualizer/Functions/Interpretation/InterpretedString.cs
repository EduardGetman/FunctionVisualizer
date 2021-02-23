using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunctionVisualizer.Functions.Validators;
using FunctionVisualizer.Functions.Validators.Tocken;

namespace FunctionVisualizer.Functions.Interpretation
{
    public class InterpretedString
    {
        List<string> _Words;
        List<TokenType> _WordsToken;

        public List<string> Words { get => _Words; private set => _Words = value; }
        internal List<TokenType> WordsToken { get => _WordsToken; private set => _WordsToken = value; }
        public int Length { get => Words.Count; }
        public InterpretedString(ValidString validStr)
        {
            _Words = new List<string>();
            _WordsToken = new List<TokenType>();
            parseString(validStr);
        }

        void parseString(ValidString validStr)
        {
            TokenType curentType = validStr.Tokens[0].Type;
            string word = "";
            for (int i = 0; i < validStr.Length; i++)
            {
                if (validStr.Tokens[i].Type == curentType)
                    word += validStr[i];
                else
                {
                    if (isStringAndDot(validStr.Tokens[i].Type, curentType))
                    {
                        word += validStr[i];
                        curentType = TokenType.Number;
                    }
                    _Words.Add(word);
                    _WordsToken.Add(curentType);
                    curentType = validStr.Tokens[i].Type;
                    word = "" + validStr[i];
                }
            }
            _Words.Add(word);
            _WordsToken.Add(curentType);
        }
        public InterpretedOperation GetOperatorsType(int index) 
        {
            if (Words[index].Length == 1 && WordsToken[index] == TokenType.Operator)
                return new InterpretedOperation(Words[index][0]);
            else
                throw new Exception("Слово по индексу не является оператором");
        }
        bool isStringAndDot(TokenType token1, TokenType token2)
        {
            return token1 == TokenType.Number && token2 == TokenType.Dot ||
                   token1 == TokenType.Dot && token2 == TokenType.Number;
        }
    }
}