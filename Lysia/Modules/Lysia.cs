using System;
using System.Collections.Generic;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace Lysia.Modules;

public static class Lysia
{
    public class Exit : Function
    {
        public Exit(): base(new []{ 1 }, new []{ new []{ "int" } }, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            Environment.Exit(values[0]);
            return null;
        }
    }

    public class PrintEnv : Function
    {
        public PrintEnv(): base(new []{ 0 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            Print.PrintEnv(env);
            return null;
        }
    }
    
    public class Version: Function
    {
        public Version(): base(new []{ 0 }, Array.Empty<string[]>(), true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters) => "1.0.0";
    }
}