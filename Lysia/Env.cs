using System.Collections.Generic;
using System;
using Lysia.Functions;

namespace Lysia
{
    class Env
    {
        public Dictionary<string, Type> core_methods;
        public Dictionary<string, dynamic> variables;

        public Env()
        {
            core_methods = new Dictionary<string, Type>();
            variables = new Dictionary<string, dynamic>();
        }

        public bool IsDefine(string name)
        {
            return core_methods.ContainsKey(name) || variables.ContainsKey(name);
        }

        public dynamic Get(string name)
        {
            if (core_methods.ContainsKey(name))
                return core_methods[name];
            if (variables.ContainsKey(name))
                return variables[name];
            return null;
        }

        public void AddCoreMethod(string[] names, Type[] types)
        {
            for (int i = 0; i < names.Length; i++)
                core_methods.Add(names[i], types[i]);
        }

        public static Env GetStandartEnv()
        {
            Env env = new Env();

            env.AddCoreMethod(new string[] {
                "#", "def", "del", "if", "for", "while", "import", "func", "ret",
                "==", "!=", ">", ">=", "<", "<=",
                "+", "-"
            }, new Type[] {
                typeof(Logic.Equals), typeof(Logic.NotEquals),
                typeof(Arithmetic.Add)
                typeof(Core.Comment), typeof(Core.Def), typeof(Core.Del), typeof(Core.If), typeof(Core.For), typeof(Core.While), typeof(Core.Import), typeof(Core.Func), typeof(Core.Ret),
            });

            return env;
        }
    }
}
