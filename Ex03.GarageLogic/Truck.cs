using System;

namespace Ex03.GarageLogic
{
    public class Truck : FuelVehicle
    {
        private const float k_MaxTankFuel = 120;
        private float m_CargoVolume;
        private bool m_IsHaveHazardousMaterials;

        public Truck(string i_VehicleModel,
                     string i_VehicleLicenseNumber,
                     byte i_NumberOfWheels,
                     float i_CurrentTankFuel,
                     eFuelType i_FuelType,
                     float i_CargoVolume,
                     bool i_IsHaveHazardousMaterials)
            : base(i_VehicleModel, 
                i_VehicleLicenseNumber,
                i_CurrentTankFuel / k_MaxTankFuel,
                i_NumberOfWheels,
                i_CurrentTankFuel,
                i_FuelType)
        {
            m_IsHaveHazardousMaterials = i_IsHaveHazardousMaterials;
            m_CargoVolume = i_CargoVolume;
        }

        public override float CurrentTankFuel
        {
            get
            {
                return m_CurrentTankFuel;
            }

            set
            {
                if(value >= 0 && value <= k_MaxTankFuel)
                {
                    m_CurrentTankFuel = value;
                }
                else
                {
                    throw new ValueOutOfRangeException();
                }
            }
        }

        public override float GetMaxTankFuel()
        {
            return k_MaxTankFuel;
        }

        public override void Refueling(float i_FuelToAdd, eFuelType i_VehicleFuelType)
        {
            if(m_FuelType.Equals(i_VehicleFuelType))
            {
                if(m_CurrentTankFuel + i_FuelToAdd <= k_MaxTankFuel)
                {
                    m_CurrentTankFuel += i_FuelToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
