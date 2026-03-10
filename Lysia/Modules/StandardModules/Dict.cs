using System.Collections.Generic;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace Lysia.Modules.StandardModules;

[Docs("Dict", "Provides functions for dictionary operations")]
public static class Dict
{
    [Docs("Create", "Creates a new dict")]
    [DocsExample("(dict:create (list:create 1 2 3) (list:create 1 1 1))", "{ 1 => 1, 2 => 1, 3 => 1 }")]
    public class Create() : Function([2], [["list"], ["list"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            var result = new Dictionary<dynamic, dynamic>();
            for(var i = 0; i < values[0].Count; i++)
                result.Add(values[0][i], values[1][i]);
            
            return result;
        }
    }

    [Docs("Get", "Gets the value of a key in a dict")]
    [DocsExample("(dict:get (dict:create (list:create 1 2 3) (list:create 1 1 1)) 2)", "1")]
    public class Get() : Function([2], [["dict"], []], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0][values[1]];
        }
    }

    [Docs("Set", "Sets the value of a key in a dict")]
    [DocsExample("(dict:set (dict:create (list:create 1 2 3) (list:create 1 1 1)) 2 3)", "{ 1 => 1, 2 => 3, 3 => 1 }")]
    public class Set() : Function([3], [["dict"], [], []], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            values[0][values[1]] = values[2];
            return values[0];
        }
    }

    [Docs("HasKey", "Checks if a dict has a key")]
    [DocsExample("(dict:has-key (dict:create (list:create 1 2 3) (list:create 1 1 1)) 2)", "true")]
    public class HasKey() : Function([2], [["dict"], []], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0].ContainsKey(values[1]);
        }
    }

    [Docs("HasValue", "Checks if a dict has a value")]
    [DocsExample("(dict:has-value (dict:create (list:create 1 2 3) (list:create 1 1 1)) 1)", "true")]
    public class HasValue() : Function([2], [["dict"], []], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0].ContainsValue(values[1]);
        }
    }
    
    [Docs("Keys", "Gets the keys of a dict")]
    [DocsExample("(dict:keys (dict:create (list:create 1 2 3) (list:create 1 1 1)))", "[1, 2, 3]")]
    public class Keys() : Function([1], [["dict"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            var keys = new List<dynamic>();
            foreach (var key in values[0].Keys)
                keys.Add(key);
            return keys;
        }
    }
    
    [Docs("Values", "Gets the values of a dict")]
    [DocsExample("(dict:values (dict:create (list:create 1 2 3) (list:create 1 1 1)))", "[1, 1, 1]")]
    public class Values() : Function([1], [["dict"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            var valuesList = new List<dynamic>();
            foreach (var value in values[0].Values)
                valuesList.Add(value);
            return valuesList;
        }
    }
    
    public static Dictionary<string, Function> GetImports() => new()
    {
        {"dict:create", new Create()},
        {"dict:get", new Get()},
        {"dict:set", new Set()},
        {"dict:haskey", new HasKey()},
        {"dict:hasvalue", new HasValue()},
        {"dict:keys", new Keys()},
        {"dict:values", new Values()}
    };
}