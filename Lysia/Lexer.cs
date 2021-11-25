using System.Collections.Generic;
using System;

namespace Lysia
{
    class Lexer
    {
        public static TokenType GetTokenType(string value) 
        {
            try
            {
                Convert.ToInt32(value);
                return TokenType.INTEGER;
            }
            catch(FormatException)
            {
                try
                {
                    Convert.ToDecimal(value);
                    return TokenType.FLOAT;
                }
                catch(FormatException)
                {
                    return TokenType.IDENTIFIER;
                }
            }
        }
        public static List<Token> Tokenize(string program)
        {
            List<Token> tokens = new List<Token>();
            int line = 1;
            int column = 1;
            int current = 0;
            int state = 0;
            string text = "";

            while(current != program.Length)
            {
                if (state == 1 && (program[current] != '"' || program[current - 1] == '\\'))
                    text += program[current];
                else if(state == 1)
                {
                    tokens.Add(new Token(text, TokenType.STRING, line, column - text.Length));
                    text = "";
                    state = 0;
                }
                else if(program[current] == '(' || program[current] == ')')
                {
                    if (text.Length > 0)
                        tokens.Add(new Token(text, GetTokenType(text), line, column - text.Length));
                    text = "";
                    if(program[current] == '(')
                        tokens.Add(new Token(program[current].ToString(), TokenType.OPEN_PAREN, line, column));
                    else
                        tokens.Add(new Token(program[current].ToString(), TokenType.CLOSE_PAREN, line, column));
                }
                else if(program[current] == '"')
                {
                    text = "";
                    state = 1;
                }
                else if(program[current] == ' ') 
                {
                    if (text.Length > 0)
                        tokens.Add(new Token(text, GetTokenType(text), line, column - text.Length));
                    text = "";
                }
                else if(program[current] == '\n')
                {
                    line += 1;
                    column = 0;
                    text = "";
                }
                else
                {
                    text += program[current];
                }
                current += 1;
                column += 1;
            }

            if(text.Length > 0)
                tokens.Add(new Token(text, GetTokenType(text), line, column - text.Length));

            return tokens;
        }
    }
}
