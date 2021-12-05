using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenExampleT4Dynamic
{
    class Program
    {
        public const string OutputFileName = "Main.cs";
        public const string TargetProject = "TargetRuntimeT4";
        public static string OutputFileOfTargetProject
        {
            get { return $@"..\..\..\{TargetProject}\{OutputFileName}"; }
        }
        public static string ReportFilename { get { return "MainReport.html"; } }

        static void Main(string[] args)
        {
            var gencodeMain = new Main();
            var gencodeReport = new MainReport();

            String gencodeMainText = gencodeMain.TransformText();
            String gencodeReportText = gencodeReport.TransformText();
            
            System.IO.File.WriteAllText(OutputFileOfTargetProject, gencodeMainText);
            System.IO.File.WriteAllText(ReportFilename, gencodeReportText);

            Console.WriteLine("Generated file: " + OutputFileOfTargetProject);
            System.Diagnostics.Process.Start(ReportFilename);
        }
    }
}
