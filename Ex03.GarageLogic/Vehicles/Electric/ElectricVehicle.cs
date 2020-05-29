namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        protected ElectricVehicle(VehicleData i_VehicleData)
            : base(i_VehicleData)
        {
        }

        public float CurrentBatteryTime
        {
            get
            {
                return r_VehicleData.CurrentEnergy;
            }

            set
            {
                if (value >= 0 && value <= r_VehicleData.MaxEnergy)
                {
                    r_VehicleData.CurrentEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_VehicleData.MaxEnergy);
                }
            }
        }

        public virtual float MaxBatteryTime
        {
            get
            {
                return r_VehicleData.MaxEnergy;
            }
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


