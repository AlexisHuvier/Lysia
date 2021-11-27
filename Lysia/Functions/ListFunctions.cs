using System.Collections.Generic;
using System.Linq;

namespace Lysia.Functions
{
    class ListFunctions
    {
        public class Create
        {
            public static int[] nbParameters = new int[] { };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters;
        }

        public class Join
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { "string" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => string.Join(parameters[1], parameters[0]);
        }

        public class First
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) 
            {
                if (parameters[0].Count == 0)
                    Interpreter.ShowError($"List is empty. List : [{string.Join(", ", parameters[0])}] - Proc : {typeof(First)}");
                return parameters[0][0];
            }
        }

        public class Last
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0].Count == 0)
                    Interpreter.ShowError($"List is empty. List : [{string.Join(", ", parameters[0])}] - Proc : {typeof(Last)}");
                return parameters[0][parameters[0].Count - 1];
            }
        }

        public class Get
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { "int" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) {
                if (parameters[1] < 0 || parameters[1] >= parameters[0].Count)
                    Interpreter.ShowError($"Index out of Bounds. List : [{string.Join(", ", parameters[0])}] - Index : {parameters[1]} - Proc : {typeof(Get)}");
                return parameters[0][parameters[1]];
            }
        }

        public class Len
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0].Count;
        }

        public class Append
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) 
            {
                parameters[0].Add(parameters[1]);
                return null;
            }
        }

        public class Remove
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0].Remove(parameters[1]);
        }

        public class RemoveAll
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => ((List<dynamic>)parameters[0]).RemoveAll(obj => obj.GetType() == parameters[1].GetType() && obj == parameters[1]);
        }

        public class RemoveAt
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { "int" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                parameters[0].RemoveAt(parameters[1]);
                return null;
            }
        }

        public class Insert
        {
            public static int[] nbParameters = new int[] { 3 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { "int" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                parameters[0].Insert(parameters[1], parameters[2]);
                return null;
            }
        }

        public class Replace
        {
            public static int[] nbParameters = new int[] { 3 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                List<dynamic> newList = new List<dynamic>();
                foreach(dynamic obj in parameters[0])
                {
                    if (obj.GetType() == parameters[1].GetType() && obj == parameters[1])
                        newList.Add(parameters[2]);
                    else
                        newList.Add(obj);
                }
                return newList;
            }
        }

        public class Reverse
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                parameters[0].Reverse();
                return null;
            }
        }

        public class Clear
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            { 
                parameters[0].Clear();
                return null;
            }
        }

        public class In
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "list" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => parameters[0].Contains(parameters[1]);
        }

        public class Range
        {
            public static int[] nbParameters = new int[] { 3 };
            public static string[][] typeParameters = new string[][] { new string[] { "int" }, new string[] { "int" }, new string[] { "int" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                List<dynamic> l = new List<dynamic>();
                for (int i = parameters[0]; i < parameters[1]; i += parameters[2])
                    l.Add(i);
                return l;
            }
        }

        public class Repeat
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "int" }, new string[] { } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => new List<dynamic>(Enumerable.Repeat<dynamic>(parameters[1], parameters[0]));
        }

        public class ForEach
        {
            public static int[] nbParameters = new int[] { 3 };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = false;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                if (parameters[0] is Token tok && tok.type == TokenType.IDENTIFIER)
                {
                    if (env.IsDefine(tok.value))
                        Interpreter.ShowError($"Identifier already defined : {tok}");
                    else
                    {
                        if(Interpreter.Eval(parameters[1], env) is List<dynamic> list)
                        {
                            foreach(dynamic i in list)
                            {
                                env.variables[tok.value] = i;
                                Interpreter.Eval(parameters[2], env);
                            }
                        }
                        else
                            Interpreter.ShowError($"Wrong Type of argument. Provided : {parameters[1]} - Expected : List - Procedure : {typeof(ForEach)}");
                    }
                }
                else
                    Interpreter.ShowError($"Wrong Type of argument. Provided : {parameters[0]} - Expected : {TokenType.IDENTIFIER} - Procedure : {typeof(ForEach)}");
                return null;
            }
        }
    }
}
