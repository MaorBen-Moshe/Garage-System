using System.Collections.Generic;
using Ex03.GarageLogic.VehiclesData;

namespace Ex03.GarageLogic
{
    internal class Truck : FuelVehicle
    {
        internal Truck()
            : base(eFuelType.Soler)
        {
            m_VehicleData = new TruckData();
            IntialNewWheelsOfVehicle();
        }

        public override string[] SetVehicleData
        {
            set
            {
                m_VehicleData.GetData(value);
            }
        }

        protected sealed override void IntialNewWheelsOfVehicle()
        {
            for (int i = 0; i < TruckData.sr_NumberOfWheels; i++)
            {
                m_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    TruckData.sr_MaxPressureInWheel));
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
