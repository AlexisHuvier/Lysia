using System.Collections.Generic;
using System;
using Lysia.Functions;

namespace Lysia
{
    class Env
    {
        Dictionary<string, Type> values;

        public Env()
        {
            values = new Dictionary<string, Type>();
        }

        public Type GetTypeOf(string name)
        {
            if (values.ContainsKey(name))
                return values[name];
            return null;
        }

        public void Add(string[] names, Type[] types)
        {
            for (int i = 0; i < names.Length; i++)
                values.Add(names[i], types[i]);
        }

        public static Env GetStandartEnv()
        {
            Env env = new Env();

            env.Add(new string[] {
                "display", "+"
            }, new Type[] {
                typeof(Core.Display), typeof(Arithmetic.Add)
            });

            return env;
        }
    }
}
