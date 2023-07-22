using System.Collections.Generic;
using System.Linq;
using Lysia.Core;
using Lysia.Utils;

namespace Lysia.Objects;

public class Function
{
    public readonly int[] nbParameters;
    public readonly string[][] typeParameters;
    public readonly bool evaluateParameter;

    public Function(int[] nbParameters, string[][] typeParameters, bool evaluateParameter)
    {
        this.nbParameters = nbParameters;
        this.typeParameters = typeParameters;
        this.evaluateParameter = evaluateParameter;
    }

    public virtual dynamic? Eval(Env env, List<dynamic> parameters)
    {
        var values = new List<dynamic>();
        
        if(evaluateParameter)
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
        if (nbParameters.Length != 0)
        {
            foreach (var nbParameter in nbParameters)
            {
                if (nbParameter == values.Count)
                {
                    if (typeParameters.Length != 0)
                    {
                        for (var i = 0; i < nbParameter; i++)
                        {
                            var validate = true;
                            foreach (var type in typeParameters[i])
                            {
                                validate = false;
                                if (Extensions.VerifType(type, values[i]))
                                {
                                    validate = true;
                                    break;
                                }
                            }

                            if (!validate)
                                return false;
                        }
                    }

                    return true;
                }
            }

        }
        else if(typeParameters.Length != 0)
        {
            foreach (var value in values)
            {
                var validate = true;
                foreach (var type in typeParameters[0])
                {
                    validate = false;
                    if (Extensions.VerifType(type, value))
                    {
                        validate = true;
                        break;
                    }
                }

                if (!validate)
                    return false;
            }

            return true;
        }

        return true;
    }
}