namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 1.2f;
        private Motorcycle m_MotorcycleDetails;

        public ElectricMotorcycle(string i_VehicleModel,
                                  string i_VehicleLicenseNumber,
                                  float i_CurrentBatteryTime,
                                  string i_LicenseType,
                                  uint i_EngineCapacity)
            : base(i_VehicleModel,
                i_VehicleLicenseNumber,
                Motorcycle.k_NumberOfWheels,
                i_CurrentBatteryTime,
                k_MaxBatteryTime)
        {
            m_MotorcycleDetails = new Motorcycle(i_LicenseType, i_EngineCapacity);
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < m_VehicleWheels.Count; i++)
            {
                m_VehicleWheels.Add(new Wheel(
                    string.Empty,
                    0,
                    Motorcycle.k_MaxPressureInWheel));
            }
        }

        public string LicenseType
        {
            get
            {
                return m_MotorcycleDetails.LicenseType;
            }
        }

        public uint EngineCapacity
        {
            get
            {
                return m_MotorcycleDetails.EngineCapacity;
            }
        }
    }
}
