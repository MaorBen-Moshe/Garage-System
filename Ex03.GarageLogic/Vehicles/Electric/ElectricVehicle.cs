namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
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
                throw new ValueOutOfRangeException(
                    0,
                    r_VehicleData.MaxEnergy - r_VehicleData.CurrentEnergy);
            }
        }
    }
}