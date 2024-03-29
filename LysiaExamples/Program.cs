﻿namespace LysiaExamples;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=============");
        Console.WriteLine("BASIC EXAMPLE");
        Console.WriteLine("=============");
        Lysia.Program.RunFile(new[] { "Examples/basic" });
        Console.WriteLine();
        Console.WriteLine("=============");
        Console.WriteLine("FOR EXAMPLE");
        Console.WriteLine("=============");
        Lysia.Program.RunFile(new[] { "Examples/for" });
        Console.WriteLine();
        Console.WriteLine("=============");
        Console.WriteLine("FUNC EXAMPLE");
        Console.WriteLine("=============");
        Lysia.Program.RunFile(new[] { "Examples/func" });
        Console.WriteLine();
        Console.WriteLine("=============");
        Console.WriteLine("FILE EXAMPLE");
        Console.WriteLine("=============");
        Lysia.Program.RunFile(new[] { "Examples/file" });
        Console.WriteLine();
        Console.WriteLine("=============");
        Console.WriteLine("EXTERN MODULE EXAMPLE");
        Console.WriteLine("=============");
        Lysia.Program.RunFile(new[] { "Examples/externModule" });
    }
}