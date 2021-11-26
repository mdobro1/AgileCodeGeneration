using System;
using System.Collections.Generic;
using System.Text;

namespace FlatModels
{
    public static class CircleModel
    {
        // definitions
        public const string Namespace = "PolygonSamples";
        public const string Class = "SampleCircle";
        public const string Types = "double,double";
        public const string Fields = "radius,diameter";
        public const string Properties = "Radius,Diameter";
        public const string Values = "10,20";
        // calculations
        public static string[] PropertiesValues = Values.Split(',');
        public static string[] PropertiesNames = Properties.Split(',');
        public static double RadiusValue = Convert.ToDouble(PropertiesValues[0]);
        public static double DiameterValue = 2 * RadiusValue;
        public static double AreaValue = Math.PI * Math.Pow(RadiusValue, 2);
        public static double PerimeterValue = Math.PI * DiameterValue;
    }
}
