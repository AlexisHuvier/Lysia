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
                    { "env:print", typeof(Functions.Environment.Print) },
                    { "env:version", typeof(Functions.Environment.Version) }
                }
            },
            {
                "rand", new Dictionary<string, Type>()
                {
                    { "rand:randint", typeof(Rand.Randint) },
                    { "rand:choice", typeof(Rand.Choice) }
                }
            },
            {
                "path", new Dictionary<string, Type>()
                {
                    { "path:read", typeof(Path.Read) },
                    { "path:readlines", typeof(Path.ReadLines) },
                    { "path:write", typeof(Path.Write) },
                    { "path:writelines", typeof(Path.WriteLines) },
                    { "path:exists", typeof(Path.Exists) },
                    { "path:create", typeof(Path.Create) },
                    { "path:delete", typeof(Path.Delete) }
                }
            },
            {
                "dict", new Dictionary<string, Type>()
                {
                    { "dict", typeof(Dict.Create) },
                    { "dict:haskey", typeof(Dict.HasKey) },
                    { "dict:hasvalue", typeof(Dict.HasValue) },
                    { "dict:get", typeof(Dict.Get) },
                    { "dict:set", typeof(Dict.Set) },
                    { "dict:values", typeof(Dict.Values) },
                    { "dict:keys", typeof(Dict.Keys) }
                }
            },
            {
                "math", new Dictionary<string, Type>()
                {
                    { "math:pi", typeof(Maths.Pi) },
                    { "math:e", typeof(Maths.E) },
                    { "math:fib", typeof(Maths.Fib) },
                    { "math:min", typeof(Maths.Min) },
                    { "math:max", typeof(Maths.Max) },
                    { "math:pow", typeof(Maths.Pow) },
                    { "math:sqrt", typeof(Maths.Sqrt) },
                    { "math:abs", typeof(Maths.Abs) },
                    { "math:ceil", typeof(Maths.Ceil) },
                    { "math:acos", typeof(Maths.Acos) },
                    { "math:acosh", typeof(Maths.Acosh) },
                    { "math:asin", typeof(Maths.Asin) },
                    { "math:asinh", typeof(Maths.Asinh) },
                    { "math:atan", typeof(Maths.Atan) },
                    { "math:atan2", typeof(Maths.Atan2) },
                    { "math:atanh", typeof(Maths.Atanh) },
                    { "math:cos", typeof(Maths.Cos) },
                    { "math:cosh", typeof(Maths.Cosh) },
                    { "math:sin", typeof(Maths.Sin) },
                    { "math:sinh", typeof(Maths.Sinh) },
                    { "math:tan", typeof(Maths.Tan) },
                    { "math:tanh", typeof(Maths.Tanh) }
                }
            },
            {
                "list", new Dictionary<string, Type>()
                {
                    { "list", typeof(ListFunctions.Create) },
                    { "list:join", typeof(ListFunctions.Join) },
                    { "list:first", typeof(ListFunctions.First) },
                    { "list:last", typeof(ListFunctions.Last) },
                    { "list:get", typeof(ListFunctions.Get) },
                    { "list:len", typeof(ListFunctions.Len) },
                    { "list:append", typeof(ListFunctions.Append) },
                    { "list:remove", typeof(ListFunctions.Remove) },
                    { "list:removeall", typeof(ListFunctions.RemoveAll) },
                    { "list:removeat", typeof(ListFunctions.RemoveAt) },
                    { "list:insert", typeof(ListFunctions.Insert) },
                    { "list:replace", typeof(ListFunctions.Replace) },
                    { "list:reverse", typeof(ListFunctions.Reverse) },
                    { "list:clear", typeof(ListFunctions.Clear) },
                    { "list:in", typeof(ListFunctions.In) },
                    { "list:foreach", typeof(ListFunctions.ForEach) },
                    { "list:range", typeof(ListFunctions.Range) },
                    { "list:repeat", typeof(ListFunctions.Repeat) }

                }
            }
        };

        public static bool IsDefined(string name) => imports.ContainsKey(name);
        public static Dictionary<string, Type> Get(string import) => imports[import];
    }
}
