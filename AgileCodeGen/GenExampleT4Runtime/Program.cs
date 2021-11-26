using System;

namespace GenExampleT4Runtime
{
    class Program
    {
        public const string OutputFileName = "Main.cs";
        public const string TargetProject = "TargetRuntimeT4";
        public static string OutputFileOfTargetProject
        {
            get { return String.Format(@"..\..\..\{0}\{1}", TargetProject, OutputFileName); }
        }
        public static string ReportFilename { get { return "MainReport.html"; } }

        static void Main(string[] args)
        {
            var gencodeMain = new Main();
            String gencodeMainText = gencodeMain.TransformText();
            System.IO.File.WriteAllText(OutputFileOfTargetProject, gencodeMainText);
            Console.WriteLine("Generated file: " + OutputFileOfTargetProject);

            var gencodeReport = new MainReport();
            String gencodeReportText = gencodeReport.TransformText();
            System.IO.File.WriteAllText(ReportFilename, gencodeReportText);
            System.Diagnostics.Process.Start(ReportFilename);
        }
    }
}
