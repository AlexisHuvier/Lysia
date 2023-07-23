using System.Collections.Generic;
using Lysia.Core;

namespace Lysia.Objects;

public class ModuleFunction: Function
{
    private readonly dynamic Function;

    public ModuleFunction(dynamic function) : base((int[])function.NbParameters, (string[][])function.TypeParameters,
        (bool)function.EvaluateParameter)
    {
        Function = function;
    }

    public override dynamic? Eval(Env env, List<dynamic> parameters)
    {
        var values = (List<dynamic>)base.Eval(env, parameters)!;
        return Function.Eval(values);
    }
}