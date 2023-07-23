using System;
using System.Collections.Generic;
using System.Linq;
using Lysia.Core;
using Lysia.Objects;

namespace Lysia.Modules.CoreModules;

public static class Arithmetic
{
    public class Add : Function
    {
        public Add() : base(Array.Empty<int>(), new[] { new[] { "int", "float", "string" } }, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if(values.Count == 0)
                Error.ShowError("Wrong Number of Arguments. Need one or more", parameters[0]);
            var value = values[0];
            for (var i = 1; i < values.Count; i++)
                value += values[i];
            return value;
        }
    }

    public class Div : Function
    {
        public Div(): base(Array.Empty<int>(), new[] { new[] { "int", "float" } }, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if(values.Count <= 1)
                Error.ShowError("Wrong Number of Arguments. Need two or more", parameters[0]);
            var value = values[0];
            for (var i = 1; i < values.Count; i++)
                value /= values[i];
            return value;
            
        }
    }

    public class Mod : Function
    {
        public Mod(): base(Array.Empty<int>(), new[] { new[] { "int", "float" } }, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if(values.Count <= 1)
                Error.ShowError("Wrong Number of Arguments. Need two or more", parameters[0]);
            var value = values[0];
            for (var i = 1; i < values.Count; i++)
                value %= values[i];
            return value;
            
        }
    }

    public class Mul : Function
    {
        public Mul(): base(Array.Empty<int>(), new[] { new[] { "int", "float" } }, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if(values.Count <= 1)
                Error.ShowError("Wrong Number of Arguments. Need two or more", parameters[0]);
            var value = values[0];
            for (var i = 1; i < values.Count; i++)
                value *= values[i];
            return value;
            
        }
    }

    public class Sub : Function
    {
        public Sub(): base(Array.Empty<int>(), new[] { new[] { "int", "float" } }, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            switch (values.Count)
            {
                case 0:
                    Error.ShowError("Wrong Number of Arguments. Need one or more", parameters[0]);
                    break;
                case 1:
                    return -values[0];
            }

            var value = values[0];
            for (var i = 1; i < values.Count; i++)
                value -= values[i];
            return value;
            
        }
    }
}