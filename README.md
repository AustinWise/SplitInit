
# Custom unmanaged managed `main` in NativeAOT

[.NET NativeAOT](https://learn.microsoft.com/dotnet/core/deploying/native-aot/)
compiles your .NET application to a native executable. By default when you
publish an application as NativeAOT, the NativeAOT build system includes its
own unmanaged `main` function that will call your applications `Main` function.

Some applications need to run native code before the managed main function.
Starting in .NET 8, NativeAOT supports the `CustomNativeMain` property.
When set to `true` in your `.csproj` file, this property causes the NativeAOT build
system to not include an unmanaged `main` function. Instead you have to supply
one using a `NativeLibrary` item in the `.csproj` file.

You can call the `__managed__Main` to execute the managed main function. Before
calling `__managed__Main`, you can also call
[`UnmanagedCallersOnly`](https://learn.microsoft.com/dotnet/api/system.runtime.interopservices.unmanagedcallersonlyattribute)
functions.

See the [`src/CustomMain`](src/CustomMain) folder for an example.

## Alternatives to using custom native main

One option is a
[module initializer](https://learn.microsoft.com/dotnet/csharp/language-reference/proposals/csharp-9.0/module-initializers).
This facility allows executing C# functions at assembly load time. In NativeAOT,
which does not have the concept of loading an assembly, all module initializers
are run before the managed main.

A module initializer is less complicated to add to an application, as you don't
have to integrate building unmanaged code into the build system. Conventional,
non-NativeAOT .NET applications also support module initializers.
