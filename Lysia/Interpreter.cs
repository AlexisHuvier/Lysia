using System;
using System.Collections.Generic;

namespace Lysia
{
    class Interpreter
    {
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
                    return Convert.ToDecimal(token.value);
                else if (token.type == TokenType.IDENTIFIER)
                {
                    Type t = env.GetTypeOf(token.value);
                    if(t is null)
                    {
                        Console.WriteLine($"Unknown Identifier : {token}");
                        Environment.Exit(1);
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
                        if (tok.value == "#") { }
                        else
                        {
                            dynamic proc = Eval(tok, env);
                            List<dynamic> vals = new List<dynamic>();
                            for (int i = 1; i < list.Count; i++)
                                vals.Add(Eval(list[i], env));
                            if(proc != null)
                                return proc.GetMethod("Eval").Invoke(null, new object[] { vals });
                            else
                            {
                                Console.WriteLine($"Unknown Procedure : {tok}");
                                Environment.Exit(1);
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
