using System;
using System.Collections.Generic;
using Lysia.Objects;
using Lysia.Token;
using Lysia.Utils;

namespace Lysia.Core;

public static class Interpreter
{
#pragma warning disable CA2211
    public static bool Debug = false;
#pragma warning restore CA2211

    public static dynamic? Eval(dynamic exp, Env? env = null)
    {
        env ??= Env.GetStandardEnv();

        switch (exp)
        {
            case Token.Token token:
                switch (token.Type)
                {
                    case TokenType.Identifier:
                        var tok = env.Get(token.Value);
                        if (tok is not null) return tok;
                        
                        if (Debug)
                            Print.PrintEnv(env);
                        Error.ShowError("Unknown Identifier", token);
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

                break;
            case List<dynamic> { Count: 0 }:
                break;
            case List<dynamic> list:
            {
                var op = list[0];
            
                switch (op)
                {
                    case List<dynamic>:
                    {
                        foreach (var tok in list)
                        {
                            if (tok is List<dynamic> { Count: >= 1 } tList && tList[0].Value == "ret")
                                return Eval(tok, env);
                            Eval(tok, env);
                        }

                        return null;
                    }
                    case Token.Token { Type: TokenType.Identifier } tOp:
                    {
                        var procedure = Eval(tOp, env);
                        switch (procedure)
                        {
                            case Procedure proc:
                            {
                                var values = new List<dynamic>();
                                for(var i = 0; i < list.Count; i++)
                                    values.Add(Eval(list[i], env));
                                return proc.Eval(Env.FromEnv(env), values);
                            }
                            case Function function:
                                return function.Eval(env, list);
                        }

                        Error.ShowError("Unknown Procedure", tOp);
                        break;
                    }
                }

                break;
            }
        }
        return null;
    }
}