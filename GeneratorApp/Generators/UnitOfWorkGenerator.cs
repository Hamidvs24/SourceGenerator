using System.Text;
using GeneratorApp.Structure;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GeneratorApp.Generators
{
    [Generator]
    public class UnitOfWorkGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var data = FileHelper.ReadJson().Result;

            var text = TextBuilder.BuildTextForUnitOfWork(data);

            context.AddSource("UnitOfWork.g.cs", SourceText.From(text, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}