using System;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private const float k_MaxTankFuel = 60;
        public FuelCar(VehicleData i_CarData)
            : base(i_CarData, eFuelType.Octan96)
        {
            r_VehicleData.MaxEnergy = 60;
            r_VehicleData.EnergyLeft = r_VehicleData.CurrentEnergy / k_MaxTankFuel;
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < r_VehicleData.VehicleWheels.Capacity; i++)
            {
                r_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    CarData.k_MaxPressureInWheel));
            }
        }

        public override string ToString()
        {
            string baseString = base.ToString();
            baseString += r_VehicleData.ToString();
            return baseString;
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
