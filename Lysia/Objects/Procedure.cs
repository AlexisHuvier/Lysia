using System.Collections.Generic;
using Lysia.Core;
using Lysia.Token;

namespace Lysia.Objects;

public class Procedure
{
    public readonly List<string> parameters = new();
    public readonly dynamic body = "";

    public Procedure(dynamic parameters, dynamic body)
    {
        if (parameters is List<dynamic> list)
        {
            this.parameters = new List<string>();
            foreach (var obj in list)
            {
                if (obj is Token.Token { Type: TokenType.Identifier } tok)
                    this.parameters.Add(tok.Value);
                else
                    Error.ShowError("WrongArgument", "Wrong Type of Argument.", obj);
            }

            this.body = body;
        }
        else
            Error.ShowError("WrongArgument", "Wrong Type of Argument.", parameters);
    }

    public dynamic Eval(Env env, List<dynamic> @params)
    {
        if (@params.Count != parameters.Count)
            Error.ShowError("WrongArgument", "Wrong Number of Arguments");
        for (var i = 0; i < parameters.Count; i++)
        {
            if (!env.Variables.TryAdd(parameters[i], @params[i]))
                env.Variables[parameters[i]] = @params[i];
        }
        return Interpreter.Eval(body, env);
    }
}