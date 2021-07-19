using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GenExampleRuntimeT4
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
            File.WriteAllText(OutputFileOfTargetProject, gencodeMainText);
            Console.WriteLine("Generated file: " + OutputFileOfTargetProject);

            var gencodeReport = new MainReport();
            String gencodeReportText = gencodeReport.TransformText();
            File.WriteAllText(ReportFilename, gencodeReportText);
            System.Diagnostics.Process.Start(ReportFilename);
        }
    }
}
