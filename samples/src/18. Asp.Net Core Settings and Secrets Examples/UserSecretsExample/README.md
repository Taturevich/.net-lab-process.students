This is simple ASP.NET Core sample that showing work with options configuration and user secrets for development. 

You have to have dotnet 2.2 SDK installed in order to run this app.

In order to setup user secrets do following steps:

1) add new guid to web project .csproj file

```xml
<PropertyGroup>
    <UserSecretsId>A50772FB-F5BB-4C2D-B719-DF71175FBCE0</UserSecretsId>
</PropertyGroup>
```

for your project use randomly generated Guid, not this one

2) Register settings file and register user secrets options to it
```c#
public Startup(IHostingEnvironment env)
{
    _configuration = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
        .AddUserSecrets<Startup>()
        .Build();

    // Now you have access to your secrets from IConfigurationRoot object. You can use it during configuration phase or save it in option file
}
```

3) Go folder with web project .csproj file and set your local secret variables via cmd or powershel there

```bash
dotnet user-secrets set FirstSecret VerySecretValue
dotnet user-secrets set SecondSecret VerySecretValue
```

You can use names for variables you want and values. You can even setup variables in particular section
```bash
dotnet user-secrets set ConfigSection:Secret VerySecretValue
```

4) Read values from configuration during Startup into appropriate objects

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(); // adding web service pipeline
    services.Configure<OptionsWithSecrets>(binder =>
    {
        binder.FirstSecret = _configuration[nameof(OptionsWithSecrets.FirstSecret)];
        binder.SecondSecret = _configuration[nameof(OptionsWithSecrets.SecondSecret)];
    }); // register secrets in the setting object
}
```
