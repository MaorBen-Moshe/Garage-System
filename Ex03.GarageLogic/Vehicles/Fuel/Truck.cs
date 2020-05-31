using Ex03.GarageLogic.VehiclesData;

namespace Ex03.GarageLogic
{
    internal class Truck : FuelVehicle
    {
        internal Truck(TruckData i_TruckData)
            : base(i_TruckData, eFuelType.Soler)
        {
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < TruckData.sr_NumberOfWheels; i++)
            {
                r_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    TruckData.sr_MaxPressureInWheel));
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
