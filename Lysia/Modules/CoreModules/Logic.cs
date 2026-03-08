using System;
using System.Collections.Generic;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace Lysia.Modules.CoreModules;

public static class Logic
{
    [Docs("And", "Returns true if both values are true")]
    [DocsExample("(&& true true)", "true")]
    public class And() : Function([2], [["bool"], ["bool"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] && values[1];
        }
    }
    
    [Docs("Equals", "Returns true if both values are equal")]
    [DocsExample("(== 42 42)", "true")]
    public new class Equals() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] == values[1];
        }
    }
    
    [Docs("Greater", "Returns true if the first value is greater than the second")]
    [DocsExample("(> 42 41)", "true")]
    public class Greater() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] > values[1];
        }
    }
    
    [Docs("GreaterOrEquals", "Returns true if the first value is greater than or equal to the second")]
    [DocsExample("(>= 42 42)", "true")]
    public class GreaterOrEquals() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] >= values[1];
        }
    }
    
    [Docs("Less", "Returns true if the first value is less than the second")]
    [DocsExample("(< 42 43)", "true")]
    public class Less() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] < values[1];
        }
    }
    
    [Docs("LessOrEquals", "Returns true if the first value is less than or equal to the second")]
    [DocsExample("(<= 42 42)", "true")]
    public class LessOrEquals() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] <= values[1];
        }
    }
    
    [Docs("NotEquals", "Returns true if the first value is not equal to the second")]
    [DocsExample("(!= 42 43)", "true")]
    public class NotEquals() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] != values[1];
        }
    }
    
    [Docs("Or", "Returns true if either value is true")]
    [DocsExample("(|| true false)", "true")]
    public class Or() : Function([2], [["bool"], ["bool"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] || values[1];
        }
    }

    [Docs("Not", "Returns the opposite of the value")]
    [DocsExample("(! true)", "false")]
    public class Not() : Function([1], [["bool"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var value = (List<dynamic>)base.Eval(env, parameters)!;
            return !value[0];
        }
    }
}