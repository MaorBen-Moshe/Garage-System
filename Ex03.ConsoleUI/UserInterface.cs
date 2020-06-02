using System;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

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
                if(isValid)
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
                switch(i_Option)
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

                PrintingUtils.PrintListOfEnum("Please choose a vehicle", typeof(CreatingVehicles.eTypeOfVehicles));
                string option = Console.ReadLine();
                isValid = Enum.TryParse(option, true, out CreatingVehicles.eTypeOfVehicles result)
                          && Enum.IsDefined(typeof(CreatingVehicles.eTypeOfVehicles), result);
                if(isValid)
                {
                    Vehicle vehicle = createVehicle(result);
                    AutoRepairShop.VehicleInShop toAdd = new AutoRepairShop.VehicleInShop(
                        ownerName,
                        ownerPhone,
                        vehicle);
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
            CreatingVehicles vehiclesMaker = new CreatingVehicles(i_TypeOfVehicle);
            Vehicle vehicleToAdd = vehiclesMaker.CreateVehicle();
            StringBuilder askForData = vehicleToAdd.AskForData;
            string[] splitAskForData = askForData.ToString().Split('\n');
            string[] storeData = new string[splitAskForData.Length];
            for(int i = 0; i < splitAskForData.Length; i++)
            { 
                if(i == 3 && i_TypeOfVehicle.Equals(CreatingVehicles.eTypeOfVehicles.Truck) == false)
                {
                    Type getType = getVehicleTypeOfEnum(i_TypeOfVehicle);
                    PrintingUtils.PrintListOfEnum(splitAskForData[i], getType);
                    storeData[i] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(splitAskForData[i]);
                    storeData[i] = Console.ReadLine();
                }
            }

            vehicleToAdd.SetVehicleData = storeData;
            return vehicleToAdd;
        }

        private Type getVehicleTypeOfEnum(CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle)
        {
            Type type;
            if(i_TypeOfVehicle.Equals(CreatingVehicles.eTypeOfVehicles.ElectricCar)
               || i_TypeOfVehicle.Equals(CreatingVehicles.eTypeOfVehicles.FuelCar))
            {
                type = typeof(CarData.eColor);
            }
            else 
            {
                type = typeof(MotorcycleData.eLicenseType);
            }

            return type;
        }

        private AutoRepairShop.VehicleInShop.eVehicleStatus? getStatus()
        {
            AutoRepairShop.VehicleInShop.eVehicleStatus? returnStatus;
            PrintingUtils.PrintListOfEnum(
                "Please write below the vehicle status:",
                typeof(AutoRepairShop.VehicleInShop.eVehicleStatus));
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
            PrintingUtils.PrintListOfEnum("Please write below the fuel type:", typeof(FuelVehicle.eFuelType));
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
