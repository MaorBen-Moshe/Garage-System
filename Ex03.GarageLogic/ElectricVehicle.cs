namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        protected float m_CurrentBatteryTime;
        protected float m_MaxBatteryTime;

        protected ElectricVehicle(
            string i_VehicleModel,
            string i_VehicleLicenseNumber,
            byte i_NumberOfWheels,
            float i_CurrentBatteryTime,
            float i_MaxBatteryTime)
            : base(i_VehicleModel,
                i_VehicleLicenseNumber,
                i_CurrentBatteryTime / i_MaxBatteryTime,
                i_NumberOfWheels)
        {
            CurrentBatteryTime = i_CurrentBatteryTime;
            m_MaxBatteryTime = i_MaxBatteryTime;
        }

        public float CurrentBatteryTime
        {
            get
            {
                return m_CurrentBatteryTime;
            }

            set
            {
                if (value >= 0 && value <= m_MaxBatteryTime)
                {
                    m_CurrentBatteryTime = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxBatteryTime);
                }
            }
        }

        public virtual float MaxBatteryTime
        {
            get
            {
                return m_MaxBatteryTime;
            }
        }

        public virtual void Loading(float i_ElectricityToAdd)
        {
            if (m_CurrentBatteryTime + i_ElectricityToAdd <= m_MaxBatteryTime)
            {
                m_CurrentBatteryTime += i_ElectricityToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxBatteryTime - m_CurrentBatteryTime);
            }
        }
    }
}


