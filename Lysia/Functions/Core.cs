using System.Collections.Generic;


namespace Lysia.Functions
{
    class Core
    {
        public class Display
        {
            public static int nbParameters = -1;
            public static string typeParameters = "*";

            public static dynamic Eval(List<dynamic> parameters)
            {
                string text = "";
                foreach (dynamic obj in parameters)
                    text += obj.ToString() + " ";
                if (text.Length >= 1)
                    text = text[..^1];
                System.Console.WriteLine(text);
                return null;
            }
        }
    }
}
