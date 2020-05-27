using System;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        public enum eFuelType
        {
            Octan95 = 95,
            Octan96 = 96,
            Octan98 = 98,
            Soler
        }

        protected eFuelType m_FuelType;
        protected float m_CurrentTankFuel;

        protected FuelVehicle(string i_VehicleModel,
                              string i_VehicleLicenseNumber,
                              float i_EnergyLeft,
                              byte i_NumberOfWheels,
                              float i_CurrentTankFuel,
                              eFuelType i_FuelType)
            : base(i_VehicleModel, i_VehicleLicenseNumber, i_EnergyLeft, i_NumberOfWheels)
        {
            FuelType = i_FuelType;
            CurrentTankFuel = i_CurrentTankFuel;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                string fuelTypeName = value.ToString();
                bool isValid = Enum.TryParse(fuelTypeName, out m_FuelType);
                if(!isValid)
                {
                    throw new ArgumentException();
                }
            }
        }

        public abstract float CurrentTankFuel { get; set; }

        public abstract float GetMaxTankFuel();

        public abstract void Refueling(float i_FuelToAdd, eFuelType i_VehicleFuelType);
    }
}
