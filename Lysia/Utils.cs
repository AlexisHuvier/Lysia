using System;
using System.Collections.Generic;
using System.Linq;


namespace Lysia
{
    class Utils
    {
        public static void PrintObject(object obj, int nb = 0)
        {
            if (obj is List<object> list)
            {
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
                foreach (object obj2 in list)
                    PrintObject(obj2, nb + 1);
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}===");
            }
            else
                Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", nb))}{obj}");
        }
    }
}
