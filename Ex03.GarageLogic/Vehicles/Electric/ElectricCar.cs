namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        internal ElectricCar()
        {
            m_VehicleData = new CarData();
            IntialNewWheelsOfVehicle();
        }

        public override string[] SetVehicleData
        {
            set
            {
                m_VehicleData.MaxEnergy = k_CarMaxBatteryTime;
                m_VehicleData.GetData(value);
            }
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < CarData.sr_NumberOfWheels; i++)
            {
                m_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    CarData.sr_MaxPressureInWheel));
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