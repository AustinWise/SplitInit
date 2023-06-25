
This sample contains the following files:

* `CustomMain.cpp` - contains the native `main` function
* `Program.cs` contains the managed `Main` function.
* `CustomMain.csproj` - configures MSBuild to compile `CustomMain.cpp` and link
  it into the finial executable.

Publish this with:

```cmd
dotnet publish -c Release CustomMain.csproj -r win-x64
```

On Windows, this must be done from a Visual Studio command prompt. For example,
if building for x64, this should be built from a
"x64 Native Tools Command Prompt for VS 2022".

On Unix-like platforms, `cc` will be used as a C compiler.
