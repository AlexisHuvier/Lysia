using System.Collections.Generic;

namespace Lysia.Functions
{
    class Logic
    {
        public new class Equals
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0] == parameters[1];
        }

        public class NotEquals
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0] != parameters[1];
        }
    }
}
