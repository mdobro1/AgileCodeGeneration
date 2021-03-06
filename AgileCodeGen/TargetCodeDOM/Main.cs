//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeDOMPolygonSample
{
    using System;
    
    
    public sealed class CodeDOMRectangleClass
    {
        
        // The width of the object.
        private double widthValue;
        
        // The height of the object.
        private double heightValue;
        
        public CodeDOMRectangleClass(double width, double height)
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
            return string.Format("The rectangle object:\r\n width = {0},\r\n height = {1},\r\n area = {2}", this.Width, this.Height, this.Area);
        }
        
        public static void Main()
        {
            CodeDOMRectangleClass rectangleObject = new CodeDOMRectangleClass(15D, 10D);
            System.Console.WriteLine(rectangleObject.ToString());
        }
    }
}
