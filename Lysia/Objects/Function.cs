using System.Collections.Generic;
using System.Linq;
using Lysia.Core;
using Lysia.Utils;

namespace Lysia.Objects;

public class Function(int[] nbParameters, string[][] typeParameters, bool evaluateParameter)
{
    public readonly int[] NbParameters = nbParameters;
    public readonly string[][] TypeParameters = typeParameters;
    public readonly bool EvaluateParameter = evaluateParameter;

    public virtual dynamic? Eval(Env env, List<dynamic> parameters)
    {
        var values = new List<dynamic>();
        
        if(EvaluateParameter)
            for(var i = 1; i < parameters.Count; i++)
                values.Add(Interpreter.Eval(parameters[i], env));
        else
            values.AddRange(parameters.Skip(1));
        
        if(!CheckParameters(values))
            Error.ShowError("Wrong Number or Types of Parameters", parameters[0]);

        return values;
    }

    public bool CheckParameters(List<dynamic> values)
    {
        if (NbParameters.Length != 0)
        {
            foreach (var nbParameter in NbParameters)
            {
                if (nbParameter != values.Count) continue;
                if (TypeParameters.Length == 0) return true;
                    
                for (var i = 0; i < nbParameter; i++)
                {
                    var validate = true;
                    foreach (var type in TypeParameters[i])
                    {
                        validate = false;
                        if (!Extensions.VerifType(type, values[i])) continue;
                        
                        validate = true;
                        break;
                    }

                    if (!validate)
                        return false;
                }

                return true;
            }

        }
        else if(TypeParameters.Length != 0)
        {
            foreach (var value in values)
            {
                var validate = true;
                foreach (var type in TypeParameters[0])
                {
                    validate = false;
                    if (!Extensions.VerifType(type, value)) continue;
                    
                    validate = true;
                    break;
                }

                if (!validate)
                    return false;
            }
        }

        return true;
    }
}