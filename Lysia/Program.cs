using System.IO;
using Lysia.Core;

namespace Lysia;

public static class Program
{
    public static void RunFile(string[] args)
    {
        string file;
        var debug = false;
        
        if (args.Length == 1)
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

        var prog = File.ReadAllText($"{file}.lysia");
        var obj = Parser.Parse(Lexer.Tokenize(prog));
        if (debug)
        {
            Interpreter.DEBUG = true;
            Utils.Print.PrintObject(obj);
            System.Console.WriteLine();
        }
        try
        {
            Interpreter.Eval(obj);
        }
        catch (System.Exception e)
        {
            if (Interpreter.DEBUG)
                System.Console.WriteLine(e);
        }
    }
    
    private static void Main(string[] args)
    {
        if (args.Length != 1 && args.Length != 2)
        {
            System.Console.Write("Lysia > ");
            var env = Env.GetStandardEnv();
            while(System.Console.ReadLine() is { } result)
            {
                if (result == "(quit)")
                    break;
                if (result == "(debug)")
                {
                    Interpreter.DEBUG = !Interpreter.DEBUG;
                    System.Console.Write("Lysia > ");
                    continue;
                }
                
                try
                {
                    Interpreter.Eval(Parser.Parse(Lexer.Tokenize(result)), env);
                }
                catch (System.Exception e)
                {
                    if (Interpreter.DEBUG)
                        System.Console.WriteLine(e);
                }
                System.Console.Write("Lysia > ");
            }
            System.Console.WriteLine("Bye.");
            return;
        }
        
        RunFile(args);
    }
}