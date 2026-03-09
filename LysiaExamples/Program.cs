Console.WriteLine("Welcome to Lysia Examples!");
Console.WriteLine();
Console.WriteLine($"List of current examples: {string.Join(", ", Directory.GetFiles("Examples").Select(Path.GetFileNameWithoutExtension))}");
Console.WriteLine();
while (true)
{
    Console.WriteLine("Which example do you want to run? (exit to quit - examples to list examples)");
    var example = Console.ReadLine();
    if (example == "exit")
    {
        Console.WriteLine("Exiting Lysia Examples...");
        break;
    }

    if (example == "examples")
    {
        Console.WriteLine($"List of current examples: {string.Join(", ", Directory.GetFiles("Examples").Select(Path.GetFileNameWithoutExtension))}");
        continue;
    }
    if (!File.Exists($"Examples/{example}.lysia"))
    {
        Console.WriteLine($"Unknown example : {example}");
        continue;
    }
    
    Lysia.Program.RunFile([$"Examples/{example}"]);
    Console.WriteLine();
}