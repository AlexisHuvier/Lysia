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
                        Error.ShowError("WrongCast", "Cannot be int", values[1]);
                        break;
                    case "float":
                        if (float.TryParse(value, out float single))
                            return single;
                        Error.ShowError("WrongCast", "Cannot be float", values[1]);
                        break;
                    case "string":
                        return value.ToString();
                    case "bool":
                        if (bool.TryParse(value, out bool boolean))
                            return boolean;
                        Error.ShowError("WrongCast", "Cannot be boolean", values[1]);
                        break;
                    default:
                        Error.ShowError("WrongCast", "Unknown Type", values[0]);
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
                Error.ShowError("WrongArgument", "Expected Identifier", values[0]);
            return value;
        }
    }

    public class Del : Function
    {
        public Del(): base(new []{ 1 }, Array.Empty<string[]>(), false)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if (values[0] is Token.Token { Type: TokenType.Identifier } token)
            {
                if (!env.IsDefine(token.Value))
                    Error.ShowError("WrongArgument", "Identifier not defined", token);
                else
                {
                    var value = env.Variables[token.Value];
                    env.Variables.Remove(token.Value);
                    return value;
                }
            }
            else
                Error.ShowError("WrongArgument", "Expected Identifier", values[0]);
            return null;
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
                    Error.ShowError("UnknownImport", "Unknown Import", parameters[0]);
            }
            else
                Error.ShowError("WrongArgument", "Wait import or lysia file", parameters[0]);

            return null;
        }
    }
}