namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        public const float k_CarMaxBatteryTime = 2.1f;
        public const float k_MotorcycleMaxBatteryTime = 1.2f;

        public virtual void Loading(float i_ElectricityToAdd)
        {
            if (m_VehicleData.CurrentEnergy + i_ElectricityToAdd <= m_VehicleData.MaxEnergy)
            {
                m_VehicleData.CurrentEnergy += i_ElectricityToAdd;
                m_VehicleData.EnergyLeft = m_VehicleData.CurrentEnergy / m_VehicleData.MaxEnergy;
            }
            else
            {
                string message = "Fail loading the vehicle";
                throw new ValueOutOfRangeException(
                    0,
                    m_VehicleData.MaxEnergy - m_VehicleData.CurrentEnergy, 
                    message);
            }
        }
    }
}