namespace Lysia
{
    class Program
    {
        static bool DEBUG = true;

        static void Main(string[] args)
        {

            string prog = System.IO.File.ReadAllText("prog.lysia");
            dynamic obj = Parser.Parse(Lexer.Tokenize(prog));
            if (DEBUG)
            {
                Utils.PrintObject(obj);
                System.Console.WriteLine();
            }
            Interpreter.Eval(obj);

        }
    }
}
