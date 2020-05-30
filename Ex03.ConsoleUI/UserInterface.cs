using System;
using System.Diagnostics.CodeAnalysis;
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
            do
            {
                PrintingUtils.PrintingOpening();
                string option = Console.ReadLine();
                bool isValid = Enum.TryParse(option, out eOption result) && Enum.IsDefined(typeof(eOption), result);
                if (isValid)
                {
                    try
                    {
                        controlGarageOptions(result);
                    }
                    catch
                    {
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Please choose from the options above!");
                }
                Console.Clear();
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
                        PrintingUtils.PrintLicensesList(r_AutoRepairShop.ShowAllVehiclesInGarage());
                        break;
                    case eOption.ShowVehiclesByStatus:
                        status = getStatus();
                        PrintingUtils.PrintLicensesList(r_AutoRepairShop.ShowAllVehiclesInGarage(status), status);
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
                        r_AutoRepairShop.FillInEnergyToVehicle(licenseNumber, fuelToAdd, fuelType);
                        break;
                    case eOption.LoadVehicle:
                        licenseNumber = getLicenseNumber();
                        float minutesToAdd = getMinutesToLoad();
                        r_AutoRepairShop.FillInEnergyToVehicle(licenseNumber, minutesToAdd);
                        break;
                    case eOption.ShowVehicleDetails:
                        licenseNumber = getLicenseNumber();
                        Console.WriteLine(string.Format(format:@"
The vehicle details:
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
                PrintingUtils.PrintExceptionErrors(ex);
                throw;
            }
        }
        
        private void addVehicle()
        {
            Console.WriteLine("Creating Vehicle: ");
            Console.WriteLine("Please write your name: ");
            string ownerName = Console.ReadLine();
            bool isValid = false;
            do
            {
                Console.WriteLine("Please write your phone number: ");
                string ownerPhone = Console.ReadLine();
                bool isValidPhoneNumber = int.TryParse(ownerPhone, out int intPhoneNumber);
                if(isValidPhoneNumber == false)
                {
                    Console.WriteLine("Fail to add the phone number you entered.");
                    continue;
                }
                PrintingUtils.TypeOfVehicle();
                string option = Console.ReadLine();
                isValid = Enum.TryParse(option, true, out CreatingVehicles.eTypeOfVehicles result)
                          && Enum.IsDefined(typeof(CreatingVehicles.eTypeOfVehicles), result);
                if (isValid)
                {
                    Vehicle vehicle = createVehicle(result);
                    AutoRepairShop.VehicleInShop toAdd = new AutoRepairShop.VehicleInShop(ownerName, ownerPhone, vehicle);
                    r_AutoRepairShop.AddVehicleToStore(toAdd);
                    break;
                }
                
                Console.WriteLine("please choose a valid option.");
            }
            while(isValid == false);
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
            bool isParseEnergy = float.TryParse(energy, out float currentEnergy);
            if(!isParseEnergy)
            {
                throw new FormatException("Fail parsing the current energy in vehicle");
            }
            switch(i_TypeOfVehicle)
            {
                case CreatingVehicles.eTypeOfVehicles.ElectricCar:
                case CreatingVehicles.eTypeOfVehicles.FuelCar:
                    PrintingUtils.ColorType();
                    string color = Console.ReadLine();
                    checkNumOfDoors(out byte numOfDoors);
                    vehicleData = new CarData(vehicleModel, vehicleLicenseNumber, currentEnergy, color, numOfDoors);
                    break;
                case CreatingVehicles.eTypeOfVehicles.ElectricMotorcycle:
                case CreatingVehicles.eTypeOfVehicles.FuelMotorcycle:
                    PrintingUtils.LicenseType();
                    string licenseType = Console.ReadLine();
                    checkEngineCapacity(out uint engineCapacity);
                    vehicleData = new MotorcycleData(vehicleModel, vehicleLicenseNumber, currentEnergy, licenseType, engineCapacity);
                    break;
                case CreatingVehicles.eTypeOfVehicles.Truck:
                    checkCargoVolume(out float cargoVolume);
                    Console.WriteLine("Does the truck deliver hazardous materials? (y/n)");
                    string isDeliver = Console.ReadLine();
                    bool isHazardous = isDeliver != null && (isDeliver.Equals("y") || isDeliver.Equals("Y"));
                    vehicleData = new TruckData(vehicleModel, vehicleLicenseNumber, currentEnergy, cargoVolume, isHazardous);
                    break;
            }
            CreatingVehicles vehicleMaker = new CreatingVehicles(i_TypeOfVehicle);
            Vehicle vehicle = vehicleMaker.CreateVehicle(vehicleData);
            return vehicle;
        }

        private void checkNumOfDoors(out byte o_NumOfDoors)
        {
            Console.WriteLine("How many doors the car has?");
            bool isParseDoors = byte.TryParse(Console.ReadLine(), out o_NumOfDoors);
            if(!isParseDoors)
            {
                throw new FormatException("Fail parsing numOfDoors");
            }
        }

        private void checkEngineCapacity(out uint o_EngineCapacity)
        {
            Console.WriteLine("Please enter the engine capacity: ");
            bool isValid = uint.TryParse(Console.ReadLine(), out o_EngineCapacity);
            if(isValid == false)
            {
                throw new FormatException("Fail parsing engine capacity");
            }
        }

        private void checkCargoVolume(out float o_CargoVolume)
        {
            Console.WriteLine("What is the cargo volume?");
            bool isValid = float.TryParse(Console.ReadLine(), out o_CargoVolume);
            if(isValid)
            {
                if(o_CargoVolume < 0)
                {
                    throw new ArgumentException("Cargo volume cannot be negative");
                }
            }
            else
            {
                throw new FormatException("Fail parsing cargo volume");
            }
        }

        private AutoRepairShop.VehicleInShop.eVehicleStatus? getStatus()
        {
            AutoRepairShop.VehicleInShop.eVehicleStatus? returnStatus = null;
            PrintingUtils.VehicleStatus();
            string status = Console.ReadLine();
            bool isValid = Enum.TryParse(status, out AutoRepairShop.VehicleInShop.eVehicleStatus result)
                && Enum.IsDefined(typeof(AutoRepairShop.VehicleInShop.eVehicleStatus), result);
            if(isValid)
            {
                returnStatus = result;
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
            bool isValid = Enum.TryParse(Console.ReadLine(), out o_FuelType) 
                && Enum.IsDefined(typeof(FuelVehicle.eFuelType), o_FuelType);
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
