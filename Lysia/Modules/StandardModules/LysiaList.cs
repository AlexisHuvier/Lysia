using System.Collections.Generic;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace Lysia.Modules.StandardModules;

[Docs("List", "Provides functions for list operations")]
public class LysiaList
{
    
    [Docs("Create", "Creates a new list")]
    [DocsExample("(list:create 1 2 3)", "[1, 2, 3]")]
    public class Create() : Function([], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            return (List<dynamic>)base.Eval(env, parameters)!;
        }
    }

    [Docs("First", "Returns the first element of a list")]
    [DocsExample("(list:first [1 2 3])", "1")]
    public class First() : Function([1], [["list"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0][0];
        }
    }

    [Docs("Last", "Returns the last element of a list")]
    [DocsExample("(list:last [1 2 3])", "3")]
    public class Last() : Function([1], [["list"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0][values[0].Count - 1];
        }
    }
    
    public static Dictionary<string, Function> GetImports() => new()
    {
        { "list:create", new Create() },
        { "list:first", new First() },
        { "list:last", new Last() },
    };
}