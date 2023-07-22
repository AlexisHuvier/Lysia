using System;

namespace Lysia.Core;

public class Error
{
    public static void ShowError(string message, Token.Token? token = null, bool stop = true)
    {
        Console.WriteLine($"Error : {message}");
        if(token != null)
            Console.WriteLine($"  Token : {token}");
        if(stop)
            Environment.Exit(1);
    }
}