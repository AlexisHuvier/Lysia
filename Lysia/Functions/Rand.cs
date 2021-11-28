using System;
using System.Collections.Generic;


namespace Lysia.Functions
{
    class Rand
    {
        private static Random rand = new Random();

        public class Randint
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "int" }, new string[] { "int" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => rand.Next(parameters[0], parameters[1]);
        }
        public class Choice
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0][rand.Next(parameters[0].Count)];
        }
    }
}
