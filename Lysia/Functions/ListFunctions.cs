using System.Collections.Generic;

namespace Lysia.Functions
{
    class ListFunctions
    {
        public class Create
        {
            public static int[] nbParameters = new int[] { };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters;
        }
    }
}
