using System;
using System.Collections.Generic;

namespace Lysia.Functions
{
    class Maths
    {
        public class Pi
        {
            public static int[] nbParameters = new int[] { 0 };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.PI;
        }

        public class E
        {
            public static int[] nbParameters = new int[] { 0 };
            public static string[][] typeParameters = new string[][] { };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.E;
        }

        public class Fib
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) 
            {
                int w;
                if (parameters[0] <= 0) return 0;
                if (parameters[0] == 1) return 1;
                int u = 0;
                int v = 1;
                for (int i = 2; i <= parameters[0]; i++)
                {
                    w = u + v;
                    u = v;
                    v = w;
                };
                return v;
            }
        }

        public class Clamp
        {
            public static int[] nbParameters = new int[] { 3 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" }, new string[] { "int", "float" }, new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Clamp(parameters[0], parameters[1], parameters[2]);
        }

        public class Ceil
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Ceiling(parameters[0]);
        }

        public class Abs
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Abs(parameters[0]);
        }

        public class Acos
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Acos(parameters[0]);
        }

        public class Acosh
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Acosh(parameters[0]);
        }

        public class Asin
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Asin(parameters[0]);
        }

        public class Asinh
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Asinh(parameters[0]);
        }

        public class Atan
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Atan(parameters[0]);
        }

        public class Atanh
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Atanh(parameters[0]);
        }

        public class Atan2
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" }, new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Atan2(parameters[0], parameters[1]);
        }

        public class Cos
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Cos(parameters[0]);
        }

        public class Cosh
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Cosh(parameters[0]);
        }

        public class Sin
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Sin(parameters[0]);
        }

        public class Sinh
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Sinh(parameters[0]);
        }

        public class Tan
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Tan(parameters[0]);
        }

        public class Tanh
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Tanh(parameters[0]);
        }

        public class Min
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" }, new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Min(parameters[0], parameters[1]);
        }

        public class Max
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" }, new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Max(parameters[0], parameters[1]);
        }

        public class Pow
        {
            public static int[] nbParameters = new int[] { 2 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" }, new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Pow(parameters[0], parameters[1]);
        }

        public class Sqrt
        {
            public static int[] nbParameters = new int[] { 1 };
            public static string[][] typeParameters = new string[][] { new string[] { "int", "float" } };
            public static bool evaluateParameters = true;

            public static dynamic Eval(Env env, List<dynamic> parameters) => Math.Sqrt(parameters[0]);
        }
    }
}
