using System;
using System.Collections.Generic;
using System.Linq;


namespace Lysia.Utils
{
    class Print
    {
        public static void PrintEnv(Env env)
        {
            Console.WriteLine("=> Core Methods :");
            Console.WriteLine($"{string.Join(", ", env.core_methods.Select(a => $"{a.Key}: {a.Value}"))}");
            Console.WriteLine("=> Variables :");
            Console.WriteLine($"{string.Join(", ", env.variables.Select(a => $"{a.Key}: {a.Value}"))}");
        }

        public static void PrintObject(dynamic obj, int nb = 0)
        {
            if (obj is List<dynamic> list)
            {
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                foreach (object obj2 in list)
                    PrintObject(obj2, nb + 1);
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
            }
            else if (obj is Dictionary<string, dynamic> dict)
            {
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                foreach ((dynamic obj2, dynamic obj3) in dict)
                {
                    Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}{obj2} =>");
                    PrintObject(obj3, nb + 1);
                }
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
            }
            else if (obj is Dictionary<string, Type> dict2)
            {
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                foreach ((dynamic obj2, dynamic obj3) in dict2)
                {
                    Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}{obj2} =>");
                    PrintObject(obj3, nb + 1);
                }
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
            }
            else
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}{obj}");
        }
    }
}
