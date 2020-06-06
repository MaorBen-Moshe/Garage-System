namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        internal ElectricMotorcycle()
        {
            m_VehicleData = new MotorcycleData();
            IntialNewWheelsOfVehicle(MotorcycleData.k_NumberOfWheels, MotorcycleData.k_MaxPressureInWheel);
        }

        public override string[] SetVehicleData
        {
            set
            {
                m_VehicleData.MaxEnergy = k_MotorcycleMaxBatteryTime;
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
