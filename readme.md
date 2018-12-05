# Project: AspNetCore for Angular client: AngularCrashCourse
## Asp.net Core 2.1 and EF Migration
## Online Ref: 
* https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio
* https://blogs.msdn.microsoft.com/dotnet/2018/05/30/announcing-entity-framework-core-2-1/
* https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding

## Check: Create the database
```
Add-Migration InitialCreate
Update-Database 
```
**If you get an error stating The term 'add-migration'** 
** is not recognized as the name of a cmdlet, close and reopen Visual Studio.**

## CORS is using policies:

```
// Shows UseCors with CorsPolicyBuilder.
services.AddCors(options =>
{
    options.AddPolicy("AllowAllOriginsHeadersAndMethods",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
```
* Using named policy:-
```
 // Shows UseCors with named policy.
 app.UseCors("AllowAllOriginsHeadersAndMethods");
```
* Using controller decorators:-
```
[Route("api/[controller]")]
[EnableCors("AllowAllOriginsHeadersAndMethods")]
public class ValuesController : ControllerBase
```


