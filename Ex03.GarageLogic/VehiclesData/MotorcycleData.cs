using System;

namespace Ex03.GarageLogic
{
    public class MotorcycleData : VehicleData
    {
        internal enum eLicenseType
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

        public MotorcycleData(
            string i_VehicleModel,
            string i_VehicleLicenseNumber,
            float i_CurrentEnergy,
            string i_LicenseType, 
            uint i_EngineCapacity,
            float i_MaxEnergy)
        : base(i_VehicleModel, i_VehicleLicenseNumber, sr_NumberOfWheels, i_CurrentEnergy, i_MaxEnergy)
        {
            LicenseType = i_LicenseType;
            EngineCapacity = i_EngineCapacity;
        }

        internal uint EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
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
