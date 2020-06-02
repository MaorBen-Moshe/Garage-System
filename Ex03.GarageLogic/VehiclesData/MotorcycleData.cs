using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorcycleData : VehicleData
    {
        public enum eLicenseType
        {
            A = 1,
            A1,
            Aa,
            B
        }

        internal static readonly byte sr_NumberOfWheels = 2;
        internal static readonly byte sr_MaxPressureInWheel = 30;
        private eLicenseType? m_LicenseType;
        private uint m_EngineCapacity;

        internal string SetEngineCapacity
        {
            set
            {
                bool isValid = uint.TryParse(value, out uint engineCapacity);
                if(isValid)
                {
                    m_EngineCapacity = engineCapacity;
                }
                else
                {
                    throw new FormatException("Fail adding the engine capacity");
                }
            }
        }

        internal string LicenseType
        {
            get
            {
                if(m_LicenseType.HasValue)
                {
                    return m_LicenseType.ToString();
                }

                throw new ArgumentNullException();
            }

            set
            {
                bool isValidLicesneType = Enum.TryParse(value, out eLicenseType result) 
                                          && Enum.IsDefined(typeof(eLicenseType), result);
                if(isValidLicesneType)
                {
                    m_LicenseType = result;
                }
                else
                {
                    throw new FormatException("Fail parsing the license type of a motorcycle");
                }
            }
        }

        public override StringBuilder AskForData()
        {
            StringBuilder data = base.AskForData();
            data.AppendLine("Enter the license type: ");
            data.AppendLine("Enter the engine capacity: ");
            return data;
        }

        public override void GetData(string[] i_AllData)
        {
            m_VehicleModel = i_AllData[0];
            VehicleLicenseNumber = i_AllData[1];
            SetCurrentEnergy = i_AllData[2];
            LicenseType = i_AllData[3];
            SetEngineCapacity = i_AllData[4];
            EnergyLeft = CurrentEnergy / MaxEnergy;
        }

        public override string ToString()
        {
            return string.Format(
                format: @"
License Type: {0}
Engine Capacity: {1}",
                m_LicenseType,
                m_EngineCapacity);
        }
    }
}
