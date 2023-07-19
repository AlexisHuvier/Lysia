using System;

namespace Lysia.Core;

public class Error
{
    public static void ShowError(string name, string message, Token.Token? token = null, bool stop = true)
    {
        Console.WriteLine($"Error : {name}");
        Console.WriteLine($"  Message : {message}");
        if(token != null)
            Console.WriteLine($"  Token : {token}");
        if(stop)
            Environment.Exit(1);
    }
}