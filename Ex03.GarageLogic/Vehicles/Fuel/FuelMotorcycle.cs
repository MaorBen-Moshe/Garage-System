using System;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        internal FuelMotorcycle()
            : base(eFuelType.Octan95)
        {
            m_VehicleData = new MotorcycleData();
            IntialNewWheelsOfVehicle(MotorcycleData.k_NumberOfWheels, MotorcycleData.k_MaxPressureInWheel);
        }

        public override string[] SetVehicleData
        {
            set
            {
                m_VehicleData.MaxEnergy = k_MotorcycleMaxTankFuel;
                m_VehicleData.GetData(value);
            }
        }

        public override string ToString()
        {
            string baseString = base.ToString();
            baseString += m_VehicleData.ToString();
            return baseString;
        }
    }
}
