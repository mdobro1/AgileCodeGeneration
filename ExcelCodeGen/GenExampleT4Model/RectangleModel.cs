using System;
using System.Collections.Generic;
using System.Text;

namespace GenExampleT4Model
{
    public static class RectangleModel
    {
        public const string Namespace = "T4Sample";
        public const string Class = "T4SampleRectangle";
        public const string Types = "double,double";
        public const string Fields = "width,height";
        public const string Properties = "Width,Height";
        public const string InitialValues = "5.3D,6.9D";
        public const string AreaFormula = "Width * Height";

        public static void Test()
        {
            foreach (var type in Types.Split(','))
            {
                int[] i = default(int[]);
                //i.Length    

            }
        }
    }
}

/*
namespace CodeDOMSample 
{
    using System;   
    
    public sealed class CodeDOMCreatedClass
    {
        
        // The width of the object.
        private double widthValue;
        
        // The height of the object.
        private double heightValue;
        
        public CodeDOMCreatedClass(double width, double height)
        {
            this.widthValue = width;
            this.heightValue = height;
        }
        
        // The Width property for the object.
        public double Width
        {
            get
            {
                return this.widthValue;
            }
        }
        
        // The Height property for the object.
        public double Height
        {
            get
            {
                return this.heightValue;
            }
        }
        
        // The Area property for the object.
        public double Area
        {
            get
            {
                return (this.widthValue * this.heightValue);
            }
        }
        
        public override string ToString()
        {
            return string.Format("The object:\r\n width = {0},\r\n height = {1},\r\n area = {2}", this.Width, this.Height, this.Area);
        }
        
        public static void Main()
        {
            CodeDOMCreatedClass testClass = new CodeDOMCreatedClass(5.3D, 6.9D);
            System.Console.WriteLine(testClass.ToString());
        }
    }
}
*/
