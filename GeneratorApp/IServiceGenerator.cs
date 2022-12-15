using System.Text;
using GeneratorApp.Structure;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GeneratorApp
{
    [Generator]
    public class IServiceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var model = FileHelper.ReadJson().Result;

            var iEntityService = TextBuilder.BuildTextForIEntityService(model);

            context.AddSource($"I{model.Name}Service.g.cs", SourceText.From(iEntityService, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}