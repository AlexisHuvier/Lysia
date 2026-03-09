using System.Collections.Generic;
using System.Linq;
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

    [Docs("Range", "Creates a list of integers from start to end")]
    [DocsExample("(list:range 1 5)", "[1, 2, 3, 4]")]
    public class Range() : Function([2], [["int"], ["int"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            var start = values[0];
            var end = values[1];
            return ((IEnumerable<int>)Enumerable.Range(start, end - start)).Select(x => (dynamic)x).ToList();
        }
    }

    [Docs("Get", "Returns the element at the given index of a list")]
    [DocsExample("(list:get [1 2 3] 1)", "2")]
    public class Get() : Function([2], [["list"], ["int"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            var list = values[0];
            var index = values[1];
            if (index >= 0 && index < list.Count) return list[index];
            
            Error.ShowError("Index out of range", parameters[0]);
            return null;
        }
    }

    [Docs("Len", "Returns the length of a list")]
    [DocsExample("(list:len [1 2 3])", "3")]
    public class Len() : Function([1], [["list"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            var list = values[0];
            return list.Count;
        }
    }

    [Docs("Add", "Adds an element to the end of a list")]
    [DocsExample("(list:add [1 2] 3)", "[1, 2, 3]")]
    public class Add() : Function([2], [["list"], []], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            values[0].Add(values[1]);
            return values[0];
        }
    }

    [Docs("Remove", "Removes an element from a list by index")]
    [DocsExample("(list:remove [1 2 3] 1)", "[1, 3]")]
    public class Remove() : Function([2], [["list"], ["int"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            values[0].RemoveAt(values[1]);
            return values[0];
        }
    }

    [Docs("In", "Checks if an element is in a list")]
    [DocsExample("(list:in [1 2 3] 2)", "true")]
    public class In() : Function([2], [["list"], []], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0].Contains(values[1]);
        }
    }

    [Docs("Insert", "Inserts an element at a specific index in a list")]
    [DocsExample("(list:insert [1 2 3] 1 4)", "[1, 4, 2, 3]")]
    public class Insert() : Function([3], [["list"], ["int"], []], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            values[0].Insert(values[1], values[2]);
            return values[0];
        }
    }

    [Docs("Replace", "Replaces an element at a specific index in a list")]
    [DocsExample("(list:replace [1 2 3] 1 4)", "[1, 4, 3]")]
    public class Set() : Function([3], [["list"], ["int"], []], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            values[0][values[1]] = values[2];
            return values[0];
        }
    }

    [Docs("Clear", "Clears a list")]
    [DocsExample("(list:clear [1 2 3])", "[]")]
    public class Clear() : Function([1], [["list"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            values[0].Clear();
            return values[0];
        }
    }

    [Docs("AddList", "Adds two lists together")]
    [DocsExample("(list:+ [1 2] [3 4])", "[1, 2, 3, 4]")]
    public class AddList() : Function([2], [["list"], ["list"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            values[0].AddRange(values[1]);
            return values[0];
        }
    }
    
    public static Dictionary<string, Function> GetImports() => new()
    {
        { "list:create", new Create() },
        { "list:first", new First() },
        { "list:last", new Last() },
        { "list:range", new Range() },
        { "list:get", new Get() },
        { "list:len", new Len() },
        { "list:add", new Add() },
        { "list:remove", new Remove() },
        { "list:in", new In() },
        { "list:insert", new Insert() },
        { "list:set", new Set() },
        { "list:clear", new Clear() },
        { "list:+", new AddList() }
    };
}