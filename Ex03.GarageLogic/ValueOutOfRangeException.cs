using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, Exception i_InnerException = null)
        : base(
            string.Format(
                format:"You have exceeded the range of values {0} : {1}", 
                i_MinValue, 
                i_MaxValue),
            i_InnerException)
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }
    }
}
