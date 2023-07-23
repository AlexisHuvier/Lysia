using System;
using System.Collections.Generic;
using Lysia.Core;
using Lysia.Objects;

namespace Lysia.Modules.CoreModules;

public static class Logic
{
    public class And : Function
    {
        public And(): base(new []{ 2 }, new []{ new []{ "bool" }, new []{ "bool" } }, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] && values[1];
        }
    }
    
    public new class Equals : Function
    {
        public Equals(): base(new []{ 2 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] == values[1];
        }
    }
    
    public class Greater : Function
    {
        public Greater(): base(new []{ 2 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] > values[1];
        }
    }
    
    public class GreaterOrEquals : Function
    {
        public GreaterOrEquals(): base(new []{ 2 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] >= values[1];
        }
    }
    
    public class Less : Function
    {
        public Less(): base(new []{ 2 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] < values[1];
        }
    }
    
    public class LessOrEquals : Function
    {
        public LessOrEquals(): base(new []{ 2 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] <= values[1];
        }
    }
    
    public class NotEquals : Function
    {
        public NotEquals(): base(new []{ 2 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] != values[1];
        }
    }
    
    public class Or : Function
    {
        public Or(): base(new []{ 2 }, new []{ new []{ "bool" }, new []{ "bool" } }, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return values[0] || values[1];
        }
    }
}