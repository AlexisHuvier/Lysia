using System;
using System.Collections.Generic;
using Lysia.Core;
using Lysia.Objects;

namespace Lysia.Modules.CoreModules;

public static class Logic
{
    public class And() : Function([2], [["bool"], ["bool"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] && values[1];
        }
    }
    
    public new class Equals() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] == values[1];
        }
    }
    
    public class Greater() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] > values[1];
        }
    }
    
    public class GreaterOrEquals() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] >= values[1];
        }
    }
    
    public class Less() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] < values[1];
        }
    }
    
    public class LessOrEquals() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] <= values[1];
        }
    }
    
    public class NotEquals() : Function([2], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] != values[1];
        }
    }
    
    public class Or() : Function([2], [["bool"], ["bool"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] || values[1];
        }
    }
}