using System.Collections.Generic;
using Lysia.Modules;
using Lysia.Objects;

namespace Lysia.Core;

public static class Imports
{
    private static readonly Dictionary<string, Dictionary<string, Function>> ImportsList = new()
    {
        {
            "io", new Dictionary<string, Function>
            {
                { "io:display", new IO.Display() },
                { "io:input", new IO.Input() }
            }
        },
        {
            "lysia", new Dictionary<string, Function>()
            {
                { "lysia:version", new Modules.Lysia.Version() },
                { "lysia:printenv", new Modules.Lysia.PrintEnv() },
                { "lysia:exit", new Modules.Lysia.Exit() }
            }
        }
    };
    
    public static bool IsDefined(string name) => ImportsList.ContainsKey(name);
    public static Dictionary<string, Function> Get(string import) => ImportsList[import];
}