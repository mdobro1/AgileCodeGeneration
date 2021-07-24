using System;
using FlatModels;

namespace GenExampleDirect
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            string gencodeReportText = "";
            string fileHtmlReport = "PolygonReport.html";

            // generate polygon report (HTML-code)
            gencodeReportText = GenerateHtmlReport();

            // write report to the file and show in browser
            System.IO.File.WriteAllText(fileHtmlReport, gencodeReportText);
            System.Diagnostics.Process.Start(fileHtmlReport);
        }

        private static string GenerateHtmlReport()
        {
            string reportResult = "";
            reportResult += "<!--Dieser Code wurde von einem Tool generiert. -->";
            reportResult += $"<h1> Report of \"{CircleModel.Class}\"-Object </h1>";
            reportResult += "    <hr><h2> Properties:</h2>";
            reportResult += "        <table>";
            for (int i = 0; i < CircleModel.PropertiesValues.Length; i++)
            {
                reportResult += "        <tr>";
                reportResult += $"        <td> {CircleModel.PropertiesNames[i]} = </td>";
                reportResult += $"        <td> {CircleModel.PropertiesValues[i]} </td>";
                reportResult += "        </tr>";
            }
            reportResult += "</table>";
            reportResult += "<hr><h2> Calculated Values:</h2>";
            reportResult += $"    Area = {CircleModel.AreaValue},";
            reportResult += $"    Perimeter = {CircleModel.PerimeterValue}";
            reportResult += "</body></html>";
            return reportResult;
        }
    }
}
