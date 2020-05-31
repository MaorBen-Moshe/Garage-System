namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        public const float k_CarMaxBatteryTime = 2.1f;
        public const float k_MotorcycleMaxBatteryTime = 1.2f;

        protected ElectricVehicle(VehicleData i_VehicleData)
            : base(i_VehicleData)
        {
        }

        public virtual void Loading(float i_ElectricityToAdd)
        {
            if (r_VehicleData.CurrentEnergy + i_ElectricityToAdd <= r_VehicleData.MaxEnergy)
            {
                r_VehicleData.CurrentEnergy += i_ElectricityToAdd;
            }
            else
            {
                string message = "Fail loading the vehicle";
                throw new ValueOutOfRangeException(
                    0,
                    r_VehicleData.MaxEnergy - r_VehicleData.CurrentEnergy, 
                    message);
            }
        }
    }
}