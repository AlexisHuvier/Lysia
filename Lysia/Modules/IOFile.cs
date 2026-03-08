using System.Collections.Generic;
using System.IO;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace Lysia.Modules;

[Docs("IO:File", "Provides functions for file operations")]
public static class IoFile
{
    [Docs("Create", "Creates a new file")]
    [DocsExample("(io:file:create test.txt)", "file stream")]
    public class Create() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Create(values[0]);
        }
    }
    
    [Docs("Delete", "Deletes a file")]
    [DocsExample("(io:file:delete test.txt)", "true")]
    public class Delete() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Delete(values[0]);
        }
    }
    
    [Docs("Exists", "Checks if a file exists")]
    [DocsExample("(io:file:exists test.txt)", "true")]
    public class Exists() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.Exists(values[0]);
        }
    }
    
    [Docs("Read", "Reads the contents of a file")]
    [DocsExample("(io:file:read test.txt)", "file contents")]
    public class Read() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.ReadAllText(values[0]);
        }
    }

    [Docs("ReadLines", "Reads the contents of a file as a list of lines")]
    [DocsExample("(io:file:readlines test.txt)", "list of file lines")]
    public class ReadLines() : Function([1], [["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.ReadAllLines(values[0]);
        }
    }
    
    [Docs("Write", "Writes content to a file")]
    [DocsExample("(io:file:write test.txt \"Hello, World!\")", "true")]
    public class Write() : Function([2], [["string"], ["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.WriteAllText(values[0], values[1]);
        }
    }

    [Docs("WriteLines", "Writes a list of lines to a file")]
    [DocsExample("(io:file:writelines target.txt (io:file:readlines source.txt))", "true")]
    public class WriteLines() : Function([2], [["string"], ["string"]], true)
    {
        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            return File.WriteAllLines(values[0], values[1]);
        }
    }
    
    
    public static Dictionary<string, Function> GetImports() => new()
    {
        { "io:file:create", new Create() },
        { "io:file:delete", new Delete() },
        { "io:file:exists", new Exists() },
        { "io:file:read", new Read() },
        { "io:file:readlines", new ReadLines() },
        { "io:file:write", new Write() },
        { "io:file:writelines", new WriteLines() }
    };
}