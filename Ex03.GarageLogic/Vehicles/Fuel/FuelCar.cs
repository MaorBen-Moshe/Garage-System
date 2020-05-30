namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        private const float k_MaxTankFuel = 60;

        internal FuelCar(VehicleData i_CarData)
            : base(i_CarData, eFuelType.Octan96)
        {
            r_VehicleData.MaxEnergy = 60;
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
                    CarData.k_MaxPressureInWheel));
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
