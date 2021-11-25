using System.Collections.Generic;

namespace Lysia
{
    class Parser
    {
        public static dynamic Parse(List<Token> tokens)
        {
            if (tokens.Count == 0)
                return new List<dynamic>();

            Token token = tokens[0];
            tokens.RemoveAt(0);
            if (token.type == TokenType.OPEN_PAREN)
            {
                List<dynamic> L = new List<dynamic>();
                while (tokens[0].type != TokenType.CLOSE_PAREN)
                {
                    L.Add(Parse(tokens));
                    if (tokens.Count == 0)
                    {
                        System.Console.WriteLine("Unexpected EOF");
                        return new List<dynamic>();
                    }
                }
                tokens.RemoveAt(0);

                return L;
            }
            else if (token.type == TokenType.CLOSE_PAREN)
            {
                System.Console.WriteLine($"Unexpected ) : {token}");
                return new List<dynamic>();
            }
            else
                return token;
        }
    }
}
