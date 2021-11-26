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

        public void AddVariables(string[] names, dynamic[] values)
        {
            for (int i = 0; i < names.Length; i++)
                variables.Add(names[i], values[i]);
        }

        public static Env FromEnv(Env env)
        {
            return new Env()
            {
                core_methods = new Dictionary<string, Type>(env.core_methods),
                variables = new Dictionary<string, dynamic>(env.variables)
            };
        }

        public static Env GetStandartEnv()
        {
            Env env = new Env();

            env.AddCoreMethod(new string[] {
                "#", "def", "del", "if", "for", "while", "import", "func", "ret",
                "==", "!=", ">", ">=", "<", "<=", "&&", "||",
                "+", "-", "*", "/", "%"
            }, new Type[] {
                typeof(Core.Comment), typeof(Core.Def), typeof(Core.Del), typeof(Core.If), typeof(Core.For), typeof(Core.While), typeof(Core.Import), typeof(Core.Func), typeof(Core.Ret),
                typeof(Logic.Equals), typeof(Logic.NotEquals), typeof(Logic.Greater), typeof(Logic.GreaterOrEquals), typeof(Logic.Less), typeof(Logic.LessOrEquals), typeof(Logic.And), typeof(Logic.Or),
                typeof(Arithmetic.Add), typeof(Arithmetic.Sub), typeof(Arithmetic.Mul), typeof(Arithmetic.Div), typeof(Arithmetic.Mod)
            });

            env.AddVariables(new string[] {
                "true", "false"
            }, new dynamic[] {
                true, false
            });

            return env;
        }
    }
}
