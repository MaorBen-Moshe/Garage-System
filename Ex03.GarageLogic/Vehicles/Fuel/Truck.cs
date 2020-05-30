using Ex03.GarageLogic.VehiclesData;

namespace Ex03.GarageLogic
{
    internal class Truck : FuelVehicle
    {
        internal Truck(VehicleData i_TruckData)
            : base(i_TruckData, eFuelType.Soler)
        {
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < TruckData.k_NumberOfWheels; i++)
            {
                r_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    TruckData.k_MaxPressureInWheel));
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
