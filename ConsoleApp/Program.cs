// just run project and go to this location
// ..\SourceGenerator\ConsoleApp\obj\Debug\net7.0\generated\GeneratorApp\GeneratorApp.FirstGenerator\HelloWorldGenerated.cs

// learn more on https://learn.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview

namespace ConsoleApp;

public abstract class Program
{
    public static void Main(string[] args)
    {
        // if you want to navigate generated file path use this lines

        var a = typeof(BLL.Abstract.ITagService);
        var b = typeof(BLL.Concrete.TagService);

        var c = typeof(API.Controllers.TagController);

        var u = typeof(DAL.UnitOfWorks.Abstract.IUnitOfWork);
        var w = typeof(DAL.UnitOfWorks.Concrete.UnitOfWork);

        var r = typeof(DAL.Abstract.ITagRepository);
        var i = typeof(DAL.Concrete.TagRepository);

        Console.WriteLine("Operation completed succesfully !");
    }
}