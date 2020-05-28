using System;

namespace Ex03.GarageLogic
{
    public class CreatingVehicles
    {
        public enum eTypeOfVehicles
        {
            FuelCar,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            Truck
        }

        private eTypeOfVehicles m_VehicleToCreate;
        private string m_ErrorMessage;

        public CreatingVehicles(string i_VehicleToCreate)
        {
             VehicleToCreate = i_VehicleToCreate;
             m_ErrorMessage = string.Format("Fail creating {0}", m_VehicleToCreate.ToString());
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

        public Vehicle CreateFuelCar(string i_VehicleModel,
                                     string i_VehicleLicenseNumber,
                                     float i_CurrentTankFuel,
                                     string i_ColorOfCar,
                                     byte i_NumberOfDoors)
        {
            try
            {
                Vehicle newFuelCar = new FuelCar(
                    i_VehicleModel,
                    i_VehicleLicenseNumber,
                    i_CurrentTankFuel,
                    i_ColorOfCar,
                    i_NumberOfDoors);
                return newFuelCar;
            }
            catch(Exception ex)
            {
                string message= "Fail creating fuel car!";
                throw new Exception(message, ex);
            }
        }

        public Vehicle CreateElectricCar(string i_VehicleModel,
                                         string i_VehicleLicenseNumber,
                                         float i_CurrentBatteryTime,
                                         string i_ColorOfCar,
                                         byte i_NumberOfDoors)
        {
            try
            {
                Vehicle newElectricCar = new ElectricCar(
                    i_VehicleModel,
                    i_VehicleLicenseNumber,
                    i_CurrentBatteryTime,
                    i_ColorOfCar,
                    i_NumberOfDoors);
                return newElectricCar;
            }
            catch (Exception ex)
            {
                throw new Exception(m_ErrorMessage, ex);
            }
        }

        public Vehicle CreateFuelMotorcycle(string i_VehicleModel,
                                            string i_VehicleLicenseNumber,
                                            float i_CurrentTankFuel,
                                            string i_LicenseType,
                                            uint i_EngineCapacity)
        {
            try
            {
                Vehicle newFuelMotorcycle = new FuelMotorcycle(
                    i_VehicleModel,
                    i_VehicleLicenseNumber,
                    i_CurrentTankFuel,
                    i_LicenseType,
                    i_EngineCapacity);
                return newFuelMotorcycle;
            }
            catch(Exception ex)
            {
                throw new Exception(m_ErrorMessage, ex);
            }
        }

        public Vehicle CreateElectricMotorcycle(string i_VehicleModel,
                                                string i_VehicleLicenseNumber,
                                                float i_CurrentBatteryTime,
                                                string i_LicenseType,
                                                uint i_EngineCapacity)
        {
            try
            {
                Vehicle newElectricMotorcycle = new ElectricMotorcycle(
                    i_VehicleModel,
                    i_VehicleLicenseNumber,
                    i_CurrentBatteryTime,
                    i_LicenseType,
                    i_EngineCapacity);
                return newElectricMotorcycle;
            }
            catch (Exception ex)
            {
                throw new Exception(m_ErrorMessage, ex);
            }
        }

        public Vehicle CreateTruck(string i_VehicleModel,
                                   string i_VehicleLicenseNumber,
                                   float i_CurrentTankFuel,
                                   float i_CargoVolume,
                                   bool i_IsHaveHazardousMaterials)
        {
            try
            {
                Vehicle newTruck = new Truck(
                    i_VehicleModel,
                    i_VehicleLicenseNumber,
                    i_CurrentTankFuel,
                    i_CargoVolume,
                    i_IsHaveHazardousMaterials);
                return newTruck;
            }
            catch(Exception ex)
            {
                throw new Exception(m_ErrorMessage, ex);
            }
        }
    }
}
