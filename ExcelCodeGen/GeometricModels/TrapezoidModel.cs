using System;

namespace FlatModels
{
    public static class TrapezoidModel
    {
        public const string Namespace = "PolygonSamples";
        public const string Class = "SampleTrapezoid";
        public const string Types = "double,double,double,double";
        public const string Fields = "shortBase,longBase,leftLeg,rightLeg";
        public const string Properties = "ShortBase,LongBase,LeftLeg,RightLeg";
        public const string InitialValues = "20.0D,30.0D,13.0D,13.0D";
        public const string PerimeterFormula = "ShortBase + LongBase + LeftLeg + RightLeg";
    }
}
