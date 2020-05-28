using System;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private const float k_MaxTankFuel = 60;
        private Car m_CarDetails;

        public FuelCar(string i_VehicleModel,
                       string i_VehicleLicenseNumber, 
                       float i_CurrentTankFuel,
                       string i_ColorOfCar,
                       byte i_NumberOfDoors)
            : base(i_VehicleModel,
                i_VehicleLicenseNumber,
                Car.k_NumberOfWheels,
                i_CurrentTankFuel,
                eFuelType.Octan96,
                k_MaxTankFuel)
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
