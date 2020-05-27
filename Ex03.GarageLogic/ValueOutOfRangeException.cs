using System;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;
    }
}
