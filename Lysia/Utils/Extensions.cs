using System.Collections.Generic;
using Lysia.Token;

namespace Lysia.Utils;

public static class Extensions
{
    public static TokenType GetTokenType(this string value)
    {
        if (int.TryParse(value, out _))
            return TokenType.Integer;
        
        return float.TryParse(value, out _) ? TokenType.Float : TokenType.Identifier;
    }

    public static bool VerifType(string type, dynamic val)
    {
        return val switch
        {
            Dictionary<dynamic, dynamic> => type == "dict",
            List<dynamic> => type == "list",
            int => type == "int",
            float => type == "float",
            bool => type == "bool",
            string => type == "string",
            _ => false
        };
    }
}