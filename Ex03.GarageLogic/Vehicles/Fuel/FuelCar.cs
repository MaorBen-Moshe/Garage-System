namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        internal FuelCar()
            : base(eFuelType.Octan96)
        {
            m_VehicleData = new CarData();
            IntialNewWheelsOfVehicle(CarData.k_NumberOfWheels, CarData.k_MaxPressureInWheel);
        }

        public override string[] SetVehicleData
        {
            set
            {
                m_VehicleData.MaxEnergy = k_CarMaxTankFuel;
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
