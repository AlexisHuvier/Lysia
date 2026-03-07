using System.Text;
using Lysia.Core;

Directory.CreateDirectory("docs");

Console.WriteLine("Génération des fichiers md de documentation...");

Console.WriteLine("Génération de la documentation de Core");
var fileText = new StringBuilder();
fileText.AppendLine("# Module Core");
fileText.AppendLine();
fileText.AppendLine("This module contains all the core functions of Lysia. You can use it without importations.");
fileText.AppendLine();

foreach (var coreMethod in Env.GetStandardEnv().CoreMethods)
{
    fileText.AppendLine("## " + coreMethod.Key);
    fileText.AppendLine();
}

foreach (var variable in Env.GetStandardEnv().Variables)
{
    fileText.AppendLine("## " + variable.Key);
    fileText.AppendLine();
}
File.WriteAllText("docs/Core.md", fileText.ToString());

foreach (var module in Imports.Get())
{
    Console.WriteLine("Génération de la documentation de " + module.Key);
    fileText.Clear();
    fileText.AppendLine("# Module " + module.Key);
    fileText.AppendLine();
    fileText.AppendLine("This module contains all the functions of " + module.Key + ".");
    fileText.AppendLine();
    foreach (var function in module.Value)
    {
        fileText.AppendLine("## " + function.Key);
        fileText.AppendLine();
    }
    File.WriteAllText("docs/" + module.Key.Replace(":", "_") + ".md", fileText.ToString());
}

Console.WriteLine("Documentation générée avec succès !");
