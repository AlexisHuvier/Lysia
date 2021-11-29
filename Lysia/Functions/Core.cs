using System.Collections.Generic;
using System;
using System.IO;
using Lysia.Utils;


namespace Lysia.Functions
{
    class Core
    {
        public class TypeOf
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0] is Dictionary<dynamic, dynamic>)
                    return "dict";
                else if (parameters[0] is List<dynamic>)
                    return "list";
                else if (parameters[0] is int)
                    return "int";
                else if (parameters[0] is float)
                    return "float";
                else if (parameters[0] is bool)
                    return "bool";
                else if (parameters[0] is string)
                    return "string";
                else
                    return parameters[0].GetType();
            }
        }

        public class Cast
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                dynamic value = Interpreter.Eval(parameters[1], env);
                if(parameters[0] is Token tok && tok.type == TokenType.IDENTIFIER)
                {
                    if(parameters[0].value == "int")
                    {
                        try
                        {
                            return Convert.ToInt32(value);
                        }
                        catch (FormatException)
                        {
                            Interpreter.ShowError($"Wrong Cast. Provided : {value} ({value.GetType()}) - Expected : int - Procedure : {typeof(Cast)}");
                        }
                    }
                    else if(parameters[0].value == "float")
                    {
                        try
                        {
                            return Convert.ToSingle(value);
                        }
                        catch (FormatException)
                        {
                            Interpreter.ShowError($"Wrong Cast. Provided : {value} ({value.GetType()}) - Expected : float - Procedure : {typeof(Cast)}");
                        }
                    }
                    else if(parameters[0].value == "string")
                    {
                        try
                        {
                            return Convert.ToString(value);
                        }
                        catch (FormatException)
                        {
                            Interpreter.ShowError($"Wrong Cast. Provided : {value} ({value.GetType()}) - Expected : string - Procedure : {typeof(Cast)}");
                        }
                    }
                    else if (parameters[0].value == "bool")
                    {
                        try
                        {
                            return Convert.ToBoolean(value);
                        }
                        catch (FormatException)
                        {
                            Interpreter.ShowError($"Wrong Cast. Provided : {value} ({value.GetType()}) - Expected : bool - Procedure : {typeof(Cast)}");
                        }
                    }
                    else
                        Interpreter.ShowError($"Wrong Type. Provided : {parameters[0].value} - Expected : int, string, float or bool - Procedure : {typeof(Cast)}");
                }
                else
                    Interpreter.ShowError($"Wrong Type of argument. Provided : {parameters[0]} - Expected : int, string, float or bool - Procedure : {typeof(Cast)}");
                return null;
            }
        }

        public class Ret
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0];
        }

        public class Func
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters) => new Procedure(parameters[0], parameters[1]);
        }

        public class Import
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0] is Token tok && tok.type == TokenType.IDENTIFIER)
                {
                    string import = tok.value;
                    if (Imports.IsDefined(import))
                    {
                        foreach (KeyValuePair<string, Type> pair in Imports.Get(import))
                            env.core_methods.Add(pair.Key, pair.Value);
                    }
                    else if (File.Exists(import) && System.IO.Path.GetExtension(import) == ".lysia")
                        Interpreter.Eval(Parser.Parse(Lexer.Tokenize(File.ReadAllText(import))), env);
                    else
                        Interpreter.ShowError($"Unknown Import : {import}");
                }
                else
                    Interpreter.ShowError($"Wrong Type of argument. Provided : {parameters[0]} - Expected : Identifier - Procedure : {typeof(Import)}");

                return null;
            }
        }

        public class While
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { };
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
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0] is Token tok && tok.type == TokenType.IDENTIFIER)
                {
                    if (env.IsDefine(tok.value))
                        Interpreter.ShowError($"Identifier already defined : {tok}");
                    else
                    {
                        if(parameters[1] is List<object> lists && lists.Count == 3)
                        {
                            int[] ints = new int[] { 0, 0, 0 };
                            for(int i = 0; i < 3; i++)
                            {
                                dynamic o = Interpreter.Eval(lists[i], env);
                                if (o is int integer)
                                    ints[i] = integer;
                                else
                                    Interpreter.ShowError($"Wrong Type of argument. Provided : {o} ({lists[i]}) - Expected : Integer - Procedure : {typeof(For)}");
                            }

                            for(int i = ints[0]; i < ints[1]; i += ints[2]) {
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
            public static string[][] typeParameters = new string[][] { };
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
            public static string[][] typeParameters = new string[][] { };
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
            public static string[][] typeParameters = new string[][] { };
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
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters) => null;
        }
    }
}
