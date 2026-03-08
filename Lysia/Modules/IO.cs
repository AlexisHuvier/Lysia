using System;
using System.Collections.Generic;
using System.Text;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace Lysia.Modules;

[Docs("IO", "Provides functions for input and output")]
public static class Io
{
    [Docs("Display", "Prints the given values to the console")]
    [DocsExample("(io:display 42)", "42")]
    public class Display() : Function([], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;

            var builder = new StringBuilder();
            foreach (var value in values)
            {
                switch (value)
                {
                    case Dictionary<dynamic, dynamic> dict:
                    {
                        builder.Append('{');
                        foreach (var pair in dict)
                            builder.Append($"{pair.Key} => {pair.Value}, ");
                        if (dict.Count > 0)
                            builder.Remove(builder.Length - 2, 2);
                        builder.Append("} ");
                        break;
                    }
                    case List<dynamic> list:
                        builder.Append($"[{string.Join(", ", list)}]");
                        break;
                    default:
                        builder.Append($"{value}");
                        break;
                }
            }
            Console.WriteLine(builder.ToString());
            return null;
        }
    }

    [Docs("Input", "Reads a line from the console")]
    [DocsExample("(io:input)", "42")]
    public class Input() : Function([], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            Console.WriteLine(string.Join(" ", values));
            return Console.ReadLine();
        }
    }
    
    public static Dictionary<string, Function> GetImports() => new()
        {
            { "io:display", new Display() },
            { "io:input", new Input() }
        };
}