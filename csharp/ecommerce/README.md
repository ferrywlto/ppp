# Compare eCommerce Platform

Product                                                       | Stars ⭐ | Last Update 🕐 | .NET Version | Frontend  | Database                                | Notes |
-------------------------------------------------------------|---------|----------------|--------------|-----------|-----------------------------------------| ---
 [SimplCommerce](https://github.com/simplcommerce/SimplCommerce) | 3.5K    | 29 days        | 6            | Angular   | MSSQL, PostgreSQL, MySQL, SQLite        |
 [nopCommerce](https://github.com/nopSolutions/nopCommerce)      | 6.9K    | 9 days         | 5            | Unknown   | MSSQL, MySQL, PostgreSQL                | Most famous
 [GrandNode](https://github.com/grandnode/grandnode2)            | 1.8K    | 1 day          | 5            | Vue       | MongoDB, AWS DocumentDB, Azure CosmosDB | Built from nopCommerce, Vue & only NoSQL


1. SimplCommerce
   1. Clone form source
   2. Not able to start by either follow the instructions on README nor by docker image
   3. `dotnet ef database update` not working as the project not able to connect local SQL server, ignored connection string changes in `appsettings.json`

```c#
Unhandled exception. Microsoft.Data.SqlClient.SqlException (0x80131904): Login failed. The login is from an untrusted domain and cannot be used with Integrated authentication.
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.CompleteLogin(Boolean enlistOK)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.AttemptOneLogin(ServerInfo serverInfo, String newPassword, SecureString newSecurePassword, Boolean ignoreSniOpenTimeout, TimeoutTimer timeout, Boolean withFailover)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.LoginNoFailover(ServerInfo serverInfo, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance, SqlConnectionString connectionOptions, SqlCredential credential, TimeoutTimer timeout)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.OpenLoginEnlist(TimeoutTimer timeout, SqlConnectionString connectionOptions, SqlCredential credential, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds..ctor(DbConnectionPoolIdentity identity, SqlConnectionString connectionOptions, SqlCredential credential, Object providerInfo, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance, SqlConnectionString userConnectionOptions, SessionData reconnectSessionData, Boolean applyTransientFaultHandling, String accessToken, DbConnectionPool pool)
   at Microsoft.Data.SqlClient.SqlConnectionFactory.CreateConnection(DbConnectionOptions options, DbConnectionPoolKey poolKey, Object poolGroupProviderInfo, DbConnectionPool pool, DbConnection owningConnection, DbConnectionOptions userOptions)
   at Microsoft.Data.ProviderBase.DbConnectionFactory.CreatePooledConnection(DbConnectionPool pool, DbConnection owningObject, DbConnectionOptions options, DbConnectionPoolKey poolKey, DbConnectionOptions userOptions)
   at Microsoft.Data.ProviderBase.DbConnectionPool.CreateObject(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at Microsoft.Data.ProviderBase.DbConnectionPool.UserCreateRequest(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at Microsoft.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, UInt32 waitForMultipleObjectsTimeout, Boolean allowCreate, Boolean onlyOneCheckConnection, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at Microsoft.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at Microsoft.Data.ProviderBase.DbConnectionFactory.TryGetConnection(DbConnection owningConnection, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal oldConnection, DbConnectionInternal& connection)
   at Microsoft.Data.ProviderBase.DbConnectionInternal.TryOpenConnectionInternal(DbConnection outerConnection, DbConnectionFactory connectionFactory, TaskCompletionSource`1 retry, DbConnectionOptions userOptions)
   at Microsoft.Data.ProviderBase.DbConnectionClosed.TryOpenConnection(DbConnection outerConnection, DbConnectionFactory connectionFactory, TaskCompletionSource`1 retry, DbConnectionOptions userOptions)
   at Microsoft.Data.SqlClient.SqlConnection.TryOpen(TaskCompletionSource`1 retry, SqlConnectionOverrides overrides)
   at Microsoft.Data.SqlClient.SqlConnection.Open(SqlConnectionOverrides overrides)
   at Microsoft.Data.SqlClient.SqlConnection.Open()
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerConnection.OpenDbConnection(Boolean errorsExpected)
   at Microsoft.EntityFrameworkCore.Storage.RelationalConnection.OpenInternal(Boolean errorsExpected)
   at Microsoft.EntityFrameworkCore.Storage.RelationalConnection.Open(Boolean errorsExpected)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.<>c.<MoveNext>b__19_0(DbContext _, Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at System.Linq.Enumerable.ToDictionary[TSource,TKey,TElement](IEnumerable`1 source, Func`2 keySelector, Func`2 elementSelector, IEqualityComparer`1 comparer)
   at System.Linq.Enumerable.ToDictionary[TSource,TKey,TElement](IEnumerable`1 source, Func`2 keySelector, Func`2 elementSelector)
   at SimplCommerce.Module.Core.Extensions.EFConfigProvider.Load() in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/simplCommerce/SimplCommerce/src/Modules/SimplCommerce.Module.Core/Extensions/EFConfigProvider.cs:line 24
   at Microsoft.Extensions.Configuration.ConfigurationManager.AddSource(IConfigurationSource source)
   at Microsoft.Extensions.Configuration.ConfigurationManager.Microsoft.Extensions.Configuration.IConfigurationBuilder.Add(IConfigurationSource source)
   at SimplCommerce.Module.Core.Extensions.EFConfigurationProviderExtension.AddEntityFrameworkConfig(IConfigurationBuilder builder, Action`1 setup) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/simplCommerce/SimplCommerce/src/Modules/SimplCommerce.Module.Core/Extensions/EFConfigurationProviderExtension.cs:line 11
   at Program.<<Main>$>g__ConfigureService|0_0(<>c__DisplayClass0_0& ) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/simplCommerce/SimplCommerce/src/SimplCommerce.WebHost/Program.cs:line 34
   at Program.<Main>$(String[] args) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/simplCommerce/SimplCommerce/src/SimplCommerce.WebHost/Program.cs:line 26
ClientConnectionId:4f663c92-6671-479f-8b4f-fadea2772ba9
Error Number:18452,State:1,Class:14

```
2. nopCommerce
   1. Need register to download
   2. Built package deploy only available for Windows and Linux, no MacOS.
   3. Extract downloaded zip file
   4. Open Presentation/Nop.Web project, restore and run.
   5. Browse to localhost:5001 see installation page.
   6. App terminated after installation, saying restart.
   7. Execute `dotnet run` again then failed.

```c#
Unhandled exception. System.Exception: Plugin 'Google Authenticator'. Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorListModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
Return type in method 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel.<Clone>$()' on type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' is not compatible with base type method 'Nop.Web.Framework.Models.BaseNopEntityModel.<Clone>$()'.
Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorSearchModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.

Unable to load one or more of the requested types.
Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorListModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
Return type in method 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel.<Clone>$()' on type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' is not compatible with base type method 'Nop.Web.Framework.Models.BaseNopEntityModel.<Clone>$()'.
Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorSearchModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.

 ---> System.Exception: Plugin 'Google Authenticator'. Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorListModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
Return type in method 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel.<Clone>$()' on type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' is not compatible with base type method 'Nop.Web.Framework.Models.BaseNopEntityModel.<Clone>$()'.
Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorSearchModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.

 ---> System.Reflection.ReflectionTypeLoadException: Unable to load one or more of the requested types.
Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorListModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
Return type in method 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel.<Clone>$()' on type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' is not compatible with base type method 'Nop.Web.Framework.Models.BaseNopEntityModel.<Clone>$()'.
Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorSearchModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
   at System.Reflection.RuntimeModule.GetTypes(RuntimeModule module)
   at System.Reflection.RuntimeModule.GetTypes()
   at System.Reflection.Assembly.GetTypes()
   at Nop.Web.Framework.Infrastructure.Extensions.ApplicationPartManagerExtensions.InitializePlugins(ApplicationPartManager applicationPartManager, AppSettings appSettings) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/nop/nopCommerce_4.40.4_Source/Presentation/Nop.Web.Framework/Infrastructure/Extensions/ApplicationPartManagerExtensions.cs:line 515
System.TypeLoadException: Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorListModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
System.TypeLoadException: Return type in method 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel.<Clone>$()' on type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' is not compatible with base type method 'Nop.Web.Framework.Models.BaseNopEntityModel.<Clone>$()'.
System.TypeLoadException: Method '<Clone>$' in type 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Models.GoogleAuthenticatorSearchModel' from assembly 'Nop.Plugin.MultiFactorAuth.GoogleAuthenticator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
   --- End of inner exception stack trace ---
   at Nop.Web.Framework.Infrastructure.Extensions.ApplicationPartManagerExtensions.InitializePlugins(ApplicationPartManager applicationPartManager, AppSettings appSettings) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/nop/nopCommerce_4.40.4_Source/Presentation/Nop.Web.Framework/Infrastructure/Extensions/ApplicationPartManagerExtensions.cs:line 534
   --- End of inner exception stack trace ---
   at Nop.Web.Framework.Infrastructure.Extensions.ApplicationPartManagerExtensions.InitializePlugins(ApplicationPartManager applicationPartManager, AppSettings appSettings) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/nop/nopCommerce_4.40.4_Source/Presentation/Nop.Web.Framework/Infrastructure/Extensions/ApplicationPartManagerExtensions.cs:line 550
   at Nop.Web.Framework.Infrastructure.Extensions.ServiceCollectionExtensions.ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/nop/nopCommerce_4.40.4_Source/Presentation/Nop.Web.Framework/Infrastructure/Extensions/ServiceCollectionExtensions.cs:line 73
   at Nop.Web.Startup.ConfigureServices(IServiceCollection services) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/nop/nopCommerce_4.40.4_Source/Presentation/Nop.Web/Startup.cs:line 37
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor, Boolean wrapExceptions)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at Microsoft.AspNetCore.Hosting.ConfigureServicesBuilder.InvokeCore(Object instance, IServiceCollection services)
   at Microsoft.AspNetCore.Hosting.ConfigureServicesBuilder.<>c__DisplayClass9_0.<Invoke>g__Startup|0(IServiceCollection serviceCollection)
   at Microsoft.AspNetCore.Hosting.ConfigureServicesBuilder.Invoke(Object instance, IServiceCollection services)
   at Microsoft.AspNetCore.Hosting.ConfigureServicesBuilder.<>c__DisplayClass8_0.<Build>b__0(IServiceCollection services)
   at Microsoft.AspNetCore.Hosting.GenericWebHostBuilder.UseStartup(Type startupType, HostBuilderContext context, IServiceCollection services, Object instance)
   at Microsoft.AspNetCore.Hosting.GenericWebHostBuilder.<>c__DisplayClass13_0.<UseStartup>b__0(HostBuilderContext context, IServiceCollection services)
   at Microsoft.Extensions.Hosting.HostBuilder.CreateServiceProvider()
   at Microsoft.Extensions.Hosting.HostBuilder.Build()
   at Nop.Web.Program.Main(String[] args) in /Users/ferrywlto/Documents/dev/poc/ppp/csharp/ecommerce/nop/nopCommerce_4.40.4_Source/Presentation/Nop.Web/Program.cs:line 16
   at Nop.Web.Program.<Main>(String[] args)

```

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

   Question:
   - How to deal with MongoDB size expand in container?

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