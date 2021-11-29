using System.IO;
using System.Collections.Generic;

namespace Lysia.Functions
{
    class Path
    {
        public class Read
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "string" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => File.ReadAllText(parameters[0]);
        }

        public class ReadLines
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "string" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => new List<string>(File.ReadAllLines(parameters[0]));
        }

        public class Write
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "string" }, new string[] { "string" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                File.WriteAllText(parameters[0], parameters[1]);
                return null;
            }
        }

        public class WriteLines
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "string" }, new string[] { "list" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                File.WriteAllLines(parameters[0], parameters[1]);
                return null;
            }
        }

        public class Exists
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "string" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => File.Exists(parameters[0]);
        }

        public class Create
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "string" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                File.Create(parameters[0]);
                return null;
            }
        }

        public class Delete
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "string" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                File.Delete(parameters[0]);
                return null;
            }
        }
    }
}
