namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        internal ElectricCar()
        {
            m_VehicleData = new CarData();
            IntialNewWheelsOfVehicle(CarData.sr_NumberOfWheels, CarData.sr_MaxPressureInWheel);
        }

        public override string[] SetVehicleData
        {
            set
            {
                m_VehicleData.MaxEnergy = k_CarMaxBatteryTime;
                m_VehicleData.GetData(value);
            }
        }

        public override string ToString()
        {
            string baseString = base.ToString();
            baseString += m_VehicleData.ToString();
            return baseString;
        }
    }
}