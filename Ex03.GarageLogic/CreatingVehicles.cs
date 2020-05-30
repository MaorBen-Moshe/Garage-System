using System;
using Ex03.GarageLogic.VehiclesData;

namespace Ex03.GarageLogic
{
    public class CreatingVehicles
    {
        public enum eTypeOfVehicles
        {
            FuelCar = 1,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            Truck
        }

        private readonly string r_ErrorMessage;
        private eTypeOfVehicles m_VehicleToCreate;

        public CreatingVehicles(eTypeOfVehicles i_VehicleToCreate)
        {
            VehicleToCreate = i_VehicleToCreate;
            r_ErrorMessage = string.Format("Fail creating {0}", m_VehicleToCreate.ToString());
        }

        public eTypeOfVehicles VehicleToCreate
        {
            set
            {
                bool isValid = Enum.IsDefined(typeof(eTypeOfVehicles), value.ToString());
                if(isValid)
                {
                    m_VehicleToCreate = value;
                }
                else
                {
                    throw new ArgumentException(string.Format("There is not type of vehicle: {0} in the garage", value));
                }
            }
        }

        public Vehicle CreateVehicle(VehicleData i_VehicleData)
        {
            try
            {
                Vehicle vehicleToCreate;
                switch(m_VehicleToCreate)
                {
                    case eTypeOfVehicles.ElectricCar:
                        vehicleToCreate = new ElectricCar(i_VehicleData as CarData);
                        break;
                    case eTypeOfVehicles.ElectricMotorcycle:
                        vehicleToCreate = new ElectricMotorcycle(i_VehicleData as MotorcycleData);
                        break;
                    case eTypeOfVehicles.FuelCar:
                        vehicleToCreate = new FuelCar(i_VehicleData as CarData);
                        break;
                    case eTypeOfVehicles.FuelMotorcycle:
                        vehicleToCreate = new FuelMotorcycle(i_VehicleData as MotorcycleData);
                        break;
                    case eTypeOfVehicles.Truck:
                        vehicleToCreate = new Truck(i_VehicleData as TruckData);
                        break;
                    default:
                        throw new ArgumentException(r_ErrorMessage);
                }

                return vehicleToCreate;
            }
            catch(Exception ex)
            { 
                throw new Exception(r_ErrorMessage, ex);
            }
        }
    }
}
