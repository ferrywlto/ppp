Blazor WASM hosted version.

It serves the WASM via blazor server and perform server side rendering (SSR/Prerendering)

Project created via
```C#
dotnet new blazorwasm --hosted
```

Reference: [Prerendering your Blazor WASM application with .NET 5 (part 1)](https://jonhilton.net/blazor-wasm-prerendering/)


### Serve the html from server side instead of static `index.html`

1. Copy `index.html` from `Client/wwwroot` as `Server/Pages/_Host.cshtml`

2. Edit `Server/Pages/_Host.cshtml` as below:
   1. add the following at the top of the file:
   ```c#
    @page
    @namespace blazor_mix_ssr.Server.Pages
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
    ```
   2. add
   ```c#
    <component type="typeof(App)" render-mode="ServerPrerendered" />
    ```
   before
    ```c#
    <script src="_framework/blazor.webassembly.js"></script>
    ```
   3. remove unneeded code, the file should looks like:
   ```c#
   @page
   @using blazor_mix_ssr.Client
   @namespace blazor_mix_ssr.Server.Pages
   @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
   
   <!DOCTYPE html>
   <html lang="en">
   
   <head>
       <meta charset="utf-8" />
       <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
       <title>blazor_mix_ssr</title>
       <base href="/" />
       <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
       <link href="css/app.css" rel="stylesheet" />
       <link href="blazor_mix_ssr.Client.styles.css" rel="stylesheet" />
   </head>
   
   <body>
   <component type="typeof(App)" render-mode="ServerPrerendered" />
   <script src="_framework/blazor.webassembly.js"></script>
   </body>
   
   </html>
   ```
4. Redirect all route to prerendered. In `Server/Program.cs`, look for 

```c#
app.MapFallbackToFile("index.html");
```

and replace with

```c#
app.MapFallbackToPage("/_Host");
```

5. Since the app was prerendered from server, the client app should no longer load the app into `#app` tag. In `Client/Program.cs` remove this line:
```c#
builder.RootComponents.Add<App>("#app");
```

otherwise error show in console:
```c#
Microsoft.JSInterop.JSException: Could not find any element matching selector ‘#app’.
```
