# Practice direction

1. Choose one product
2. Create a site with it
3. Try to replicate on other product
4. Repeat step 3.

# Comparison between CMS

Product | Stars | Last Release       | .NET Version | Frontend                                              | DB                               | Note
--- |-------|--------------------|--------------|-------------------------------------------------------|----------------------------------| ---
[Piranha](piranhacms.org) | 1.5K  | v10.0.1 - 01/12/21 | 6            | Vue                                                   | MSSQL, SQLite, Postgres, MySQL   | Headless / Integrated CMS
[Squidex](squidex.io) | 1.6K  | v6.4.0 - 20/12/21  | 6            | N/A - Headless                                        | MongoDb                          | Headless, Not free, starter plan limit to 20000 calls, powerful, many deploy options 
[OrchardCore](www.orchardcore.net/) | 5.7K  | v1.2.0 - 07/01/22  | 6            | Liquid.js                                             | MSSQL, SQLite, Postgres, MySQL   | Framework + CMS                                             
[Umbraco](umbraco.com) | 3.5K  | v9.2.0 - 04/01/22  | 6            | Angular                                               | MSSQL                            | Headless is not free, Full CMS        
[MixCore](https://mixcore.org) | 435   | v1.0.4 - 11/11/21  | 5            | Angular / Bootstrap / React / Vue / Svelte/ Handlebar | MSSQL, SQLite, Postgres, MySQL   | Headless + Decoupled CMS

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
- Not easy to start / try. Seems force you to use their cloud hosting.

### Installation options
`squidex/squidex:latest`

- Need to build docker image from source.
`https://github.com/Squidex/squidex/archive/refs/tags/6.4.0.zip`
`https://github.com/Squidex/squidex/releases/download/6.4.0/binaries.zip`

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
- ASP.NET MVC
- Backoffice use Angular
- Can unattended install
- SQL Server Only
- Like Wordpress to try to provide low/no code platform to editor
- Powerful, has many features that are not exist in other products like CRM forms, document and relation types.
- Many packages to further extend features
- Fast and responsive
- For professional content site
- Backoffice still partially work when server shut down.
- Fast frontend
- Have eCommerce concept implemented.
- Coding template in backoffice interface
- Work out of box, easy to install
- Need to create database in MSSQL before install.
- The down side: steep learning curve, too many features, MSSQL lock-in, no free headless mode.

### Installation options
1. Template
```
dotnet new -i Umbraco.Templates
dotnet new umbraco --name MyProject
```

2. Source

`https://github.com/umbraco/Umbraco-CMS/archive/refs/tags/release-9.2.0.zip`
```
cd src/Umbraco.Web.UI
dotnet run
```


## 5. MixCore
- Fast back office
- Easy to use backoffice
- Work out of box
- Slow on data loading?
- Good documentation
- Good UX both front-end and back-office
- Seems have some problems on back-office styling and permission settings


### Installation options

1. Docker
```
docker pull mixcore/mix.core:latest
docker run -it --rm -p 5000:80 --name mixcore_cms mixcore/mix.core:latest
```

2. By source

`https://github.com/mixcore/mix.core/archive/refs/tags/v1.0.4.zip`

```
cd mix.core/src/Mix.Cms.Web

dotnet restore
dotnet build
dotnet run
```

3. By upload binaries

`https://github.com/mixcore/mix.core/releases/download/v1.0.4/mixcore-v1.0.4.zip`
