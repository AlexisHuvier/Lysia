using System.Collections.Generic;
using Lysia.Core;
using Lysia.Token;

namespace Lysia.Objects;

public class Procedure
{
    public readonly List<string> Parameters = [];
    public readonly dynamic Body = "";

    public Procedure(dynamic parameters, dynamic body)
    {
        if (parameters is List<dynamic> list)
        {
            Parameters = [];
            foreach (var obj in list)
            {
                if (obj is Token.Token { Type: TokenType.Identifier } tok)
                    Parameters.Add(tok.Value);
                else
                    Error.ShowError("Wrong Type of Argument.", obj);
            }

            Body = body;
        }
        else
            Error.ShowError("Wrong Type of Argument.", parameters);
    }

    public dynamic Eval(Env env, List<dynamic> @params)
    {
        @params.RemoveAt(0);
        
        if (@params.Count != Parameters.Count)
            Error.ShowError("Wrong Number of Arguments");
        for (var i = 0; i < Parameters.Count; i++)
        {
            if (!env.Variables.TryAdd(Parameters[i], @params[i]))
                env.Variables[Parameters[i]] = @params[i];
        }
        return Interpreter.Eval(Body, env);
    }
}