using System.Collections.Generic;
using Lysia.Modules.CoreModules;
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

        env.AddCoreMethods(new[]
        {
            "cast", "#", "def", "del", "for", "func", "import", "ret", "typeof",
            "+", "/", "%", "*", "-",
            "&&", "==", ">", ">=", "<", "<=", "!=", "||"
        }, new Function[]
        {
            new Modules.CoreModules.Core.Cast(), new Modules.CoreModules.Core.Comment(),
            new Modules.CoreModules.Core.Def(), new Modules.CoreModules.Core.Del(),
            new Modules.CoreModules.Core.For(), new Modules.CoreModules.Core.Func(),
            new Modules.CoreModules.Core.Import(), new Modules.CoreModules.Core.Ret(),
            new Modules.CoreModules.Core.TypeOf(),
            new Arithmetic.Add(), new Arithmetic.Div(), new Arithmetic.Mod(), new Arithmetic.Mul(), new Arithmetic.Sub(),
            new Logic.And(), new Logic.Equals(), new Logic.Greater(), new Logic.GreaterOrEquals(), new Logic.Less(), 
            new Logic.LessOrEquals(), new Logic.NotEquals(), new Logic.Or()
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