using System;
using System.Collections.Generic;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace Lysia.Modules.StandardModules;

[Docs("Lysia", "Main module for Lysia")]
public static class Lysia
{
    [Docs("Exit", "Exits the program with the given status code")]
    [DocsExample("(lysia:exit 0)", "")]
    public class Exit() : Function([1], [["int"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            Environment.Exit(values[0]);
            return null;
        }
    }

    [Docs("PrintEnv", "Prints the current environment")]
    [DocsExample("(lysia:printenv)", "")]
    public class PrintEnv() : Function([0], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            Print.PrintEnv(env);
            return null;
        }
    }
    
    [Docs("Version", "Returns the current version of Lysia")]
    [DocsExample("(lysia:version)", "1.0.0")]
    public class Version() : Function([0], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters) => "1.0.0";
    }
    
    public static Dictionary<string, Function> GetImports() => new()
    {
        { "lysia:version", new Version() },
        { "lysia:printenv", new PrintEnv() },
        { "lysia:exit", new Exit() }
    };
}