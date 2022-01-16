# Static Site Generator

## [Statiq](statiq.dev)

- Seems this is the only choice in .NET world
- Still in beta.
- Too few documentation and example for doing anything serious.

## Statiq.Framework

- Base framework, not easy to use.

## [Statiq.Web](statiq.dev/web)
- Build on top of Statiq.Framework.
- Easier

### Installation
**Folder name cannot be statiq.web or statiq.framework**
```c#
dotnet new console --name MySite
dotnet add package Statiq.Web --version x.y.z
```
Program.cs
```c#
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Web;

namespace MySite
{
  public class Program
  {
    public static async Task<int> Main(string[] args) =>
      await Bootstrapper
        .Factory
        .CreateWeb(args)
        .RunAsync();
  }
}
```
input/index.md
```markdown
Title: My First Statiq page
---
# Hello World!

Hello from my first Statiq page.
```
run with preview:
```
dotnet run -- preview --port 1234
```
serve without build:
```
dotnet run -- serve
```
also you can use npm package `http-server` to serve the build `output` folder
```
http-server output/
```
