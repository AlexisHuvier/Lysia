using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Lysia
{
    class Interpreter
    {
        public static bool DEBUG = false;

        public static void ShowError(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }

        private static bool VerifType(string type, dynamic val)
        {
            if (val is int nb)
                return type == "int";
            else if (val is float nb2)
                return type == "float";
            else if (val is bool boolean)
                return type == "bool";
            else if (val is string txt)
                return type == "string";
            else
                return false;
        }

        public static dynamic Eval(dynamic exp, Env env = null)
        {
            if (env == null)
                env = Env.GetStandartEnv();

            if(exp is Token token)
            {
                if (token.type == TokenType.STRING)
                    return token.value;
                else if (token.type == TokenType.INTEGER)
                    return Convert.ToInt32(token.value);
                else if (token.type == TokenType.FLOAT)
                    return Convert.ToSingle(token.value, CultureInfo.InvariantCulture);
                else if (token.type == TokenType.IDENTIFIER)
                {
                    dynamic t = env.Get(token.value);
                    if(t is null)
                    {
                        if(DEBUG)
                        {
                            Utils.Print.PrintObject(env.core_methods);
                            Utils.Print.PrintObject(env.variables);
                        }
                        ShowError($"Unknown Identifier : {token}");

                    }
                    return t;
                }
            }
            else if(exp is List<dynamic> list)
            {
                if (list.Count == 0)
                    return null;
                else
                {
                    dynamic op = list[0];
                    if(op is List<dynamic>)
                    {
                        foreach(dynamic i in list)
                        {
                            if (i is List<dynamic> l3 && l3.Count >= 1 && l3[0].value == "ret")
                                return Eval(i, env);
                            Eval(i, env);
                        }
                        return null;
                    }
                    else if(op is Token tok && tok.type == TokenType.IDENTIFIER)
                    {
                        dynamic proced = Eval(tok, env);
                        if(proced is Utils.Procedure procedure)
                        {
                            List<dynamic> vals = new List<dynamic>();
                            for (int i = 1; i < list.Count; i++)
                                vals.Add(Eval(list[i], env));
                            return procedure.Eval(Env.FromEnv(env), vals);
                        }
                        else if (proced is Type proc)
                        {
                            int[] nbParameters = (int[])proc.GetField("nbParameters").GetValue(null);
                            string[] typeParameters = (string[])proc.GetField("typeParameters").GetValue(null);
                            bool evaluateParameters = (bool)proc.GetField("evaluateParameters").GetValue(null);
                            List<dynamic> vals = new List<dynamic>();

                            if (evaluateParameters)
                            {
                                for (int i = 1; i < list.Count; i++)
                                    vals.Add(Eval(list[i], env));
                            }
                            else
                                vals.AddRange(list.Skip(1));

                            if(nbParameters.Length != 0)
                            {
                                bool validate = false;
                                foreach(int nbParameter in nbParameters)
                                {
                                    if(nbParameter == vals.Count)
                                    {
                                        validate = true;
                                        break;
                                    }    
                                }
                                if(!validate)
                                    ShowError($"Wrong Number of arguments. Provided : {vals.Count} - Expected : {string.Join(", ", nbParameters)} - Procedure : {proc}");
                            }

                            if (typeParameters.Length != 0)
                            {
                                foreach (dynamic val in vals)
                                {
                                    bool validate = false;
                                    foreach (string typeParameter in typeParameters)
                                    {
                                        if (VerifType(typeParameter, val))
                                        {
                                            validate = true;
                                            break;
                                        }
                                    }
                                    if (!validate)
                                        ShowError($"Wrong Type of arguments. Provided : {string.Join(", ", vals.Select(val => val.GetType()))} - Expected : {string.Join(", ", typeParameters)} - Procedure : {proc}");
                                }
                            }
                            return proc.GetMethod("Eval").Invoke(null, new object[] { env, vals });
                        }
                        else
                            ShowError($"Unknown Procedure : {tok}");
                    }
                }
            }

            return null;
        }
    }
}
