using System;

namespace Ex03.GarageLogic
{
    public class CarData : VehicleData
    {
        internal enum eColor
        {
            Red = 1,
            White,
            Black,
            Silver
        }

        internal const byte k_NumberOfWheels = 4;
        internal const byte k_MaxPressureInWheel = 32;
        private byte m_NumberOfDoors;
        private eColor? m_Color;

        public CarData(
            string i_VehicleModel,
            string i_VehicleLicenseNumber,
            float i_CurrentEnergy,
            string i_Color,
            byte i_NumberOfDoors)
            : base(i_VehicleModel, i_VehicleLicenseNumber, k_NumberOfWheels, i_CurrentEnergy)
        {
            NumberOfDoors = i_NumberOfDoors;
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
                bool isValidColor = Enum.TryParse(value, out eColor result) && Enum.IsDefined(typeof(eColor), result);
                if(isValidColor)
                {
                    m_Color = result;
                }
                else
                {
                    throw new FormatException("Fail parsing the car color");
                }
            }
        }

        internal byte NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                if(!(value >= 2 && value <= 5))
                {
                    throw new ValueOutOfRangeException(2, 5);
                }

                m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                format: @"
Color: {0},
The car has {1} doors",
                m_Color,
                m_NumberOfDoors);
        }
    }
}