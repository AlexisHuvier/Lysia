namespace LysiaExamples;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=============");
        Console.WriteLine("BASIC EXAMPLE");
        Console.WriteLine("=============");
        Lysia.Program.RunFile(new[] { "Examples/basic" });
    }
}