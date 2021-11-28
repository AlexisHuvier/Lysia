using System.Collections.Generic;

namespace Lysia.Functions
{
    class Dict
    {
        public class Create
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { "list" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) 
            {
                Dictionary<dynamic, dynamic> dict = new Dictionary<dynamic, dynamic>();
                for (int i = 0; i < parameters[0].Count; i++)
                    dict.Add(parameters[0][i], parameters[1][i]);
                return dict;
            }
        }

        public class Get
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "dict" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0].ContainsKey(parameters[1]))
                    return parameters[0][parameters[1]];
                Interpreter.ShowError($"Unknown Key. Key : {parameters[1]} - Dict : {Utils.Print.GetDict(parameters[0])}");
                return null;
            }
        }

        public class Set
        {
            public static int[] nbParameters = new int[] { 3 };
            public static string[][] typeParameters = new string[][] { new string[] { "dict" }, new string[] { }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0].ContainsKey(parameters[1]))
                    parameters[0][parameters[1]] = parameters[2];
                else
                    parameters[0].Add(parameters[1], parameters[2]);
                return null;
            }
        }

        public class HasKey
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "dict" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0].ContainsKey(parameters[1]);
        }

        public class HasValue
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "dict" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0].ContainsValue(parameters[1]);
        }

        public class Values
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "dict" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => new List<dynamic>(parameters[0].Values);
        }

        public class Keys
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "dict" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => new List<dynamic>(parameters[0].Keys);
        }
    }
}
