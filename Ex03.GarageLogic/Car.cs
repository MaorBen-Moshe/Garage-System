using System;

namespace Ex03.GarageLogic
{
    internal struct Car
    {
        internal enum eColor
        {
            Red,
            White,
            Black,
            Silver
        }

        internal const byte k_NumberOfWheels = 4;
        internal const byte k_MaxPressureInWheel = 32;
        private eColor? m_Color;
        private readonly byte r_NumberOfDoors;

        internal Car(string i_Color, byte i_NumberOfDoors)
        {
            m_Color = null;
            r_NumberOfDoors = i_NumberOfDoors;
            Color = i_Color;
        }

        internal string Color
        {
            get
            {
                if(m_Color.HasValue)
                {
                    return m_Color.ToString();
                }

                throw new ArgumentNullException();
            }

            set
            {
                bool isValidColor = Enum.TryParse(value, out eColor result);
                if (isValidColor)
                {
                    m_Color = result;
                }
                else
                {
                    throw new FormatException();
                }
            }
        }

        internal byte NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }
    }
}
