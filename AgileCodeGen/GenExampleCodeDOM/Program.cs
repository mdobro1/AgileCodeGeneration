using System;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
/// <summary>
/// Code-Example is derived from https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/how-to-create-a-class-using-codedom#compiling-the-code
/// </summary>

namespace GenExampleCodeDOM
{
    /// <summary>
    /// This code example creates a graph using a CodeCompileUnit and
    /// generates source code for the graph using the CSharpCodeProvider.
    /// </summary>
    class CodeDOMGeneratorSample
    {
        /// <summary>
        /// Create the CodeDOM graph and generate the code.
        /// </summary>
        static void Main()
        {
            GenerateCodeInTargetProject();
            // GenerateCodeInCurrentProject();
        }

        /// <summary>
        /// Define the compile unit to use for code generation.
        /// </summary>
        private CodeCompileUnit targetUnit;

        /// <summary>
        /// The only class in the compile unit. This class contains 2 fields,
        /// 3 properties, a constructor, an entry point, and 1 simple method.
        /// </summary>
        private CodeTypeDeclaration targetClass;

        /// <summary>
        /// Define the class.
        /// </summary>
        public CodeDOMGeneratorSample()
        {
            targetUnit = new CodeCompileUnit();
            CodeNamespace samples = new CodeNamespace("CodeDOMPolygonSample");
            samples.Imports.Add(new CodeNamespaceImport("System"));
            targetClass = new CodeTypeDeclaration("CodeDOMRectangleClass");
            targetClass.IsClass = true;
            targetClass.TypeAttributes =
                TypeAttributes.Public | TypeAttributes.Sealed;
            samples.Types.Add(targetClass);
            targetUnit.Namespaces.Add(samples);
        }

