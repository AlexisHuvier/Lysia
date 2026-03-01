using System.Collections.Generic;
using Lysia.Core;

namespace Lysia.Objects;

public class ModuleFunction(dynamic function) : Function(
    (int[])function.NbParameters,
    (string[][])function.TypeParameters,
    (bool)function.EvaluateParameter
    )
{ 
    public override dynamic? Eval(Env env, List<dynamic> parameters)
    {
        var values = (List<dynamic>)base.Eval(env, parameters)!;
        return function.Eval(values);
    }
}