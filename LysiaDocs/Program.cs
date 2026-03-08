using System.Text;
using Lysia.Core;
using Lysia.Objects;
using Lysia.Utils;

namespace LysiaDocs;

internal static class Program
{
    private static void RenderFunction(string functionName, Function function, StringBuilder fileText)
    {
        var docsAttribute = Attribute.GetCustomAttribute(function.GetType(), typeof(DocsAttribute)) as DocsAttribute;
        var examplesAttribute = Attribute.GetCustomAttributes(function.GetType(), typeof(DocsExampleAttribute)) as DocsExampleAttribute[];
        fileText.AppendLine("## Function - " + (docsAttribute?.Name ?? functionName));
        fileText.AppendLine();
        fileText.AppendLine(docsAttribute?.Description ?? "No description");
        fileText.AppendLine();
        fileText.AppendLine($"Symbol : {functionName}  ");
        fileText.Append("Parameters : ");
        if(function.NbParameters.Length == 0)
            fileText.Append($"Any number - {(function.TypeParameters.Length == 0 ? "Any type": string.Join(", ", function.TypeParameters[0]))}");
        else
        {
            foreach (var nbParameter in function.NbParameters)
            {
                if (nbParameter == 0)
                    fileText.Append('0');
                else
                {
                    fileText.Append($"{nbParameter} - ");
                    if (function.TypeParameters.Length >= nbParameter)
                    {
                        for (var par = 0; par < nbParameter; par++)
                        {
                            fileText.Append(string.Join(", ", function.TypeParameters[par]));
                            if (par != nbParameter - 1)
                                fileText.Append(", ");
                        }
                    }
                    else
                        fileText.Append("Any type");
                }
            }
        }

        fileText.AppendLine("  ");
        fileText.AppendLine($"Parameters evaluated : {(function.EvaluateParameter ? "Yes" : "No")}");
        fileText.AppendLine();

        if (examplesAttribute == null || examplesAttribute.Length == 0) return;
        
        fileText.AppendLine("Examples : ");
        foreach (var example in examplesAttribute)
            fileText.AppendLine($"- `{example.Code}` => {example.Result}");
        fileText.AppendLine();
    }
    
    public static void Main(string[] args)
    {
        Directory.Delete("../../../../docs", true);
        Directory.CreateDirectory("../../../../docs");

        Console.WriteLine("Génération des fichiers md de documentation...");

        Console.WriteLine("Génération de la documentation de Core");
        var fileText = new StringBuilder();
        fileText.AppendLine("# Module - core");
        fileText.AppendLine();
        fileText.AppendLine("This module contains all the core functions of Lysia. You can use it without importations.");
        fileText.AppendLine();

        foreach (var coreMethod in Env.GetStandardEnv().CoreMethods)
            RenderFunction(coreMethod.Key, coreMethod.Value, fileText);

        foreach (var variable in Env.GetStandardEnv().Variables)
        {
            fileText.AppendLine("## Variable - " + variable.Key);
            fileText.AppendLine();
            fileText.AppendLine($"Value : {variable.Value}");
            fileText.AppendLine();
        }
        File.WriteAllText("../../../../docs/core.md", fileText.ToString());

        foreach (var module in Imports.Get())
        {
            var docsAttribute = Attribute.GetCustomAttribute(module.Value, typeof(DocsAttribute)) as DocsAttribute;
            
            Console.WriteLine("Génération de la documentation de " + module.Key);
            fileText.Clear();
            fileText.AppendLine("# Module - " + (docsAttribute?.Name ?? module.Key));
            fileText.AppendLine();
            fileText.AppendLine(docsAttribute?.Description ?? "No description");
            fileText.AppendLine();
            foreach (var function in module.Value.GetMethod("GetImports")?.Invoke(null, null) as Dictionary<string, Function> ?? [])
                RenderFunction(function.Key, function.Value, fileText);
            File.WriteAllText("../../../../docs/" + module.Key.Replace(":", "_") + ".md", fileText.ToString());
        }

        Console.WriteLine("Documentation générée avec succès !");
    }
}