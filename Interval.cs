namespace EducativeGrokkingCodingPatterns
{
    public class Interval
    {
        public Interval(int begin, int end)
        {
            this.begin = begin;
            this.end = end;
        }
        public override string ToString()
        {
            /*
             * $ Means interoplated string
                 An interpolated string allows you to embed expressions inside string literals, using curly braces { }. 
                 The expression inside the curly braces will be evaluated, and its result will be inserted into the resulting string.
            */
            return $"[{begin}, {end}]";
        }

        public int begin;
        public int end;
    }
}
