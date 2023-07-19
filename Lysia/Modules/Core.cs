using System.Collections.Generic;
using System.IO;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Token;

namespace Lysia.Modules;

public class Core
{
    public class Comment : Function
    {
        public Comment() : base(System.Array.Empty<int>(), System.Array.Empty<string[]>(), false)
        {}
    }

    public class Import : Function
    {
        public Import() : base(new[] { 1 }, System.Array.Empty<string[]>(), false)
        { }

        public override dynamic? Eval(Env env, List<dynamic> parameters)
        {
            var values = (List<dynamic>)base.Eval(env, parameters)!;
            
            if (values[0] is Token.Token { Type: TokenType.Identifier } token)
            {
                var import = token.Value;
                if (Imports.IsDefined(import))
                {
                    foreach (var function in Imports.Get(import))
                        env.CoreMethods.Add(function.Key, function.Value);
                }
                else if (File.Exists(import) && Path.GetExtension(import) == ".lysia")
                    Interpreter.Eval(Parser.Parse(Lexer.Tokenize(File.ReadAllText(import))), env);
                else
                    Error.ShowError("UnknownImport", "Unknown Import", parameters[0]);
            }
            else
                Error.ShowError("WrongArgument", "Wait import or lysia file", parameters[0]);

            return null;
        }
    }
}