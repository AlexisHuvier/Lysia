using System.Collections.Generic;


namespace Lysia.Functions
{
    class Environment
    {
        public class Exit
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[] typeParameters = new string[] { "int" };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                System.Environment.Exit(parameters[0]);
                return null;
            }
        }

        public class Print
        {
            public static int[] nbParameters = new int[] { 0 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                Utils.Print.PrintEnv(env);
                return null;
            }
        }
    }
}
