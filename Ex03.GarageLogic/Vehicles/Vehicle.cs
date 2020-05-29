using System.Collections.Generic;

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

        public abstract override string ToString();
    }
}
