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

        public class Greater
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0] > parameters[1];
        }

        public class GreaterOrEquals
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0] >= parameters[1];
        }

        public class Less
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0] < parameters[1];
        }

        public class LessOrEquals
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0] <= parameters[1];
        }

        public class And
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { "bool" };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0] && parameters[1];
        }

        public class Or
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[] typeParameters = new string[] { "bool" };
            public static bool evaluateParameters = true;

        }
    }
}
