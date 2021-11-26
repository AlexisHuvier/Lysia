using System.Collections.Generic;

namespace Lysia.Utils
{
    class Procedure
    {
        public List<string> parms;
        public dynamic body;

        public Procedure(dynamic parms, dynamic body)
        {
            if (parms is List<object> list)
            {
                this.parms = new List<string>();
                foreach (object obj in list)
                {
                    if (obj is Token tok && tok.type == TokenType.IDENTIFIER)
                        this.parms.Add(tok.value);
                    else
                        Interpreter.ShowError($"Wrong Type of Argument. Provided : {obj} - Expected : Identifier");
                }

                this.body = body;
            }
            else
                Interpreter.ShowError($"Wrong Type of Argument. Provided : {parms} - Expected : List of Identifiers");
        }

        public dynamic Eval(Env env, List<dynamic> parameters)
        {
            if (parameters.Count != parms.Count)
                Interpreter.ShowError($"Wrong Number of Arguments. Provided : {parameters.Count} - Expected : {parms.Count}");
            for (int i = 0; i < parms.Count; i++)
            {
                if (!env.variables.TryAdd(parms[i], parameters[i]))
                    env.variables[parms[i]] = parameters[i];
            }
            return Interpreter.Eval(body, env);
        }
    }
}
