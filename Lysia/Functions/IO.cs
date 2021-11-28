using System;
using System.Collections.Generic;

namespace Lysia.Functions
{
    class IO
    {
        public class Input
        {
            public static int[] nbParameters = new int[] { };
            public static string[][] typeParameters = new string[][] { };
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
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters)
            {
                string txt = "";
                foreach(dynamic t in parameters)
                {
                    if (t is Dictionary<dynamic, dynamic> dict)
                    {
                        txt += $"{{";
                        foreach (KeyValuePair<dynamic, dynamic> kvp in dict)
                            txt += $"{kvp.Key} => {kvp.Value}, ";
                        if (dict.Count > 0)
                            txt = txt[..^2];
                        txt += $"}} ";
                    }
                    else if (t is List<dynamic> list)
                        txt += $"[{string.Join(", ", list)}] ";
                    else
                        txt += $"{t} ";
                }
                Console.WriteLine(txt);
                return null;
            }
        }
    }
}
