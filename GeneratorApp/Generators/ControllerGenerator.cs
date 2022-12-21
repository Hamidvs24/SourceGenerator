using System.Text;
using GeneratorApp.Structure;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GeneratorApp.Generators
{
    [Generator]
    public class ControllerGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var data = FileHelper.ReadJson().Result;

            data.ForEach(model =>
            {
                var text = TextBuilder.BuildTextForEntityController(model);
                context.AddSource($"{model.Name}Controller.g.cs", SourceText.From(text, Encoding.UTF8));
            });
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}