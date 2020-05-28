﻿using System;

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
        private readonly string r_VehicleModel;
        private readonly string r_LicenseNumber;
        private readonly string r_ErrorMessage;

        public CreatingVehicles(string i_VehicleToCreate, string i_VehicleModel, string i_LicesneNumber)
        {
             VehicleToCreate = i_VehicleToCreate;
             r_VehicleModel = i_VehicleModel;
             r_LicenseNumber = i_LicesneNumber;
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

        public Vehicle CreateFuelCar(float i_CurrentTankFuel,
                                     string i_ColorOfCar,
                                     byte i_NumberOfDoors)
        {
            try
            {
                Vehicle newFuelCar = new FuelCar(
                    r_VehicleModel,
                    r_LicenseNumber,
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

        public Vehicle CreateElectricCar(float i_CurrentBatteryTime,
                                         string i_ColorOfCar,
                                         byte i_NumberOfDoors)
        {
            try
            {
                Vehicle newElectricCar = new ElectricCar(
                    r_VehicleModel,
                    r_LicenseNumber,
                    i_CurrentBatteryTime,
                    i_ColorOfCar,
                    i_NumberOfDoors);
                return newElectricCar;
            }
            catch (Exception ex)
            {
                throw new Exception(r_ErrorMessage, ex);
            }
        }

        public Vehicle CreateFuelMotorcycle(float i_CurrentTankFuel,
                                            string i_LicenseType,
                                            uint i_EngineCapacity)
        {
            try
            {
                Vehicle newFuelMotorcycle = new FuelMotorcycle(
                    r_VehicleModel,
                    r_LicenseNumber,
                    i_CurrentTankFuel,
                    i_LicenseType,
                    i_EngineCapacity);
                return newFuelMotorcycle;
            }
            catch(Exception ex)
            {
                throw new Exception(r_ErrorMessage, ex);
            }
        }

        public Vehicle CreateElectricMotorcycle(float i_CurrentBatteryTime,
                                                string i_LicenseType,
                                                uint i_EngineCapacity)
        {
            try
            {
                Vehicle newElectricMotorcycle = new ElectricMotorcycle(
                    r_VehicleModel,
                    r_LicenseNumber,
                    i_CurrentBatteryTime,
                    i_LicenseType,
                    i_EngineCapacity);
                return newElectricMotorcycle;
            }
            catch (Exception ex)
            {
                throw new Exception(r_ErrorMessage, ex);
            }
        }

        public Vehicle CreateTruck(float i_CurrentTankFuel,
                                   float i_CargoVolume,
                                   bool i_IsHaveHazardousMaterials)
        {
            try
            {
                Vehicle newTruck = new Truck(
                    r_VehicleModel,
                    r_LicenseNumber,
                    i_CurrentTankFuel,
                    i_CargoVolume,
                    i_IsHaveHazardousMaterials);
                return newTruck;
            }
            catch(Exception ex)
            {
                throw new Exception(r_ErrorMessage, ex);
            }
        }
    }
}
