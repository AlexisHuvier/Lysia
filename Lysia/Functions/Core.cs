using System.Collections.Generic;
using System;
using System.IO;
using Lysia.Utils;


namespace Lysia.Functions
{
    class Core
    {
        public class Import
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[] typeParameters = new string[] { "string" };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if(Imports.IsDefined(parameters[0]))
                {
                    foreach (KeyValuePair<string, Type> pair in Imports.Get(parameters[0]))
                        env.core_methods.Add(pair.Key, pair.Value);
                }
                else if(File.Exists(parameters[0]) && Path.GetExtension(parameters[0]) == ".lysia")
                    Interpreter.Eval(Parser.Parse(Lexer.Tokenize(File.ReadAllText(parameters[0]))), env);
                else
                    Interpreter.ShowError($"Unknown Import : {parameters[0]}");
                return null;
            }
        }

        public class While
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                while (Interpreter.Eval(parameters[0], env))
                    Interpreter.Eval(parameters[1], env);
                return null;
            }
        }

        public class For
        {
            public static int[] nbParameters = new int[] { 3 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0] is Token tok && tok.type == TokenType.IDENTIFIER)
                {
                    if (env.IsDefine(tok.value))
                        Interpreter.ShowError($"Identifier not defined : {tok}");
                    else
                    {
                        if(parameters[1] is List<object> lists && lists.Count == 3 && lists[0] is Token t1 && t1.type == TokenType.INTEGER && lists[1] is Token t2 && t2.type == TokenType.INTEGER && lists[2] is Token t3 && t3.type == TokenType.INTEGER)
                        {
                            for(int i = Convert.ToInt32(t1.value); i < Convert.ToInt32(t2.value); i += Convert.ToInt32(t3.value)) {
                                env.variables[tok.value] = i;
                                Interpreter.Eval(parameters[2], env);
                            }
                        }
                        else
                            Interpreter.ShowError($"Wrong Type of argument. Provided : {parameters[1]} - Expected : List of 3 {TokenType.INTEGER} - Procedure : {typeof(For)}");
                    }
                }
                else
                    Interpreter.ShowError($"Wrong Type of argument. Provided : {parameters[0]} - Expected : {TokenType.IDENTIFIER} - Procedure : {typeof(For)}");
                return null;
            }
        }

        public class If
        {
            public static int[] nbParameters = new int[] { 3 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (Interpreter.Eval(parameters[0], env))
                    return Interpreter.Eval(parameters[1], env);
                else
                    return Interpreter.Eval(parameters[2], env);
            }
        }

        public class Del
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0] is Token tok && tok.type == TokenType.IDENTIFIER)
                {
                    if (!env.IsDefine(tok.value))
                        Interpreter.ShowError($"Identifier not defined : {tok}");
                    else
                        env.variables.Remove(tok.value);
                }
                else
                    Interpreter.ShowError($"Wrong Type of argument. Provided : {parameters[0]} - Expected : {TokenType.IDENTIFIER} - Procedure : {typeof(Del)}");
                return null;
            }
        }

        public class Def
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if(parameters[0] is Token tok && tok.type == TokenType.IDENTIFIER)
                    env.variables[tok.value] = Interpreter.Eval(parameters[1], env);
                else
                    Interpreter.ShowError($"Wrong Type of argument. Provided : {parameters} - Expected : {TokenType.IDENTIFIER} - Procedure : {typeof(Def)}");
                return null;
            }
        }

        public class Comment
        {
            public static int[] nbParameters = new int[] { };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters) => null;
        }
    }
}
