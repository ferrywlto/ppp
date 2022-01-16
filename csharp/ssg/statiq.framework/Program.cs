// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Markdown;

namespace MyGenerator
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>
            await Bootstrapper
                  .Factory
                  .CreateDefault(args)
                  .BuildPipeline("Render Markdown", builder => builder
                                                               .WithInputReadFiles("*.md")
                                                               .WithProcessModules(new RenderMarkdown())
                                                               .WithOutputWriteFiles(".html"))
                  .RunAsync();
    }
}
