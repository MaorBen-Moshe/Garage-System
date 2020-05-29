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

        private eTypeOfVehicles m_VehicleToCreate;
        private readonly string r_ErrorMessage;

        public CreatingVehicles(eTypeOfVehicles i_VehicleToCreate)
        {
             m_VehicleToCreate = i_VehicleToCreate;
             r_ErrorMessage = string.Format("Fail creating {0}", m_VehicleToCreate.ToString());
        }

        public string VehicleToCreate
        {
            set
            {
                bool isValid = Enum.TryParse(value, out eTypeOfVehicles result);
                if(isValid)
                {
                    m_VehicleToCreate = result;
                }
                else
                {
                    throw new ArgumentException(
                        string.Format("There is not {0} type of vehicle in the garage", value));
                }
            }
        }

        public eTypeOfVehicles VehicleType
        {
            get
            {
                return m_VehicleToCreate;
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
