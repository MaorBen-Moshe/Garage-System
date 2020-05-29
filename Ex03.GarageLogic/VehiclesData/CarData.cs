using System;

namespace Ex03.GarageLogic
{
    public class CarData : VehicleData
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

        public CarData(string i_VehicleModel,
                       string i_VehicleLicenseNumber,
                       float i_CurrentEnergy,
                       string i_Color,
                       byte i_NumberOfDoors)
            : base(i_VehicleModel, i_VehicleLicenseNumber, k_NumberOfWheels, i_CurrentEnergy)
        {
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

        public override string ToString()
        {
            return string.Format(
                format: @"
Color: {0},
The car has {1} doors",
                m_Color,
                r_NumberOfDoors);
        }
    }
}
