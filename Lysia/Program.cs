using System.IO;


namespace Lysia
{
    class Program
    {
        static void Main(string[] args)
        {
            string file;
            bool debug = false;

            if (args.Length != 1 && args.Length != 2)
            {
                System.Console.WriteLine("Lysia.exe [-d] <lysia file>");
                return;
            }
            else if (args.Length == 1)
            {
                if (File.Exists($"{args[0]}.lysia"))
                    file = args[0];
                else
                {
                    System.Console.WriteLine($"Unknown File : {args[0]}");
                    return;
                }
            }
            else
            {
                if(args[0] == "-d")
                {
                    debug = true;
                    if (File.Exists($"{args[1]}.lysia"))
                        file = args[1];
                    else
                    {
                        System.Console.WriteLine($"Unknown File : {args[1]}");
                        return;
                    }
                }
                else
                {
                    System.Console.WriteLine($"Unkown Argument : {args[0]}");
                    return;
                }
            }

            string prog = File.ReadAllText($"{file}.lysia");
            dynamic obj = Parser.Parse(Lexer.Tokenize(prog));
            if (debug)
            {
                Interpreter.DEBUG = true;
                Print.PrintObject(obj);
                System.Console.WriteLine();
            }
            Interpreter.Eval(obj);

        }
    }
}
