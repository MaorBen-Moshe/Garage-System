namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        private const float k_MaxTankFuel = 7;

        internal FuelMotorcycle(VehicleData i_MotorcycleData)
            : base(i_MotorcycleData, eFuelType.Octan95)
        {
            r_VehicleData.MaxEnergy = k_MaxTankFuel;
            r_VehicleData.EnergyLeft = r_VehicleData.CurrentEnergy / k_MaxTankFuel;
            MaintainCurrentEnergy();
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < r_VehicleData.VehicleWheels.Capacity; i++)
            {
                r_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    MotorcycleData.k_MaxPressureInWheel));
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
