namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 2.1f;

        public ElectricCar(VehicleData i_CarData)
            : base(i_CarData)
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
                    CarData.k_MaxPressureInWheel));
            }
        }

        public override string ToString()
        {
        }

        public string ColorOfCar
        {
            get
            {
                return (r_VehicleData as CarData).Color;
            }
        }

        public byte NumberOfDoors
        {
            get
            {
                return (r_VehicleData as CarData).NumberOfDoors;
            }
        }
    }
}
