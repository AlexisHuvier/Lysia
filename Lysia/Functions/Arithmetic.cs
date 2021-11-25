using System.Collections.Generic;


namespace Lysia.Functions
{
    class Arithmetic
    {
        public class Add
        {
            public static int nbParameters = 2;
            public static string typeParameters = "int|float|string";

            public static dynamic Eval(List<dynamic> parameters) => parameters[0] + parameters[1];
        }
    }
}
