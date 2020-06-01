﻿using System;

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

        internal static readonly byte sr_NumberOfWheels = 4;
        internal static readonly byte sr_MaxPressureInWheel = 32;
        private byte m_NumberOfDoors;
        private eColor? m_Color;

        public CarData(
            string i_VehicleModel,
            string i_VehicleLicenseNumber,
            float i_CurrentEnergy,
            string i_Color,
            byte i_NumberOfDoors,
            float i_MaxEnergy)
            : base(i_VehicleModel, i_VehicleLicenseNumber, sr_NumberOfWheels, i_CurrentEnergy, i_MaxEnergy)
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
                    string message = "Fail adding the number of doors";
                    throw new ValueOutOfRangeException(2, 5, message);
                }

                m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                format: @"
Color: {0}
The car has {1} doors",
                m_Color,
                m_NumberOfDoors);
        }
    }
}