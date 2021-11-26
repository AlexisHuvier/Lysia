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
                "IO", new Dictionary<string, Type>()
                {
                    { "display", typeof(IO.Display) },
                    { "input", typeof(IO.Input) }
                } 
            }    
            {
                "env", new Dictionary<string, Type>()
                {
                    { "env:exit", typeof(Functions.Environment.Exit) },
                    { "env:print", typeof(Functions.Environment.Print) }
                }
            }
        };

        public static bool IsDefined(string name) => imports.ContainsKey(name);
        public static Dictionary<string, Type> Get(string import) => imports[import];
    }
}
