using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CarData : VehicleData
    {
        public enum eColor
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

        internal string Color
        {
            get
            {
                if (m_Color.HasValue)
                {
                    return m_Color.ToString();
                }

                throw new ArgumentNullException();
            }

            set
            {
                bool isValidColor = Enum.TryParse(value, out eColor result) && Enum.IsDefined(typeof(eColor), result);
                if (isValidColor)
                {
                    m_Color = result;
                }
                else
                {
                    throw new FormatException("Fail parsing the car color");
                }
            }
        }

        internal string SetNumOfDoors
        {
            set
            {
                bool isValid = byte.TryParse(value, out byte numOfDoors);
                if (isValid)
                {
                    if (!(numOfDoors >= 2 && numOfDoors <= 5))
                    {
                        string message = "Fail adding the number of doors";
                        throw new ValueOutOfRangeException(2, 5, message);
                    }

                    m_NumberOfDoors = numOfDoors;
                }
                else
                {
                    throw new FormatException("Fail adding the number of doors");
                }
            }
        }

        public override StringBuilder AskForData()
        {
            StringBuilder data = base.AskForData();
            data.AppendLine("Enter the color of car: ");
            data.AppendLine("Enter the number of doors: ");
            data.AppendLine("3"); //// Enumerable Indices
            return data;
        }

        public override void GetData(string[] i_AllData)
        {
            m_VehicleModel = i_AllData[0];
            VehicleLicenseNumber = i_AllData[1];
            SetCurrentEnergy = i_AllData[2];
            Color = i_AllData[3];
            SetNumOfDoors = i_AllData[4];
            EnergyLeft = CurrentEnergy / MaxEnergy;
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