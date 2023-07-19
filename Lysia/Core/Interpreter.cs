using System;
using System.Collections.Generic;
using Lysia.Objects;
using Lysia.Token;
using Lysia.Utils;

namespace Lysia.Core;

public class Interpreter
{
    public static bool DEBUG = false;

    public static dynamic? Eval(dynamic exp, Env? env = null)
    {
        env ??= Env.GetStandardEnv();

        if (exp is Token.Token token)
        {
            switch (token.Type)
            {
                case TokenType.Identifier:
                    var tok = env.Get(token.Value);
                    if (tok is null)
                    {
                        if (DEBUG)
                            Print.PrintEnv(env);
                        Error.ShowError("UnknownIdentifier", "Unknown Identifier", token);
                    }
                    return tok;
                case TokenType.Integer:
                    return int.Parse(token.Value);
                case TokenType.Float:
                    return float.Parse(token.Value);
                case TokenType.String:
                    return token.Value;
                case TokenType.Unknown:
                case TokenType.OpenParen:
                case TokenType.CloseParen:
                default:
                    break;
            }
        }
        else if (exp is List<dynamic> list)
        {
            if (list.Count == 0)
                return null;
            var op = list[0];
            
            if (op is List<dynamic>)
            {
                foreach (var tok in list)
                {
                    if (tok is List<dynamic> tList && tList.Count >= 1 && tList[0].Value == "ret")
                        return Eval(tok, env);
                    Eval(tok, env);
                }

                return null;
            }

            if (op is Token.Token tOp && tOp.Type == TokenType.Identifier)
            {
                var procedure = Eval(tOp, env);
                if (procedure is Procedure proc)
                {
                    var values = new List<dynamic>();
                    for(var i = 0; i < list.Count; i++)
                        values.Add(Eval(list[i], env));
                    return proc.Eval(Env.FromEnv(env), values);
                }

                if (procedure is Function function)
                    return function.Eval(env, list);
                
                Error.ShowError("UnknownProcedure", "Unknown Procedure", tOp);
            }
        }
        return null;
    }
}