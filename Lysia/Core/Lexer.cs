using System.Collections.Generic;
using Lysia.Token;
using Lysia.Utils;

namespace Lysia.Core;

public class Lexer
{
    public static List<Token.Token> Tokenize(string program)
    {
        var tokens = new List<Token.Token>();
        var line = 1;
        var column = 0;
        var ptr = 0;
        var state = LexerState.Normal;
        var text = "";

        while (ptr != program.Length)
        {
            if (state == LexerState.String && (program[ptr] != '"' || program[ptr - 1] == '\\'))
                text += program[ptr];
            else if (state == LexerState.String)
            {
                tokens.Add(new Token.Token(text, TokenType.String, line, column - text.Length));
                text = "";
                state = LexerState.Normal;
            }
            else switch (program[ptr])
            {
                case '(':
                case ')':
                {
                    if(text.Length > 0)
                        tokens.Add(new Token.Token(text, text.GetTokenType(), line, column - text.Length));
                    text = "";

                    tokens.Add(new Token.Token(program[ptr].ToString(),
                        program[ptr] == '(' ? TokenType.OpenParen : TokenType.CloseParen, line, column));
                    break;
                }
                case '"':
                    text = "";
                    state = LexerState.String;
                    break;
                case ' ':
                {
                    if (text.Length > 0)
                        tokens.Add(new Token.Token(text, text.GetTokenType(), line, column - text.Length));
                    text = "";
                    break;
                }
                case '\n':
                    if(text.Length > 0)
                        tokens.Add(new Token.Token(text, text.GetTokenType(), line, column - text.Length));
                    text = "";
                    
                    line += 1;
                    column = 0;
                    break;
                default:
                    text += program[ptr];
                    break;
            }

            ptr++;
            column++;
        }
        
        if(text.Length > 0)
            tokens.Add(new Token.Token(text, text.GetTokenType(), line, column - text.Length));
        return tokens;
    }
}