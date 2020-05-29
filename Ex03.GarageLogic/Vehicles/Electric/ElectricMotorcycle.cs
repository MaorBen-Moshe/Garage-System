namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 1.2f;

        public ElectricMotorcycle(VehicleData i_MotorcycleData)
            : base(i_MotorcycleData)
        {
            r_VehicleData.MaxEnergy = k_MaxBatteryTime;
            r_VehicleData.EnergyLeft = r_VehicleData.CurrentEnergy / k_MaxBatteryTime;
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < r_VehicleData.VehicleWheels.Count; i++)
            {
                r_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    MotorcycleData.k_MaxPressureInWheel));
            }
        }

        public override string ToString()
        {
        }

        public string LicenseType
        {
            get
            {
                return (r_VehicleData as MotorcycleData).LicenseType;
            }
        }

        public uint EngineCapacity
        {
            get
            {
                return (r_VehicleData as MotorcycleData).EngineCapacity;
            }
        }
    }
}
