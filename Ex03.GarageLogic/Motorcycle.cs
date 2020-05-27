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
        private int m_EngineCapacity;

        internal Motorcycle(string i_LicenseType, int i_EngineCapacity)
        {
            m_LicenseType = null;
            m_EngineCapacity = 0;
            EngineCapacity = i_EngineCapacity;
        }

        internal int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                if(value > 0)
                {
                    m_EngineCapacity = value;
                }
                else
                {
                    throw new FormatException();
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
