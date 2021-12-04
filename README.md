# AgileCodeGeneration

Code Generation with .NET and Excel-Models
Code-Samples and Demos for Article in [dotnetpro-magazine](http://www.dotnetpro.de/)

The folder **AgileCodeGen** contains Visual Studio (2019+) solution with demo projects. To obtain the demo projects locally simply click on the green **Code**-button and clone the Git-repository or download/unpack it as a ZIP file and finally open **_AgileCodeGeneration.sln_** in Visual Studio. 

In the **_AgileCodeGeneration_**-solution you will find directories with the following artifacts:

- **_1. Models / GeometricModels_** - a library with the circle and trapezoid models (as static public C#-classes).
- **_1. Model / GeometricModelsCore_** - a library with the rectangle model (as a static public C#-class).
- **_2. code generation - Direct / GenExampleDirect_** - code generation implemented “by hand”.
- **_3. code generation - CodeDOM / GenExampleCodeDOM_** - code generation project with CodeDOM technology.
- **_3. Code Generation - CodeDOM / TargetCodeDOM_** - target project for CodeDOM code generation.
- **_4. code generation - T4 / 4.1_static / GenExampleT4_** - code generation project with T4 text template.
- **_4. code generation - T4 / 4.2_dynamic / GenExampleT4Dynamic_** - code generation project with T4 runtime text templates.
- **_4. code generation - T4 / 4.2_dynamic / TargetRuntimeT4_** - target project for code generation with T4 runtime text templates.
- **_5. code generation - Excel / ExcelSqlCodeGen.xlsx_** - Excel code generation model for SQL-scripts.
- **_5. Code Generation - Excel / PolygonCodeGenerator.xlsm_** - Excel code generation model for C#-classes.
- **_5. Code generation - Excel / PolygonTestCircle /-Rectangle /-Trapezoid_** - C#-target projects for code generation with an Excel model.

Some C#-projects have .NET Core 3.1 and the other .NET 4.7.2 as a target framework to demonstrate that code generation with .NET can run on a multi-platform basis.
