using System;
using System.Collections.Generic;
using System.IO;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Token;

namespace Lysia.Modules;

public class Core
{
    public class Cast : Function
    {
        public Cast(): base(new []{ 2 }, Array.Empty<string[]>(), false)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            var value = Interpreter.Eval(values[1], env);
            if (values[0] is Token.Token { Type: TokenType.Identifier } tok)
            {
                switch (tok.Value)
                {
                    case "int":
                        if (int.TryParse(value, out int integer))
                            return integer;
                        Error.ShowError("Cannot be int", values[1]);
                        break;
                    case "float":
                        if (float.TryParse(value, out float single))
                            return single;
                        Error.ShowError("Cannot be float", values[1]);
                        break;
                    case "string":
                        return value.ToString();
                    case "bool":
                        if (bool.TryParse(value, out bool boolean))
                            return boolean;
                        Error.ShowError("Cannot be boolean", values[1]);
                        break;
                    default:
                        Error.ShowError("Unknown Type", values[0]);
                        break;
                }
            }

            return null;
        }
    }
    
    public class Comment : Function
    {
        public Comment() : base(Array.Empty<int>(), Array.Empty<string[]>(), false)
        {}
    }

    public class Def : Function
    {
        public Def(): base(new []{ 2 }, Array.Empty<string[]>(), false)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            var value = Interpreter.Eval(values[1], env);

            if (values[0] is Token.Token { Type: TokenType.Identifier } tok)
                env.Variables[tok.Value] = value;
            else
                Error.ShowError("Expected Identifier", values[0]);
            return value;
        }
    }

    public class Del : Function
    {
        public Del(): base(new [] { 1 }, Array.Empty<string[]>(), false)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if (values[0] is Token.Token { Type: TokenType.Identifier } token)
            {
                if (!env.IsDefine(token.Value))
                    Error.ShowError("Identifier not defined", token);
                else
                {
                    var value = env.Variables[token.Value];
                    env.Variables.Remove(token.Value);
                    return value;
                }
            }
            else
                Error.ShowError("Expected Identifier", values[0]);
            return null;
        }
    }

    public class For: Function
    {
        public For() : base(new[] { 3 }, Array.Empty<string[]>(), false)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if (values[0] is Token.Token { Type: TokenType.Identifier } token)
            {
                if(env.IsDefine(token.Value))
                    Error.ShowError("Identifier already defined", values[0]);
                else
                {
                    if (values[1] is List<dynamic> { Count: 3 } forValues)
                    {
                        var forInts = new[] { 0, 0, 0 };
                        for (var i = 0; i < 3; i++)
                        {
                            var forInt = Interpreter.Eval(forValues[i], env);
                            if (forInt is int forInteger)
                                forInts[i] = forInteger;
                            else
                                Error.ShowError("Wrong Type of argument. Need List of 3 Integer", values[1]);
                        }

                        for (var i = forInts[0]; i < forInts[1]; i += forInts[2])
                        {
                            env.Variables[token.Value] = i;
                            Interpreter.Eval(values[2], env);
                        }
                    }
                    else
                        Error.ShowError("Wrong Type of argument. Need List of 3 Integer", values[1]);
                }
            }
            else
                Error.ShowError("Expected Identifier", values[0]);
            return null;
            
        }
    }

    public class Func : Function
    {
        public Func(): base(new [] { 2 }, Array.Empty<string[]>(), false)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;

            return new Procedure(values[0], values[1]);
        }
    }

    public class Import : Function
    {
        public Import() : base(new[] { 1 }, Array.Empty<string[]>(), false)
        { }

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if (values[0] is Token.Token { Type: TokenType.Identifier } token)
            {
                var import = token.Value;
                if (Imports.IsDefined(import))
                {
                    foreach (var function in Imports.Get(import))
                        env.CoreMethods.Add(function.Key, function.Value);
                }
                else if (File.Exists(import) && Path.GetExtension(import) == ".lysia")
                    Interpreter.Eval(Parser.Parse(Lexer.Tokenize(File.ReadAllText(import))), env);
                else
                    Error.ShowError("Unknown Import", parameters[0]);
            }
            else
                Error.ShowError("Wait import or lysia file", parameters[0]);

            return null;
        }
    }

    public class Ret : Function
    {
        public Ret() : base(new[] { 1 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0];
        }
    }

    public class TypeOf : Function
    {
        public TypeOf(): base(new [] { 1 }, Array.Empty<string[]>(), true) 
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;

            return values[0] switch
            {
                Dictionary<dynamic, dynamic> => "dict",
                List<dynamic> => "list",
                int => "int",
                float => "float",
                bool => "bool",
                string => "string",
                _ => values[0].GetType().ToString()
            };
        }
    }
}