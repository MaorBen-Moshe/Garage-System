using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly VehicleData r_VehicleData;
        protected string VehicleLicenseNumber
        {
            get
            {
                return r_VehicleData.VehicleLicenseNumber;
            }
        }

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


        internal List<VehicleData.Wheel> Wheels
        {
            get
            {
                return r_VehicleData.VehicleWheels;
            }
        }

        private StringBuilder printWheels()
        {
            StringBuilder wheelList = new StringBuilder();
            int index = 0;
            foreach(VehicleData.Wheel currentWheel in r_VehicleData.VehicleWheels)
            {
                wheelList.AppendLine(string.Format("Wheel {0}: {1}", index++, currentWheel.ToString()));
            }
            return wheelList;
        }

        public override string ToString()
        { 
            return string.Format(
                format: @"Vechile Model: {0}
Vechile License: {1},
Wheel Data: {2},
Energy Left: {3:p},
Current Energy: {4}",
                r_VehicleData.VehicleModel,
                r_VehicleData.VehicleLicenseNumber,
                printWheels(),
                r_VehicleData.EnergyLeft * 100,
                r_VehicleData.CurrentEnergy);
        }
    }
}
