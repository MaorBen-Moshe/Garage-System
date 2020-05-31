namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 1.2f;

        internal ElectricMotorcycle(MotorcycleData i_MotorcycleData)
            : base(i_MotorcycleData)
        {
            r_VehicleData.MaxEnergy = k_MaxBatteryTime;
            MaintainCurrentEnergy();
            r_VehicleData.EnergyLeft = r_VehicleData.CurrentEnergy / k_MaxBatteryTime;
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < r_VehicleData.VehicleWheels.Capacity; i++)
            {
                r_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    MotorcycleData.sr_MaxPressureInWheel));
            }
        }

        public override string ToString()
        {
            string baseString = base.ToString();
            baseString += r_VehicleData.ToString();
            return baseString;
        }
    }
}
