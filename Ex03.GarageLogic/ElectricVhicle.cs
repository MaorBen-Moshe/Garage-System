namespace Ex03.GarageLogic
{
    public abstract class ElectricVhicle : Vehicle
    {
        protected float m_CurrentLoad;

        protected ElectricVhicle(
            string i_VehicleModel,
            string i_VehicleLicenseNumber,
            float i_EnergyLeft,
            byte i_NumberOfWheels,
            float i_CurrentLoad)
            : base(i_VehicleModel, i_VehicleLicenseNumber, i_EnergyLeft, i_NumberOfWheels)
        {
            CurrentLoad = i_CurrentLoad;
        }

        public abstract float CurrentLoad { get; set; }

        public abstract float getTimeLeftInBattery();

        public abstract float getMaxTimeOfBattery();

        public abstract void Loading(float i_ElectricityToAdd);
    }
}


