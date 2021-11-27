using System.Collections.Generic;
using System;
using Lysia.Functions;

namespace Lysia.Utils
{
    public class Imports
    {
        public static Dictionary<string, Dictionary<string, Type>> imports = new Dictionary<string, Dictionary<string, Type>>()
        {
            { 
                "io", new Dictionary<string, Type>()
                {
                    { "io:display", typeof(IO.Display) },
                    { "io:input", typeof(IO.Input) }
                }
            },
            {
                "env", new Dictionary<string, Type>()
                {
                    { "env:exit", typeof(Functions.Environment.Exit) },
                    { "env:print", typeof(Functions.Environment.Print) }
                }
            },
            {
                "list", new Dictionary<string, Type>()
                {
                    { "list", typeof(ListFunctions.Create) }
                }
            }
        };

        public static bool IsDefined(string name) => imports.ContainsKey(name);
        public static Dictionary<string, Type> Get(string import) => imports[import];
    }
}
