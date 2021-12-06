﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
// </auto-generated>
//------------------------------------------------------------------------------
namespace PolygonTestCircle
{
    using System;

    public sealed class CirclePolygon
    {
        // Attributes (fields)
        private double m_Radius = 10.0;

        // Attributes (properties)
        public double Radius { get { return this.m_Radius; } }

        // Derived attributes (co-properties)
        public double Diameter { get { return 2 * Radius; } }

        // Main values
        public double Area { get { return Math.PI * Math.Pow(Radius, 2); } }
        public double Perimeter { get { return 2 * Math.PI * Radius; } }

        public override string ToString()
        {
            // Polygon main values
            var result = $"The Circle object:\r\n   Area = {this.Area}\r\n   Perimeter = {this.Perimeter}";
            // Polygon main attributes
            result += "\r\n--------\r\n Main attributes:";
            result += $"\r\n   Radius = {this.Radius}";
            // Polygon derived attributes
            result += "\r\n--------\r\n Derived attributes:";
            result += $"\r\n   Diameter = {this.Diameter}";
            return result;
        }

        public static void Main()
        {
            var polygon = new CirclePolygon();

            System.Console.WriteLine(polygon.ToString());
        }
    }
}
