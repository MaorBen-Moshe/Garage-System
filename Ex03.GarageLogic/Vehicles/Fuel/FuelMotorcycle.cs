namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        internal FuelMotorcycle(MotorcycleData i_MotorcycleData)
            : base(i_MotorcycleData, eFuelType.Octan95)
        {
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
