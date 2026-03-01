using System;
using System.Collections.Generic;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace Lysia.Modules;

public static class Lysia
{
    public class Exit() : Function([1], [["int"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            Environment.Exit(values[0]);
            return null;
        }
    }

    public class PrintEnv() : Function([0], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            Print.PrintEnv(env);
            return null;
        }
    }
    
    public class Version() : Function([0], [], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters) => "1.0.0";
    }
}