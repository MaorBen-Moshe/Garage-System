using System;
using System.Threading;
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
                        Thread.Sleep(4000);
                    }
                }
                else
                {
                    Console.WriteLine("Please choose from the options above!");
                    Thread.Sleep(2000);
                }
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
                Console.Clear();
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
                        r_AutoRepairShop.SetNewStatusToVehicle(licenseNumber, status, out bool isSucceeded);
                        PrintingUtils.StatusModified(licenseNumber, status, isSucceeded);
                        break;
                    case eOption.InflateWheels:
                        licenseNumber = getLicenseNumber();
                        r_AutoRepairShop.SetWheelsPressureToMaximum(licenseNumber, out bool isInflated);
                        PrintingUtils.InflateWheels(licenseNumber, isInflated);
                        break;
                    case eOption.RefuelVehicle:
                        licenseNumber = getLicenseNumber();
                        getFuelToAdd(out FuelVehicle.eFuelType fuelType, out float fuelToAdd);
                        r_AutoRepairShop.FillInEnergyToVehicle(licenseNumber, fuelToAdd, out bool isRefueled, fuelType);
                        PrintingUtils.EnergyAdded(licenseNumber, isRefueled, fuelType);
                        break;
                    case eOption.LoadVehicle:
                        licenseNumber = getLicenseNumber();
                        float minutesToAdd = getMinutesToLoad();
                        r_AutoRepairShop.FillInEnergyToVehicle(licenseNumber, minutesToAdd, out bool isLoaded);
                        PrintingUtils.EnergyAdded(licenseNumber, isLoaded);
                        break;
                    case eOption.ShowVehicleDetails:
                        licenseNumber = getLicenseNumber();
                        PrintingUtils.PrintVehicleDetails(
                            r_AutoRepairShop.ShowDetailsOfVehicle(licenseNumber, out bool isExist),
                            isExist);
                        break;
                    case eOption.Exit:
                        m_LeaveStore = true;
                        break;
                    default:
                        throw new ValueOutOfRangeException(1, 9);
                }

                if(i_Option != eOption.Exit)
                {
                    Thread.Sleep(4000);
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
            Console.WriteLine("Please write your phone number: ");
            string ownerPhone = Console.ReadLine();
            bool isValid = false;
            do
            {
                bool isValidPhoneNumber = int.TryParse(ownerPhone, out int intPhoneNumber);
                if(isValidPhoneNumber == false)
                {
                    Console.WriteLine("Fail to add the phone number you entered.");
                    Console.WriteLine("Please write your phone number: ");
                    ownerPhone = Console.ReadLine();
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
                    r_AutoRepairShop.AddVehicleToStore(toAdd, out bool isAdded);
                    PrintingUtils.VehicleAdded(toAdd.VehicleLicensNumber, isAdded);
                    break;
                }
                
                Console.WriteLine("please choose a valid option.");
            }
            while(isValid == false);
        }

        private Vehicle createVehicle(CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle)
        {
            VehicleData vehicleData = null;
            getGeneralInformation(out string vehicleModel, out string vehicleLicenseNumber, out float currentEnergy);

            float maxEnergy;
            switch (i_TypeOfVehicle)
            {
                case CreatingVehicles.eTypeOfVehicles.ElectricCar:
                case CreatingVehicles.eTypeOfVehicles.FuelCar:
                    getCarData(i_TypeOfVehicle, out string color, out byte numOfDoors, out maxEnergy);
                    vehicleData = new CarData(vehicleModel, vehicleLicenseNumber, currentEnergy, color, numOfDoors, maxEnergy);
                    break;
                case CreatingVehicles.eTypeOfVehicles.ElectricMotorcycle:
                case CreatingVehicles.eTypeOfVehicles.FuelMotorcycle:
                    getMotorcycleData(i_TypeOfVehicle, out string licenseType, out uint engineCapacity, out maxEnergy);
                    vehicleData = new MotorcycleData(vehicleModel, vehicleLicenseNumber, currentEnergy, licenseType, engineCapacity, maxEnergy);
                    break;
                case CreatingVehicles.eTypeOfVehicles.Truck:
                    getTruckData(i_TypeOfVehicle, out float cargoVolume, out bool isHazardous);
                    vehicleData = new TruckData(vehicleModel, vehicleLicenseNumber, currentEnergy, cargoVolume, isHazardous);
                    break;
            }

            CreatingVehicles vehicleMaker = new CreatingVehicles(i_TypeOfVehicle);
            Vehicle vehicle = vehicleMaker.CreateVehicle(vehicleData);
            return vehicle;
        }

        private void getMotorcycleData(CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle, out string o_LicenseType, out uint o_EngineCapacity, out float o_MaxEnergy)
        {
            PrintingUtils.LicenseType();
            o_LicenseType = Console.ReadLine();
            checkEngineCapacity(out o_EngineCapacity);
            o_MaxEnergy = i_TypeOfVehicle == CreatingVehicles.eTypeOfVehicles.ElectricMotorcycle
                            ? ElectricVehicle.k_MotorcycleMaxBatteryTime
                            : FuelVehicle.k_MotorcycleMaxTankFuel;
        }
        
        private void getTruckData(CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle, out float o_CargoVolume, out bool o_IsHazardous)
        {
            checkCargoVolume(out o_CargoVolume);
            Console.WriteLine("Does the truck deliver hazardous materials? (y/n)");
            string isDeliver = Console.ReadLine();
            o_IsHazardous = isDeliver != null && (isDeliver.Equals("y") || isDeliver.Equals("Y"));
        }
        
        private void getCarData(CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle, out string o_Color, out byte o_NumOfDoors, out float o_MaxEnergy)
        {
            PrintingUtils.ColorType();
            o_Color = Console.ReadLine();
            checkNumOfDoors(out o_NumOfDoors);
            o_MaxEnergy = i_TypeOfVehicle == CreatingVehicles.eTypeOfVehicles.ElectricCar
                            ? ElectricVehicle.k_CarMaxBatteryTime
                            : FuelVehicle.k_CarMaxTankFuel;
        }
        
        private void getGeneralInformation(out string o_VehicleModel, out string o_VehicleLicenseNumber, out float o_CurrentEnergy)
        {
            Console.WriteLine("Please enter your vehicle model: ");
            o_VehicleModel = Console.ReadLine();
            Console.WriteLine("Please enter your vehicle's license number: ");
            o_VehicleLicenseNumber = Console.ReadLine();
            if(r_AutoRepairShop.ContainsLicenseNumber(o_VehicleLicenseNumber))
            {
                throw new ArgumentException(string.Format(format:@"Vehicle {0} is already in the garage", o_VehicleLicenseNumber));
            }
            Console.WriteLine("Please enter your current energy in vehicle: ");
            string energy = Console.ReadLine();
            bool isParseEnergy = float.TryParse(energy, out o_CurrentEnergy);
            if (!isParseEnergy)
            {
                throw new FormatException("Fail parsing the current energy in vehicle");
            }
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
            AutoRepairShop.VehicleInShop.eVehicleStatus? returnStatus;
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
                string errorMessage = "You have to choose from the following options";
                ValueOutOfRangeException ex = new ValueOutOfRangeException(1, 3, errorMessage);
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
