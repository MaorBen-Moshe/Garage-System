﻿using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.VehiclesData;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private readonly AutoRepairShop r_AutoRepairShop;
        private bool m_LeaveStore;

        public UserInterface()
        {
            r_AutoRepairShop = new AutoRepairShop();
        }

        private enum eOption
        {
            AddVehicle = 1,
            ShowVehiclesByLicense,
            ShowVehiclesByStatus,
            ModifyStatus,
            InflateWheels,
            RefuelVehicle,
            LoadVehicle,
            ShowVehicleDetails,
            Exit
        }

        public void ControlGarage()
        {
            bool isValid;
            do
            {
                PrintingUtils.PrintingOpening();
                string option = Console.ReadLine();
                isValid = Enum.TryParse(option, out eOption result);
                if(isValid)
                {
                    try
                    {
                        controlGarageOptions(result);
                    }
                    catch
                    {
                        System.Threading.Thread.Sleep(2000);
                        isValid = false;
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Please choose from the following!");
                }
                //Console.Clear();
            }
            while(m_LeaveStore == false);
            Console.WriteLine("Goodbye!");
        }

        private void controlGarageOptions(eOption i_Option)
        {
            try
            {
                AutoRepairShop.VehicleInShop.eVehicleStatus? status;
                string licenseNumber;
                switch (i_Option)
                {
                    case eOption.AddVehicle:
                        addVehicle();
                        break;
                    case eOption.ShowVehiclesByLicense:
                        r_AutoRepairShop.ShowAllVehiclesInGarage();
                        break;
                    case eOption.ShowVehiclesByStatus:
                        status = getStatus();
                        r_AutoRepairShop.ShowAllVehiclesInGarage(status);
                        break;
                    case eOption.ModifyStatus:
                        licenseNumber = getLicenseNumber();
                        status = getStatus();
                        r_AutoRepairShop.SetNewStatusToVehicle(licenseNumber, status);
                        break;
                    case eOption.InflateWheels:
                        licenseNumber = getLicenseNumber();
                        r_AutoRepairShop.SetWheelsPressureToMaximum(licenseNumber);
                        break;
                    case eOption.RefuelVehicle:
                        licenseNumber = getLicenseNumber();
                        getFuelToAdd(out FuelVehicle.eFuelType fuelType, out float fuelToAdd);
                        r_AutoRepairShop.RefuelingVehicle(licenseNumber, fuelType, fuelToAdd);
                        break;
                    case eOption.LoadVehicle:
                        licenseNumber = getLicenseNumber();
                        float minutesToAdd = getMinutesToLoad();
                        r_AutoRepairShop.LoadingVehicle(licenseNumber, minutesToAdd);
                        break;
                    case eOption.ShowVehicleDetails:
                        licenseNumber = getLicenseNumber();
                        Console.WriteLine(string.Format(format:@"The vehicle details:
{0}", 
                            r_AutoRepairShop.ShowDetailsOfVehicle(licenseNumber)));
                        break;
                    case eOption.Exit:
                        m_LeaveStore = true;
                        break;
                    default:
                        throw new ValueOutOfRangeException(1, 9);
                }
            }
            catch(Exception ex)
            {
                while(ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }

                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void addVehicle()
        {
            Console.WriteLine("Creating Vehicle: ");
            Console.WriteLine("Please write your name: ");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Please write your phone number: ");
            string ownerPhone = Console.ReadLine();
            Vehicle vehicle = null;
            bool isValid;
            do
            {
                PrintingUtils.TypeOfVehicle();
                string option = Console.ReadLine();
                isValid = Enum.TryParse(option, out CreatingVehicles.eTypeOfVehicles result);
                if (isValid)
                {
                    vehicle = createVehicle(result);
                    break;
                }
                
                Console.WriteLine("please choose a valid option.");
            }
            while(isValid == false);

            AutoRepairShop.VehicleInShop toAdd = new AutoRepairShop.VehicleInShop(ownerName, ownerPhone, vehicle);
            r_AutoRepairShop.AddVehicleToStore(toAdd);
        }

        private Vehicle createVehicle(CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle)
        {
            VehicleData vehicleData = null;
            Console.WriteLine("Please enter your vehicle model: ");
            string vehicleModel = Console.ReadLine();
            Console.WriteLine("Please enter your vehicle's license number: ");
            string vehicleLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter your current energy in vehicle: ");
            string energy = Console.ReadLine();
            float currentEnergy = float.Parse(energy);
            switch(i_TypeOfVehicle)
            {
                case CreatingVehicles.eTypeOfVehicles.ElectricCar:
                case CreatingVehicles.eTypeOfVehicles.FuelCar:
                    PrintingUtils.ColorType();
                    string color = Console.ReadLine();
                    Console.WriteLine("How many doors the car has?");
                    byte numOfDoors = byte.Parse(Console.ReadLine());
                     vehicleData = new CarData(vehicleModel,vehicleLicenseNumber,currentEnergy, color, numOfDoors);
                    break;
                case CreatingVehicles.eTypeOfVehicles.ElectricMotorcycle:
                case CreatingVehicles.eTypeOfVehicles.FuelMotorcycle:
                    PrintingUtils.LicenseType();
                    string licenseType = Console.ReadLine();
                    Console.WriteLine("Please enter the engine capacity: ");
                    uint engineCapacity = uint.Parse(Console.ReadLine());
                    vehicleData = new MotorcycleData(vehicleModel, vehicleLicenseNumber, currentEnergy, licenseType, engineCapacity);
                    break;
                case CreatingVehicles.eTypeOfVehicles.Truck:
                    Console.WriteLine("What is the cargo volume?");
                    float cargoVolume = float.Parse(Console.ReadLine());
                    Console.WriteLine("Does the truck deliver hazardous materials? (y/n)");
                    string isDeliver = Console.ReadLine();
                    bool isHazardous = isDeliver.Equals("y") ? true : false;
                    vehicleData = new TruckData(vehicleModel, vehicleLicenseNumber, currentEnergy, cargoVolume, isHazardous);
                    break;
            }
            CreatingVehicles vehicleMaker = new CreatingVehicles(i_TypeOfVehicle);
            Vehicle vehicle = vehicleMaker.CreateVehicle(vehicleData);

            return vehicle;
        }

        private AutoRepairShop.VehicleInShop.eVehicleStatus? getStatus()
        {
            AutoRepairShop.VehicleInShop.eVehicleStatus? returnStatus;
            PrintingUtils.VehicleStatus();
            string status = Console.ReadLine();
            bool isValid = Enum.TryParse(status, out AutoRepairShop.VehicleInShop.eVehicleStatus result);
            if(isValid)
            {
                if(result.CompareTo(AutoRepairShop.VehicleInShop.eVehicleStatus.Repaired) > 0)
                {
                    returnStatus = null;
                }
                else
                {
                    returnStatus = result;
                }
            }
            else
            {
                ValueOutOfRangeException ex = new ValueOutOfRangeException(1, 3);
                throw new FormatException("Fail parsing the vehicle status", ex);
            }

            return returnStatus;
        }

        private string getLicenseNumber()
        {
            Console.WriteLine("Please enter the vehicle's license number:");
            return Console.ReadLine();
        }

        private float getMinutesToLoad()
        {
            Console.WriteLine("Please enter the amount of time(in minutes) you would like to load the battery:");
            bool isValid = float.TryParse(Console.ReadLine(), out float minutesToAdd);
            if(isValid == false)
            {
                throw new FormatException("Fail parsing the minutes to load");
            }

            return minutesToAdd;
        }

        private void getFuelToAdd(out FuelVehicle.eFuelType o_FuelType, out float o_FuelToAdd)
        {
            PrintingUtils.FuelToAdd();
            bool isValid = Enum.TryParse(Console.ReadLine(), out o_FuelType);
            if(isValid == false)
            {
                throw new FormatException("Fail parsing fuel type");
            }

            Console.WriteLine("Please insert the amount of fuel you would like to add: ");
            bool isParse = float.TryParse(Console.ReadLine(), out o_FuelToAdd);
            if(isParse == false)
            {
                throw new FormatException("Fail parsing the amount of fuel to add");
            }
        }
    }
}
