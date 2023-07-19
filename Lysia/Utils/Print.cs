using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lysia.Core;

namespace Lysia.Utils;

public static class Print
{
     public static string GetDict(Dictionary<dynamic, dynamic> dict)
    {
        var txt = new StringBuilder("{");
        foreach (var kvp in dict)
            txt.Append($"{kvp.Key} => {kvp.Value}, ");
        if (dict.Count > 0)
            txt.Remove(txt.Length - 2, 2);
        txt.Append('}');
        return txt.ToString();
    }

    public static void PrintEnv(Env env)
    {
        Console.WriteLine("=> Core Methods :");
        Console.WriteLine($"{string.Join(", ", env.CoreMethods.Select(a => $"{a.Key}: {a.Value}"))}");
        Console.WriteLine("=> Variables :");
        Console.WriteLine($"{string.Join(", ", env.Variables.Select(a => $"{a.Key}: {a.Value}"))}");
    }

    public static void PrintObject(dynamic obj, int nb = 0)
    {
        switch (obj)
        {
            case List<dynamic> list:
            {
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                foreach (object obj2 in list)
                    PrintObject(obj2, nb + 1);
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                break;
            }
            case Dictionary<string, dynamic> dict:
            {
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                foreach ((dynamic obj2, dynamic obj3) in dict)
                {
                    Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}{obj2} =>");
                    PrintObject(obj3, nb + 1);
                }
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                break;
            }
            case Dictionary<string, Type> dict2:
            {
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                foreach ((dynamic obj2, dynamic obj3) in dict2)
                {
                    Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}{obj2} =>");
                    PrintObject(obj3, nb + 1);
                }
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                break;
            }
            default:
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}{obj}");
                break;
        }
    }
}