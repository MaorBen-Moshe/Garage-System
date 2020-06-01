using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly VehicleData r_VehicleData;

        protected Vehicle(VehicleData i_VehicleData)
        {
            r_VehicleData = i_VehicleData;
        }

        protected abstract void IntialNewWheelsOfVehicle();

        internal string LicenseNumber
        {
            get
            {
                return r_VehicleData.VehicleLicenseNumber;
            }
        }

        internal float CurrentEnergy
        {
            get
            {
                return r_VehicleData.CurrentEnergy;
            }
        }

        internal float MaxEnergy
        {
            get
            {
                return r_VehicleData.MaxEnergy;
            }
        }

        internal List<VehicleData.Wheel> Wheels
        {
            get
            {
                return r_VehicleData.VehicleWheels;
            }
        }

        public override string ToString()
        { 
            return string.Format(
                format: @"Vehicle Model: {0}
Vehicle License: {1}
Wheel Data: 
{2}
Energy Left: {3:0.00} %
Current Energy: {4}",
                r_VehicleData.VehicleModel,
                r_VehicleData.VehicleLicenseNumber,
                printWheels(),
                r_VehicleData.EnergyLeft * 100,
                r_VehicleData.CurrentEnergy);
        }

        private StringBuilder printWheels()
        {
            StringBuilder wheelList = new StringBuilder();
            int index = 0;
            foreach (VehicleData.Wheel currentWheel in r_VehicleData.VehicleWheels)
            {
                wheelList.AppendLine(string.Format(format:@"Wheel {0}: {1}", ++index, currentWheel.ToString()));
            }

            return wheelList;
        }
    }
}
