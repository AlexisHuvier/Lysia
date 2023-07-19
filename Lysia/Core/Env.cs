using System.Collections.Generic;
using Lysia.Objects;

namespace Lysia.Core;

public class Env
{
    public Dictionary<string, Function> CoreMethods = new();
    public Dictionary<string, dynamic> Variables = new();

    public bool IsDefine(string name) => CoreMethods.ContainsKey(name) || Variables.ContainsKey(name);

    public dynamic? Get(string name)
    {
        if (CoreMethods.TryGetValue(name, out var func))
            return func;
        
        return Variables.TryGetValue(name, out var var) ? var : null;
    }

    public void AddCoreMethods(string[] names, Function[] functions)
    {
        for(var i = 0; i < names.Length; i++)
            CoreMethods.Add(names[i], functions[i]);
    }

    public void AddVariables(string[] names, dynamic[] values)
    {
        for(var i = 0; i < names.Length; i++)
            Variables.Add(names[i], values[i]);
    }

    public static Env FromEnv(Env env)
    {
        return new Env
        {
            CoreMethods = new Dictionary<string, Function>(env.CoreMethods),
            Variables = new Dictionary<string, dynamic>(env.Variables)
        };
    }
    
    public static Env GetStandardEnv()
    {
        var env = new Env();
        
        env.AddCoreMethods(new []
        {
            "#", "import"
        }, new Function[]
        {
            new Modules.Core.Comment(), new Modules.Core.Import()
        });
        
        env.AddVariables(new []
        {
            "true", "false"
        }, new dynamic[]
        {
            true, false
        });

        return env;
    }
}