using System.Text;
using GeneratorApp.Structure;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GeneratorApp.Generators
{
    [Generator]
    public class IUnitOfWorkGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var data = FileHelper.ReadJson().Result;

            var text = TextBuilder.BuildTextForIUnitOfWork(data);

            context.AddSource("IUnitOfWork.g.cs", SourceText.From(text, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}