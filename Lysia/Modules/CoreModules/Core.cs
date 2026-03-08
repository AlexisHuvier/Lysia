using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Token;
using Lysia.Utils;

namespace Lysia.Modules.CoreModules;

public static class Core
{
    [Docs("Cast", "Converts the given value to the specified type")]
    [DocsExample("(cast 1 float)", "1.0")]
    public class Cast() : Function([2], [], false)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            var value = Interpreter.Eval(values[1], env);
            if (values[0] is not Token.Token { Type: TokenType.Identifier } tok) return null;
            
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

            return null;
        }
    }
    
    [Docs("Comment", "Adds a comment to the code")]
    [DocsExample("(# This is a comment)", "")]
    public class Comment() : Function([], [], false);

    [Docs("Def", "Defines a new variable with the given name and value")]
    [DocsExample("(def x 2)", "2")]
    public class Def() : Function([2], [], false)
    {
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

    [Docs("Del", "Deletes the variable with the given name")]
    [DocsExample("(del x)", "")]
    public class Del() : Function([1], [], false)
    {
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

    [Docs("If", "Executes the given code if the condition is true, otherwise executes the given code")]
    [DocsExample("(if (== 1 1) (io:display true) (io:display false))", "true")]
    public class If() : Function([3], [], false)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            if (Interpreter.Eval(values[0], env) is bool condition)
                return Interpreter.Eval(condition ? values[1] : values[2], env);
            Error.ShowError("Expected Boolean", values[0]);
            return null;
        }
    }

    [Docs("While", "Executes the given code while the condition is true")]
    [DocsExample("(while (!= 1 1) (io:display true))", "")]
    public class While() : Function([2], [], false)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            while (Interpreter.Eval(values[0], env) is true)
                Interpreter.Eval(values[1], env);
            return null;
        }
    }
    
    [Docs("For", "Iterates over a range of values")]
    [DocsExample("(for i (0 10 1) (io:display i))", "0 1 2 3 4 5 6 7 8 9")]
    public class For() : Function([3], [], false)
    {
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

    [Docs("Func", "Defines a new function with the given name and body")]
    [DocsExample("(func (x y) (ret (+ x y)))", "Function which adds two numbers")]
    public class Func() : Function([2], [], false)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;

            return new Procedure(values[0], values[1]);
        }
    }

    [Docs("Import", "Imports a module or file")]
    [DocsExample("(import io)", "")]
    [DocsExample("(import externModule)", "")]
    [DocsExample("(import file.lysia)", "")]
    public class Import() : Function([1], [], false)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if (values[0] is Token.Token { Type: TokenType.Identifier } token)
            {
                var import = token.Value;
                if (Imports.IsDefined(import))
                {
                    foreach (var function in Imports.Get(import).GetMethod("GetImports")?.Invoke(null, null) as Dictionary<string, Function> ?? [])
                        env.CoreMethods[function.Key] = function.Value;
                }
                else if (File.Exists(import) && Path.GetExtension(import) == ".lysia")
                    Interpreter.Eval(Parser.Parse(Lexer.Tokenize(File.ReadAllText(import))), env);
                else if (File.Exists(Environment.ExpandEnvironmentVariables($"%appdata%/LysiaModules/{import}.dll")))
                {
                    var dll = Assembly.LoadFile(
                        Environment.ExpandEnvironmentVariables($"%appdata%/LysiaModules/{import}.dll"));
                    var imports = dll.GetTypes().FirstOrDefault(x => x.Name == "Imports");
                    var field = imports?.GetField("ImportsList", BindingFlags.Public | BindingFlags.Static);
                    var importsList = (Dictionary<string, Function>)(field?.GetValue(null) ?? new Dictionary<string, Function>());
                    foreach (var function in importsList)
                        env.CoreMethods[function.Key] = new ModuleFunction(function.Value);
                }
                else
                    Error.ShowError("Unknown Import", parameters[0]);
            }
            else
                Error.ShowError("Wait import or lysia file", parameters[0]);

            return null;
        }
    }
    
    [Docs("Ret", "Returns a value from a function")]
    [DocsExample("(ret 42)", "42")]
    public class Ret() : Function([1], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0];
        }
    }

    [Docs("TypeOf", "Returns the type of a value")]
    [DocsExample("(typeof 42)", "int")]
    public class TypeOf() : Function([1], [], true)
    {
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