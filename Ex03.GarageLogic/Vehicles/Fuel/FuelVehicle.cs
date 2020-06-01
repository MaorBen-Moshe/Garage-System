using System;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        public const float k_CarMaxTankFuel = 60;
        public const float k_MotorcycleMaxTankFuel = 7;
        protected eFuelType m_FuelType;

        protected FuelVehicle(VehicleData i_VehicleData, eFuelType i_FuelType)
            : base(i_VehicleData)
        {
            FuelType = i_FuelType;
        }

        internal eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                string fuelTypeName = value.ToString();
                bool isValid = Enum.TryParse(fuelTypeName, out m_FuelType) && Enum.IsDefined(typeof(eFuelType), fuelTypeName);
                if(!isValid)
                {
                    throw new ArgumentException(@"This not a valid type of fuel");
                }
            }
        }

        internal virtual void Refueling(float i_FuelToAdd, eFuelType i_VehicleFuelType)
        {
            if (m_FuelType.Equals(i_VehicleFuelType))
            {
                if (r_VehicleData.CurrentEnergy + i_FuelToAdd <= r_VehicleData.MaxEnergy)
                {
                    r_VehicleData.CurrentEnergy += i_FuelToAdd;
                    r_VehicleData.EnergyLeft = r_VehicleData.CurrentEnergy / r_VehicleData.MaxEnergy;
                }
                else
                {
                    string message = "Fail refueling the vehicle";
                    throw new ValueOutOfRangeException(
                        0,
                        r_VehicleData.MaxEnergy - r_VehicleData.CurrentEnergy,
                        message);
                }
            }
            else
            {
                throw new ArgumentException(
                        string.Format(
                        format: "You cannot add {0} to this vehicle",
                        i_VehicleFuelType.ToString()));
            }
        }

        public override string ToString()
        {
            string basesString = base.ToString();
            basesString += string.Format(
                format: @"
Fuel Type: {0}",
                m_FuelType.ToString());

            return basesString;
        }
    }
}
