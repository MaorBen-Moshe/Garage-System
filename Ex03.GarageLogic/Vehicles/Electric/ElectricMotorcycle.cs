namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        internal ElectricMotorcycle()
        {
            m_VehicleData = new MotorcycleData();
            IntialNewWheelsOfVehicle();
        }

        public override string[] SetVehicleData
        {
            set
            {
                m_VehicleData.MaxEnergy = k_MotorcycleMaxBatteryTime;
                m_VehicleData.GetData(value);
            }
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < MotorcycleData.sr_NumberOfWheels; i++)
            {
                m_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    MotorcycleData.sr_MaxPressureInWheel));
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
