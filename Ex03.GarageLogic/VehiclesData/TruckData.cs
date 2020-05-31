namespace Ex03.GarageLogic.VehiclesData
{
    public class TruckData : VehicleData
    {
        internal static readonly float sr_MaxTankFuel = 120;
        internal static readonly byte sr_NumberOfWheels = 16;
        internal static readonly byte sr_MaxPressureInWheel = 28;
        private readonly float r_CargoVolume;
        private readonly bool r_IsHaveHazardousMaterials;

        public TruckData(
            string i_VehicleModel,
            string i_VehicleLicenseNumber,
            float i_CurrentEnergy,
            float i_CargoVolume,
            bool i_IsHaveHazardousMaterials)
        : base(i_VehicleModel, i_VehicleLicenseNumber, sr_NumberOfWheels, i_CurrentEnergy)
        {
            m_MaxEnergy = sr_MaxTankFuel;
            EnergyLeft = m_CurrentEnergy / m_MaxEnergy;
            m_CurrentEnergy = m_CurrentEnergy > m_MaxEnergy ? m_MaxEnergy : m_CurrentEnergy;
            r_CargoVolume = i_CargoVolume;
            r_IsHaveHazardousMaterials = i_IsHaveHazardousMaterials;
        }

        public override string ToString()
        {
            return string.Format(
                format: @"
Cargo volume: {0}
Truck {1} deliver hazardous materials",
                r_CargoVolume,
                r_IsHaveHazardousMaterials ? "is" : "is not");
        }
    }
}
