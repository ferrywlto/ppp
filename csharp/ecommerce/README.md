# Compare eCommerce Platform

Product                                                       | Stars ⭐ | Last Update 🕐 | .NET Version | Frontend  | Database                                | Notes |
-------------------------------------------------------------|----- ----|----------------|--------------|-----------|-----------------------------------------| ---
 [SimplCommerce](https://github.com/simplcommerce/SimplCommerce) | 3.5K    | 29 days        | 6 (stable 3.1)           | Angular   | MSSQL, PostgreSQL, MySQL, SQLite        |
 [nopCommerce](https://github.com/nopSolutions/nopCommerce)      | 6.9K    | 9 days         | 5            | Unknown   | MSSQL, MySQL, PostgreSQL                | Most famous
 [GrandNode](https://github.com/grandnode/grandnode2)            | 1.8K    | 1 day          | 5            | Vue       | MongoDB, AWS DocumentDB, Azure CosmosDB | Built from nopCommerce, Vue & only NoSQL


## 1. SimplCommerce (GiveUp)
- Has Stripe/Paypal Express built-in
- Easier theming
- Where is marketplace?
- For a 3.5K project, the official site looks like halfly built.
- Modern bootstrap/material style UI compare with other products.
- Lack of documentation
- The doc website didn't update for 2 years.
- Still use no longer supported old Angular version. (1.x)
- Seems like not in active development and is a dying project although it has simplier architecture.

### Installation options
1. Docker (Test only)
- `docker run -p 5000:80 simplcommerce/ci-build`
- default admin user and password: `admin@simplcommerce.com`, `1qazZAQ!`

2. Clone form source
   1. At root directory, `chmod 777 ./simpl-build.sh`
   2. run `./simpl-build.sh`
   3. Not able to start by either follow the instructions on README nor by docker image
   4. `dotnet ef database update` not working as the project not able to connect local SQL server, ignored connection string changes in `appsettings.json`
   5. The source code cannot compile out of the box, needed to install `Npgsql.EntityFrameworkCore.PostgreSQL` nuget package first.
   6. The default connection string is for MSSQL, but the EF migration default to Postgres...
   7. Initial run after successful build throws following exception.

```c#
fail: Microsoft.EntityFrameworkCore.Database.Command[20102]
      Failed executing DbCommand ...,
fail: Microsoft.EntityFrameworkCore.Update[10000]
      An exception occurred in the database while saving changes for context type 'SimplCommerce.Module.Core.Data.SimplDbContext'.
      Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while saving the entity changes. See the inner exception for details.
       ---> System.InvalidCastException: Cannot write DateTimeOffset with Offset=08:00:00 to PostgreSQL type 'timestamp with time zone', only offset 0 (UTC) is supported. Note that it's not possible to mix DateTimes with different Kinds in an array/range. See the Npgsql.EnableLegacyTimestampBehavior AppContext switch to enable legacy behavior.
...
```

3. From release package:
- `simplcommerce_v1.0.0-rc-osx.10.13-x64.zip`
- Latest stable release is still in .NETCore 2.1!
- Not able to build using `./simpl-install.sh`. nor `dotnet build SimplCommerce.sln`

```
SimplCommerce-1.0.0-rc/src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj(67,5): error MSB3073: The command "npm run gulp-copy-modules -- --configurationName Debug" exited with code 134.
```


## 2. nopCommerce
   1. Need register to download
   2. Have many language pack to download.
   3. Have basic stripe plugin for free.
   4. Have HKD currency by default.
   5. Very good feature-wise.
   6. Have document for basic customise layout.
   7. Default look and feel is ugly.
   8. Seems cloud deploy must rely on a VM with docker installed, which is the same as Grandnode2

### Installation option
   1. Built package deploy only available for Windows and Linux, no MacOS.

`https://github.com/nopSolutions/nopCommerce/releases/tag/`

   2. Docker Image:

`docker pull nopcommerceteam/nopcommerce:latest`

   3. Clone from GitHub.

`gh repo clone nopSolutions/nopCommerce`

   1. Open Presentation/Nop.Web project, restore and run.
   2. Browse to localhost:5001 see installation page.
   3. App terminated after installation, saying restart.


## 3. GrandNode

   Comment:
   - Good documentation
   - Support multi-store
   - Fast
   - Able to get up and running in a day.
   - Only basic plugins provided, important plugins like Theme Editor, Stripe Payment, PayPal Express Checkout are EXPENSIVE.
   - Premium themes license are yearly based. Not much you can customize in admin page.
   - Anyway you can edit anything from source code and built your own version.
   - Should also support MongoAltas as it support other public cloud DB like Cosmos DB.
   - No language pack by default, you have to translate by your own!

   Question:
   - How to deal with MongoDB size expand in container?
   - Problem:
     - Deploying the container to GCP & Azure cannot get pass the installation status.
     - I think it is the cache problem. In GCP, Cloud Run cannot restart container so when Grandnode finished install, its state presist as the container cannot restart. On the other hand if let container goes idle, the container get shutdown before the installation complete. In Azure App Service for Container, for unknown reason the install state still persists after app service restart.
     - The code `Web/Grand.Web/Controllers/InstallController => Task<IActionResult> Index(InstallModel model)` should have the answer but I don't figure out yet.
     - Grandnode2 can connect to MongoAltas via `mongodb+srv://<username>:<password>@sandbox-cluster.tzgum.gcp.mongodb.net/<database_name>?retryWrites=true&w=majority`


   Tag grandnode image and push to public cloud
  ```
  // Azure
  docker tag grandnode/grandnode2:1.1.x ferrywlto.azurecr.io/grandnode2
  docker login ferrywlto.azurecr.io
  docker push ferrywlto.azurecr.io/grandnode2

  or
   // GCP
  docker tag grandnode/grandnode2:1.1.x asia.gcr.io/learn-ecommerce-337707/grandnode/grandnode2:1.1.x
  gcloud auth login
  docker push asia.gcr.io/learn-ecommerce-337707/grandnode/grandnode2:1.1.x
  ```

   ### Prerequisite:
   1. Database for grandnode2 in MongoDB need to be created and exists before installation.
   2. Requires create user at <database_name> database, in-addition to `admin` database.

   ### Steps:
   Install via docker:

   1. Pull docker images:
   ```
   docker run -d -p 127.0.0.1:27017:27017 --name mongodb mongo
   docker run -d -p 80:80 --name grandnode2 --link mongodb:mongo grandnode/grandnode2
   ```

   1. Get mongodb container IP from grandnode container:

   ```
   docker exec -it <grandnode_container_id> bash
   env
   ```

   shows following:
   ```
   root@d195c11ae055:/etc# env
   MONGO_ENV_MONGO_PACKAGE=mongodb-org
   HOSTNAME=d195c11ae055
   MONGO_ENV_MONGO_MAJOR=4.4
   MONGO_PORT_27017_TCP=tcp://172.17.0.2:27017
   MONGO_ENV_JSYAML_VERSION=3.13.1
   DOTNET_VERSION=5.0.12
   MONGO_ENV_GPG_KEYS=20691EEC35216C63CAF66CE1656408E390CFB1F5
   ASPNETCORE_URLS=http://+:80
   PWD=/etc
   HOME=/root
   MONGO_ENV_MONGO_VERSION=4.4.2
   MONGO_ENV_MONGO_REPO=repo.mongodb.org
   MONGO_PORT_27017_TCP_PORT=27017
   TERM=xterm
   MONGO_PORT=tcp://172.17.0.2:27017
   MONGO_PORT_27017_TCP_PROTO=tcp
   SHLVL=1
   ASPNET_VERSION=5.0.12
   DOTNET_RUNNING_IN_CONTAINER=true
   MONGO_PORT_27017_TCP_ADDR=172.17.0.2
   MONGO_NAME=/grandnode2/mongo
   MONGO_ENV_GOSU_VERSION=1.12
   PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin
   _=/usr/bin/env
   OLDPWD=/
   ```

   Browse to `localhost/install` and use `MONGO_PORT` value (e.g. 172.17.0.2:27017).

   1. Installation success.

   Install via source:

   1. Clone from GitHub repo, Debug `Web/Grand.Web`
   2. Install success.
