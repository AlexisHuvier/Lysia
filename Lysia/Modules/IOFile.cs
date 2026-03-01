using System.Collections.Generic;
using System.IO;
using Lysia.Core;
using Lysia.Objects;

namespace Lysia.Modules;

public static class IoFile
{
    public class Create() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Create(values[0]);
        }
    }
    
    public class Delete() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Delete(values[0]);
        }
    }
    
    public class Exists() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Exists(values[0]);
        }
    }
    
    public class Read() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.ReadAllText(values[0]);
        }
    }

    public class ReadLines() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.ReadAllLines(values[0]);
        }
    }
    public class Write() : Function([2], [["string"], ["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.WriteAllText(values[0], values[1]);
        }
    }

    public class WriteLines() : Function([2], [["string"], ["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.WriteAllLines(values[0], values[1]);
        }
    }
}