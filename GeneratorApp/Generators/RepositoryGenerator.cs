using System.Text;
using GeneratorApp.Structure;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GeneratorApp.Generators
{
    [Generator]
    public class RepositoryGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var data = FileHelper.ReadJson().Result;

            data.ForEach(model =>
            {
                var text = TextBuilder.BuildTextForRepository(model);
                context.AddSource($"{model.Name}Repository.g.cs", SourceText.From(text, Encoding.UTF8));
            });
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}