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
        protected float m_MaxTankFuel;

        protected FuelVehicle(string i_VehicleModel,
                              string i_VehicleLicenseNumber,
                              byte i_NumberOfWheels,
                              float i_CurrentTankFuel,
                              eFuelType i_FuelType,
                              float i_MaxTankFuel)
            : base(i_VehicleModel, i_VehicleLicenseNumber, i_CurrentTankFuel / i_MaxTankFuel, i_NumberOfWheels)
        {
            m_MaxTankFuel = i_MaxTankFuel;
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

        public float CurrentTankFuel
        {
            get
            {
                return m_CurrentTankFuel;
            }

            set
            {
                if (value >= 0 && value <= m_MaxTankFuel)
                {
                    m_CurrentTankFuel = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxTankFuel);
                }
            }
        }

        public float MaxTankFuel
        {
            get
            {
                return m_MaxTankFuel;
            }
        }

        public virtual void Refueling(float i_FuelToAdd, eFuelType i_VehicleFuelType)
        {
            if (m_FuelType.Equals(i_VehicleFuelType))
            {
                if (m_CurrentTankFuel + i_FuelToAdd <= m_MaxTankFuel)
                {
                    m_CurrentTankFuel += i_FuelToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxTankFuel - m_CurrentTankFuel);
                }
            }
            else
            {
                throw new ArgumentException(string.Format(format: "You cannot add {0} to a truck",
                    i_VehicleFuelType.ToString()));
            }
        }
    }
}
