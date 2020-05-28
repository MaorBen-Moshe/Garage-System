using System;

namespace Ex03.GarageLogic
{
    public class Truck : FuelVehicle
    {
        private const float k_MaxTankFuel = 120;
        private const byte k_NumberOfWheels = 16;
        internal const byte k_MaxPressureInWheel = 28;
        private float m_CargoVolume;
        private bool m_IsHaveHazardousMaterials;

        public Truck(string i_VehicleModel,
                     string i_VehicleLicenseNumber,
                     float i_CurrentTankFuel,
                     float i_CargoVolume,
                     bool i_IsHaveHazardousMaterials)
            : base(i_VehicleModel, 
                i_VehicleLicenseNumber,
                k_NumberOfWheels,
                i_CurrentTankFuel,
                eFuelType.Soler,
                k_MaxTankFuel)
        {
            m_IsHaveHazardousMaterials = i_IsHaveHazardousMaterials;
            m_CargoVolume = i_CargoVolume;
            IntialNewWheelsOfVehicle();
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(
                    string.Empty,
                    k_MaxPressureInWheel,
                    k_MaxPressureInWheel));
            }
        }
    }
}
