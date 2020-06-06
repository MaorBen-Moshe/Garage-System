using Ex03.GarageLogic.VehiclesData;

namespace Ex03.GarageLogic
{
    internal class Truck : FuelVehicle
    {
        internal Truck()
            : base(eFuelType.Soler)
        {
            m_VehicleData = new TruckData();
            IntialNewWheelsOfVehicle(TruckData.k_NumberOfWheels, TruckData.k_MaxPressureInWheel);
        }

        public override string[] SetVehicleData
        {
            set
            {
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
