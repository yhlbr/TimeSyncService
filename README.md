# TimeSyncService

## What it does
It automatically syncs the current system time to any given endpoint.

## Create New Release
### Building

1. **Update MyApp Version** - update the application version.
 
   	**`Properties\AssemblyInfo.cs`**
   
   	~~~cs
  	[assembly: AssemblyVersion("1.0.1")]
	[assembly: AssemblyFileVersion("1.0.1")]
   	~~~
2. **Switch to Release** - switch your build configuration to `Release`.
3. **Build MyApp** - build your application to ensure the latest changes are included in the package we will be creating.

### Packing

Using [NuGet Package Explorer](https://npe.codeplex.com/) complete the following:

1. **Open Previous NuGet Package** - open the previous NuGet package you created for MyApp version 1.0.0.
2. **Update Version** - update the version in the metadata.
4. **Replace Release Files** - replace the changed files under `lib\net45`. You can simply drag and drop any program specific files that have changed (i.e., the `MyApp.exe` file is the only one that has updated in the example). 
5. **Save the NuGet Package File as New Version** - use the "Save As..." feature to save the new version of the package `MyApp.1.0.1.nupkg`.

### Releasifying

Use the [Package Manager Console](https://docs.NuGet.org/consume/package-manager-console) to execute `Squirrel.exe --releasify` command using the new  `MyApp.1.0.1.nupkg` package.

~~~powershell
PM> Squirrel --releasify TimeSyncService.1.0.2.nupkg --setupIcon "C:\Users\Yannick Hilber\git\TimeSyncService\TimeSyncService\Resources\icon.ico"
~~~

### Distributing the New Release
Create a new GitHub Release
