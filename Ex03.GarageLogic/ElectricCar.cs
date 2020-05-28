namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 2.1f;
        private Car m_CarDetails;
        public ElectricCar(string i_VehicleModel,
                           string i_VehicleLicenseNumber,
                           float i_CurrentBatteryTime,
                           string i_ColorOfCar,
                           byte i_NumberOfDoors)
            : base(i_VehicleModel,
                i_VehicleLicenseNumber,
                Car.k_NumberOfWheels,
                i_CurrentBatteryTime,
                k_MaxBatteryTime)
        {
            m_CarDetails = new Car(i_ColorOfCar, i_NumberOfDoors);
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < m_VehicleWheels.Count; i++)
            {
                m_VehicleWheels.Add(new Wheel(
                    string.Empty,
                    0,
                    Car.k_MaxPressureInWheel));
            }
        }

        public string ColorOfCar
        {
            get
            {
                return m_CarDetails.Color;
            }
        }

        public byte NumberOfDoors
        {
            get
            {
                return m_CarDetails.NumberOfDoors;
            }
        }
    }
}
