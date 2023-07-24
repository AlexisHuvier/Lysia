using System.Collections.Generic;
using System.IO;
using Lysia.Core;
using Lysia.Objects;

namespace Lysia.Modules;

public static class IOFile
{
    public class Create: Function
    {
        public Create() : base(new[] { 1 }, new []{ new []{"string"}}, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Create(values[0]);
        }
    }
    
    public class Delete: Function
    {
        public Delete() : base(new[] { 1 }, new []{ new []{"string"}}, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Delete(values[0]);
        }
    }
    
    public class Exists: Function
    {
        public Exists() : base(new[] { 1 }, new []{ new []{"string"}}, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Exists(values[0]);
        }
    }
    
    public class Read : Function
    {
        public Read(): base(new [] { 1 }, new [] { new [] { "string" } }, true) 
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.ReadAllText(values[0]);
        }
    }

    public class ReadLines : Function
    {
        public ReadLines(): base(new []{ 1 }, new []{ new []{"string"}}, true)
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.ReadAllLines(values[0]);
        }
    }
    public class Write : Function
    {
        public Write(): base(new [] { 2 }, new [] { new [] { "string" }, new []{ "string" } }, true) 
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.WriteAllText(values[0], values[1]);
        }
    }

    public class WriteLines : Function
    {
        public WriteLines(): base(new [] { 2 }, new [] { new [] { "string" }, new []{ "string" } }, true) 
        {}

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.WriteAllLines(values[0], values[1]);
        }
    }
}