        /// <summary>
        /// Adds two fields to the class.
        /// </summary>
        public void AddFields()
        {
            // Declare the widthValue field.
            CodeMemberField widthValueField = new CodeMemberField();
            widthValueField.Attributes = MemberAttributes.Private;
            widthValueField.Name = "widthValue";
            widthValueField.Type = new CodeTypeReference(typeof(System.Double));
            widthValueField.Comments.Add(new CodeCommentStatement(
                "The width of the object."));
            targetClass.Members.Add(widthValueField);

            // Declare the heightValue field
            CodeMemberField heightValueField = new CodeMemberField();
            heightValueField.Attributes = MemberAttributes.Private;
            heightValueField.Name = "heightValue";
            heightValueField.Type =
                new CodeTypeReference(typeof(System.Double));
            heightValueField.Comments.Add(new CodeCommentStatement(
                "The height of the object."));
            targetClass.Members.Add(heightValueField);
        }
        /// <summary>
        /// Add three properties to the class.
        /// </summary>
        public void AddProperties()
        {
            // Declare the read-only Width property.
            CodeMemberProperty widthProperty = new CodeMemberProperty();
            widthProperty.Attributes =
                MemberAttributes.Public | MemberAttributes.Final;
            widthProperty.Name = "Width";
            widthProperty.HasGet = true;
            widthProperty.Type = new CodeTypeReference(typeof(System.Double));
            widthProperty.Comments.Add(new CodeCommentStatement(
                "The Width property for the object."));
            widthProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "widthValue")));
            targetClass.Members.Add(widthProperty);

            // Declare the read-only Height property.
            CodeMemberProperty heightProperty = new CodeMemberProperty();
            heightProperty.Attributes =
                MemberAttributes.Public | MemberAttributes.Final;
            heightProperty.Name = "Height";
            heightProperty.HasGet = true;
            heightProperty.Type = new CodeTypeReference(typeof(System.Double));
            heightProperty.Comments.Add(new CodeCommentStatement(
                "The Height property for the object."));
            heightProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "heightValue")));
            targetClass.Members.Add(heightProperty);

            // Declare the read only Area property.
            CodeMemberProperty areaProperty = new CodeMemberProperty();
            areaProperty.Attributes =
                MemberAttributes.Public | MemberAttributes.Final;
            areaProperty.Name = "Area";
            areaProperty.HasGet = true;
            areaProperty.Type = new CodeTypeReference(typeof(System.Double));
            areaProperty.Comments.Add(new CodeCommentStatement(
                "The Area property for the object."));

            // Create an expression to calculate the area for the get accessor
            // of the Area property.
            CodeBinaryOperatorExpression areaExpression =
                new CodeBinaryOperatorExpression(
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "widthValue"),
                CodeBinaryOperatorType.Multiply,
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "heightValue"));
            areaProperty.GetStatements.Add(
                new CodeMethodReturnStatement(areaExpression));
            targetClass.Members.Add(areaProperty);
        }

        /// <summary>
        /// Adds a method to the class. This method multiplies values stored
        /// in both fields.
        /// </summary>
        public void AddMethod()
        {
            // Declaring a ToString method
            CodeMemberMethod toStringMethod = new CodeMemberMethod();
            toStringMethod.Attributes =
                MemberAttributes.Public | MemberAttributes.Override;
            toStringMethod.Name = "ToString";
            toStringMethod.ReturnType =
                new CodeTypeReference(typeof(System.String));

            CodeFieldReferenceExpression widthReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "Width");
            CodeFieldReferenceExpression heightReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "Height");
            CodeFieldReferenceExpression areaReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "Area");

            // Declaring a return statement for method ToString.
            CodeMethodReturnStatement returnStatement =
                new CodeMethodReturnStatement();

            // This statement returns a string representation of the width,
            // height, and area.
            string formattedOutput = "The rectangle object:" + Environment.NewLine +
                " width = {0}," + Environment.NewLine +
                " height = {1}," + Environment.NewLine +
                " area = {2}";
            returnStatement.Expression =
                new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.String"), "Format",
                new CodePrimitiveExpression(formattedOutput),
                widthReference, heightReference, areaReference);
            toStringMethod.Statements.Add(returnStatement);
            targetClass.Members.Add(toStringMethod);
        }
        /// <summary>
        /// Add a constructor to the class.
        /// </summary>
        public void AddConstructor()
        {
            // Declare the constructor
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes =
                MemberAttributes.Public | MemberAttributes.Final;

            // Add parameters.
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(
                typeof(System.Double), "width"));
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(
                typeof(System.Double), "height"));

            // Add field initialization logic
            CodeFieldReferenceExpression widthReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "widthValue");
            constructor.Statements.Add(new CodeAssignStatement(widthReference,
                new CodeArgumentReferenceExpression("width")));
            CodeFieldReferenceExpression heightReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "heightValue");
            constructor.Statements.Add(new CodeAssignStatement(heightReference,
                new CodeArgumentReferenceExpression("height")));
            targetClass.Members.Add(constructor);
        }

        /// <summary>
        /// Add an entry point to the class.
        /// </summary>
        public void AddEntryPoint()
        {
            // following code fill be generated
            /// public static void Main()
            /// {
            ///     CodeDOMRectangleClass rectangleObject = new CodeDOMRectangleClass(15.0D, 10.0D);
            ///     System.Console.WriteLine(rectangleObject.ToString());
            /// }

            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeObjectCreateExpression objectCreate =
                new CodeObjectCreateExpression(
                new CodeTypeReference("CodeDOMRectangleClass"),
                new CodePrimitiveExpression(15.0),
                new CodePrimitiveExpression(10.0));

            // Add the statement:
            // "CodeDOMRectangleClass rectangleObject =
            //     new CodeDOMRectangleClass(15.0, 10.0);"
            start.Statements.Add(new CodeVariableDeclarationStatement(
                new CodeTypeReference("CodeDOMRectangleClass"), "rectangleObject",
                objectCreate));

            // Creat the expression:
            // "rectangleObject.ToString()"
            CodeMethodInvokeExpression toStringInvoke =
                new CodeMethodInvokeExpression(
                new CodeVariableReferenceExpression("rectangleObject"), "ToString");

            // Add a System.Console.WriteLine statement with the previous
            // expression as a parameter.
            start.Statements.Add(new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine", toStringInvoke));
            targetClass.Members.Add(start);
        }
        /// <summary>
        /// Generate source code from the compile unit.
        /// </summary>
        /// <param name="filename">Output file name</param>
        public void GenerateTargetCode(string fileName)
        {
            var provider = new CSharpCodeProvider();
            //var provider = CodeDomProvider.CreateProvider("CSharp");
            //var provider = CodeDomProvider.CreateProvider("JScript");
            //var provider = CodeDomProvider.CreateProvider("VB");

            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter(fileName  ))
            {
                provider.GenerateCodeFromCompileUnit(
                    targetUnit, sourceWriter, options);
            }
        }

        /// <summary>
        /// The name of the file to contain the source code.
        /// </summary>
        public const string OutputFileName = "Main.cs";

        /// <summary>
        /// The project of the file to contain the source code.
        /// </summary>
        public const string TargetProject = "TargetCodeDOM";

        /// <summary>
        /// The path to the file to contain the source code in target project.
        /// </summary>
        /// <returns></returns>
        public static string OutputFileOfTargetProject
        {
            get { return String.Format(@"..\..\..\{0}\{1}", TargetProject, OutputFileName); }
        }

        /// <summary>
        /// The path to the file to contain the source code in current project.
        /// </summary>
        /// <returns></returns>
        public static string OutputFileOfCurrProject
        {
            get { return String.Format(@"..\..\{0}", OutputFileName); }
        }

        private static void GenerateCode(string fileName)
        {
            var codeGenerator = new CodeDOMGeneratorSample();
            codeGenerator.AddFields();
            codeGenerator.AddProperties();
            codeGenerator.AddMethod();
            codeGenerator.AddConstructor();
            codeGenerator.AddEntryPoint();
            codeGenerator.GenerateTargetCode(fileName);
        }

        private static void GenerateCodeInTargetProject()
        {
            //if (!File.Exists(OutputFileOfTargetProject))
            //{
                // generate sample class in target project
                GenerateCode(OutputFileOfTargetProject);
            //}
        }
        private static void GenerateCodeInCurrentProject()
        {
            if (!File.Exists(OutputFileOfTargetProject))
            {
                // generate sample class in current project
                GenerateCode(OutputFileOfCurrProject);
                AddGeneratedFileToCurrentProject();
            }
        }

        private static void AddGeneratedFileToCurrentProject()
        {
            var p = new Microsoft.Build.Evaluation.Project(
                String.Format(@"..\..\{0}.csproj", Assembly.GetCallingAssembly().GetName().Name));
            p.AddItem("Compile", OutputFileName);
            p.Save();
        }

    }
}