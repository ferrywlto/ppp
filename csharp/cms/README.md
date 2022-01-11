# Comparison between CMS

Product | Stars | Last Release      | .NET Version | Frontend       | Note
--- |-------|-------------------|--------------|----------------| --- 
[Piranha](piranhacms.org) | 1.5K  | v10.0.1 - 01/12/21 | 6            | Vue            | Headless / Integrated CMS  
[Squidex](squidex.io) | 1.6K  | v6.4.0 - 20/12/21 | 6            | N/A - Headless | Headless, MongoDb, Not free, starter plan limit to 20000 calls, powerful, many deploy options 
[OrchardCore](www.orchardcore.net/) | 5.7K  | v1.2.0 - 07/01/22 | 6            | Liquid.js      | Framework + CMS, MSSQL, SQLite, Postgres, MySQL
[Umbraco](mbraco.com) | 3.5K  | v9.2.0 - 04/01/22 | 6            | ?              | Headless is not free, Full CMS
[MixCore](https://mixcore.org) | 435   | v1.0.4 - 11/11/21 | 5            | Angular/Svelte | Headless + Decoupled CMS

Why CMS/Website over FB Page?
- Data ownership
- Customized branding options
- Platform lock-in
- Policy change by FB
- You agree all your content on FB can be use and sell by FB or other FB users
- You have no control on negative comment.
- Get money/Reach user directly
- Business presence can be search by Google.
- Should have both channels simultaneously.

## 1. Piranha
- Work out of the box
- Easy to use
- Good documentation

### Installation options

- From template:

`dotnet new -i Piranha.Templates`

`dotnet new piranha.razor`
or
`dotnet new piranha.mvc`
or
`dotnet new piranha.empty`

- From source:
```
> git clone https://github.com/PiranhaCMS/piranha.core.git
> cd piranha.core/core/Piranha.Manager
> npm install
> gulp min:js
> gulp min:css

> cd piranha.core
> dotnet restore
> dotnet build
> cd examples/MvcWeb
> dotnet run
```

- Admin page:
`~/manager` with `admin` / `password`

## 2. Squidex

### Installation options

## 3. OrchardCore

### Installation options
- Seems powerful.
- Fast
- Work out of box
- Can initialise as various mode (SaaS/Blog Engine/Agency/etc)
- Theming possible (need to learn Liquid.js)
- Good documentation
- Develop options (Full CMS, Decoupled, Headless)


1. Docker
   `docker run --name orchardcms -p 8080:80 orchardproject/orchardcore-cms-linux:latest`

2. Source
    `https://github.com/OrchardCMS/OrchardCore/archive/refs/tags/v1.2.0.zip`

3. Create from scratch
    `dotnet new -i OrchardCore.ProjectTemplates::1.2.0`
   `dotnet new occms`
    or
   `dotnet new ocmvc`
## 4. Umbraco

### Installation options

## 5. MixCore

### Installation options
