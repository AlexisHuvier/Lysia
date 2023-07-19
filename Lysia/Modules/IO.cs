using System;
using System.Collections.Generic;
using System.Text;
using Lysia.Core;
using Lysia.Objects;

namespace Lysia.Modules;

public class IO
{
    public class Display: Function
    {
        public Display() : base(Array.Empty<int>(), Array.Empty<string[]>(), true)
        { }

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
}