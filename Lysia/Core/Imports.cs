using System;
using System.Collections.Generic;
using Lysia.Modules.StandardModules;

namespace Lysia.Core;

public static class Imports
{
    private static readonly Dictionary<string, Type> ImportsList = new()
    {
        { "io", typeof(Io) },
        { "io:file", typeof(IoFile) },
        { "lysia", typeof(Modules.StandardModules.Lysia) },
        { "list", typeof(LysiaList) },
        { "dict", typeof(Dict) }
    };
    
    public static bool IsDefined(string name) => ImportsList.ContainsKey(name);
    public static Type Get(string import) => ImportsList[import];
    public static Dictionary<string, Type> Get() => ImportsList;
}
