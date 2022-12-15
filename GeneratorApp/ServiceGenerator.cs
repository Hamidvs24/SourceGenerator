using System.Text;
using GeneratorApp.Structure;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GeneratorApp
{
    [Generator]
    public class ServiceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var model = FileHelper.ReadJson().Result;

            var entityService = TextBuilder.BuildTextForEntityService(model);

            context.AddSource($"{model.Name}Service.g.cs", SourceText.From(entityService, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}