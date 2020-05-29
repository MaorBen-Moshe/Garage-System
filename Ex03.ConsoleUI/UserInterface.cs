using System;
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
                        isValid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Please choose from the following!");
                }
                Console.Clear();
            }
            while(isValid == false && m_LeaveStore == false);
        }

        private void controlGarageOptions(eOption i_Option)
        {
            try
            {
                switch (i_Option)
                {
                    case eOption.AddVehicle:
                        addVehicle();
                        break;
                    case eOption.ShowVehiclesByLicense:
                        break;
                    case eOption.ShowVehiclesByStatus:
                        break;
                    case eOption.ModifyStatus:
                        break;
                    case eOption.InflateWheels:
                        break;
                    case eOption.RefuelVehicle:
                        break;
                    case eOption.LoadVehicle:
                        break;
                    case eOption.ShowVehicleDetails:
                        break;
                    case eOption.Exit:
                        m_LeaveStore = true;
                        break;
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
    }
}
