using System.Collections.Generic;
using Lysia.Token;

namespace Lysia.Core;

public class Parser
{
    public static dynamic Parse(List<Token.Token> tokens)
    {
        if (tokens.Count == 0)
            return new List<dynamic>();

        var token = tokens[0];
        tokens.RemoveAt(0);
        if (token.Type == TokenType.OpenParen)
        {
            var internalTokens = new List<dynamic>();
            while (tokens[0].Type != TokenType.CloseParen)
            {
                internalTokens.Add(Parse(tokens));
                if (tokens.Count == 0)
                    Error.ShowError("EOF", "Unexpected End of File", token);
            }
            tokens.RemoveAt(0);
            return internalTokens;
        }
        
        if (token.Type == TokenType.CloseParen)
            Error.ShowError("UnexpectedParen", "Unexpected )", token);

        return token;
    }
}