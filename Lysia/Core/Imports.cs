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
                { "io:display", new Io.Display() },
                { "io:input", new Io.Input() }
            }
        },
        {
            "io:file", new Dictionary<string, Function>
            {
                { "io:file:create", new IoFile.Create() },
                { "io:file:delete", new IoFile.Delete() },
                { "io:file:exists", new IoFile.Exists() },
                { "io:file:read", new IoFile.Read() },
                { "io:file:readlines", new IoFile.ReadLines() },
                { "io:file:write", new IoFile.Write() },
                { "io:file:writelines", new IoFile.WriteLines() }
            }
        },
        {
            "lysia", new Dictionary<string, Function>
            {
                { "lysia:version", new Modules.Lysia.Version() },
                { "lysia:printenv", new Modules.Lysia.PrintEnv() },
                { "lysia:exit", new Modules.Lysia.Exit() }
            }
        }
    };
    
    public static bool IsDefined(string name) => ImportsList.ContainsKey(name);
    public static Dictionary<string, Function> Get(string import) => ImportsList[import];
    public static Dictionary<string, Dictionary<string, Function>> Get() => ImportsList;
}
