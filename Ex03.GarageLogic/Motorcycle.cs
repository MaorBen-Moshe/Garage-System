using System;

namespace Ex03.GarageLogic
{
    internal struct Motorcycle
    {
        internal enum eLicenseType
        {
            A,
            A1,
            Aa,
            B
        }

        private eLicenseType? m_LicenseType;
        private uint m_EngineCapacity;
        internal const byte k_NumberOfWheels = 2;
        internal const byte k_MaxPressureInWheel = 30;

        internal Motorcycle(string i_LicenseType, uint i_EngineCapacity)
        {
            m_LicenseType = null;
            m_EngineCapacity = 0;
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
                bool isValidLicesneType = Enum.TryParse(value, out eLicenseType result);
                if(isValidLicesneType)
                {
                    m_LicenseType = result;
                }
                else
                {
                    throw new FormatException();
                }
            }
        }
    }
}
