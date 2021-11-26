using System.Collections.Generic;


namespace Lysia.Functions
{
    class Arithmetic
    {
        public class Add
        {
            public static int[] nbParameters = new int[] { };
            public static string[] typeParameters = new string[] { "int", "float", "string" };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) {
                if (parameters.Count == 0)
                    Interpreter.ShowError($"Wrong Number of arguments. Provided : {parameters.Count} - Expected : 1 or more - Procedure : {typeof(Add)}");
                dynamic retour = parameters[0];
                for (int i = 1; i < parameters.Count; i++)
                    retour += parameters[i];
                return retour;
            }
        }
        public class Sub
        {
            public static int[] nbParameters = new int[] { };
            public static string[] typeParameters = new string[] { "int", "float", "string" };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters.Count == 0)
                    Interpreter.ShowError($"Wrong Number of arguments. Provided : {parameters.Count} - Expected : 1 or more - Procedure : {typeof(Sub)}");
                else if (parameters.Count == 1)
                    return -parameters[1];
                dynamic retour = parameters[0];
                for (int i = 1; i < parameters.Count; i++)
                    retour -= parameters[i];
                return retour;
            }
        }
    }
}
