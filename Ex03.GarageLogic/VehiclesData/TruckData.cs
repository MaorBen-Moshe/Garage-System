namespace Ex03.GarageLogic.VehiclesData
{
    public class TruckData : VehicleData
    {
        internal const float k_MaxTankFuel = 120;
        internal const byte k_NumberOfWheels = 16;
        internal const byte k_MaxPressureInWheel = 28;
        private float m_CargoVolume;
        private bool m_IsHaveHazardousMaterials;

        public TruckData(string i_VehicleModel,
                         string i_VehicleLicenseNumber,
                         float i_CurrentEnergy,
                         float i_CargoVolume,
                         bool i_IsHaveHazardousMaterials)
        : base(i_VehicleModel, i_VehicleLicenseNumber, k_NumberOfWheels, i_CurrentEnergy)
        {
            m_MaxEnergy = k_MaxTankFuel;
            EnergyLeft = m_CurrentEnergy / m_MaxEnergy;
            m_CargoVolume = i_CargoVolume;
            m_IsHaveHazardousMaterials = i_IsHaveHazardousMaterials;
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
        }

        public bool IsHaveHazardousMaterials
        {
            get
            {
                return m_IsHaveHazardousMaterials;
            }
        }
    }
}
