namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        internal ElectricMotorcycle(MotorcycleData i_MotorcycleData)
            : base(i_MotorcycleData)
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
