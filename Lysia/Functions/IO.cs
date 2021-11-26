using System;
using System.Collections.Generic;

namespace Lysia.Functions
{
    class IO
    {
        public class Input
        {
            public static int[] nbParameters = new int[] { };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                Console.WriteLine(string.Join(" ", parameters));
                return Console.ReadLine();
            }
        }

        public class Display
        {
            public static int[] nbParameters = new int[] { };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                Console.WriteLine(string.Join(" ", parameters));
                return null;
            }
        }
    }
}
