using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class Class1
    {

        ////private Vehicle createVehicle(CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle)
        ////{
        ////    VehicleData vehicleData = null;
        ////    getGeneralInformation(out string vehicleModel, out string vehicleLicenseNumber, out float currentEnergy);

        ////    float maxEnergy;
        ////    switch (i_TypeOfVehicle)
        ////    {
        ////        case CreatingVehicles.eTypeOfVehicles.ElectricCar:
        ////        case CreatingVehicles.eTypeOfVehicles.FuelCar:
        ////            getCarData(i_TypeOfVehicle, out string color, out byte numOfDoors, out maxEnergy);
        ////            vehicleData = new CarData(vehicleModel, vehicleLicenseNumber, currentEnergy, color, numOfDoors, maxEnergy);
        ////            break;
        ////        case CreatingVehicles.eTypeOfVehicles.ElectricMotorcycle:
        ////        case CreatingVehicles.eTypeOfVehicles.FuelMotorcycle:
        ////            getMotorcycleData(i_TypeOfVehicle, out string licenseType, out uint engineCapacity, out maxEnergy);
        ////            vehicleData = new MotorcycleData(vehicleModel, vehicleLicenseNumber, currentEnergy, licenseType, engineCapacity, maxEnergy);
        ////            break;
        ////        case CreatingVehicles.eTypeOfVehicles.Truck:
        ////            getTruckData(i_TypeOfVehicle, out float cargoVolume, out bool isHazardous);
        ////            vehicleData = new TruckData(vehicleModel, vehicleLicenseNumber, currentEnergy, cargoVolume, isHazardous);
        ////            break;
        ////    }

        ////    CreatingVehicles vehicleMaker = new CreatingVehicles(i_TypeOfVehicle);
        ////    Vehicle vehicle = vehicleMaker.CreateVehicle(vehicleData);
        ////    return vehicle;
        ////}

        //private void getMotorcycleData(
        //    CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle,
        //    out string o_LicenseType,
        //    out uint o_EngineCapacity,
        //    out float o_MaxEnergy)
        //{
        //    PrintingUtils.PrintListOfEnum("Please write below the license type:", typeof(MotorcycleData.eLicenseType));
        //    o_LicenseType = Console.ReadLine();
        //    checkEngineCapacity(out o_EngineCapacity);
        //    o_MaxEnergy = i_TypeOfVehicle == CreatingVehicles.eTypeOfVehicles.ElectricMotorcycle
        //                      ? ElectricVehicle.k_MotorcycleMaxBatteryTime
        //                      : FuelVehicle.k_MotorcycleMaxTankFuel;
        //}

        //private void getTruckData(
        //    CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle,
        //    out float o_CargoVolume,
        //    out bool o_IsHazardous)
        //{
        //    checkCargoVolume(out o_CargoVolume);
        //    Console.WriteLine("Does the truck deliver hazardous materials? (y/n)");
        //    string isDeliver = Console.ReadLine();
        //    o_IsHazardous = isDeliver != null && (isDeliver.Equals("y") || isDeliver.Equals("Y"));
        //}

        //private void getCarData(
        //    CreatingVehicles.eTypeOfVehicles i_TypeOfVehicle,
        //    out string o_Color,
        //    out byte o_NumOfDoors,
        //    out float o_MaxEnergy)
        //{
        //    PrintingUtils.PrintListOfEnum("Please write below the color:", typeof(CarData.eColor));
        //    o_Color = Console.ReadLine();
        //    checkNumOfDoors(out o_NumOfDoors);
        //    o_MaxEnergy = i_TypeOfVehicle == CreatingVehicles.eTypeOfVehicles.ElectricCar
        //                      ? ElectricVehicle.k_CarMaxBatteryTime
        //                      : FuelVehicle.k_CarMaxTankFuel;
        //}

        //private void getGeneralInformation(
        //    out string o_VehicleModel,
        //    out string o_VehicleLicenseNumber,
        //    out float o_CurrentEnergy)
        //{
        //    Console.WriteLine("Please enter your vehicle model: ");
        //    o_VehicleModel = Console.ReadLine();
        //    Console.WriteLine("Please enter your vehicle's license number: ");
        //    o_VehicleLicenseNumber = Console.ReadLine();
        //    if(r_AutoRepairShop.ContainsLicenseNumber(o_VehicleLicenseNumber))
        //    {
        //        throw new ArgumentException(
        //            string.Format(format: @"Vehicle {0} is already in the garage", o_VehicleLicenseNumber));
        //    }

        //    Console.WriteLine("Please enter your current energy in vehicle: ");
        //    string energy = Console.ReadLine();
        //    bool isParseEnergy = float.TryParse(energy, out o_CurrentEnergy);
        //    if(!isParseEnergy)
        //    {
        //        throw new FormatException("Fail parsing the current energy in vehicle");
        //    }
        //}

        //private void checkNumOfDoors(out byte o_NumOfDoors)
        //{
        //    Console.WriteLine("How many doors the car has?");
        //    bool isParseDoors = byte.TryParse(Console.ReadLine(), out o_NumOfDoors);
        //    if(!isParseDoors)
        //    {
        //        throw new FormatException("Fail parsing numOfDoors");
        //    }
        //}

        //private void checkEngineCapacity(out uint o_EngineCapacity)
        //{
        //    Console.WriteLine("Please enter the engine capacity: ");
        //    bool isValid = uint.TryParse(Console.ReadLine(), out o_EngineCapacity);
        //    if(isValid == false)
        //    {
        //        throw new FormatException("Fail parsing engine capacity");
        //    }
        //}

        //private void checkCargoVolume(out float o_CargoVolume)
        //{
        //    Console.WriteLine("What is the cargo volume?");
        //    bool isValid = float.TryParse(Console.ReadLine(), out o_CargoVolume);
        //    if(isValid)
        //    {
        //        if(o_CargoVolume < 0)
        //        {
        //            throw new ArgumentException("Cargo volume cannot be negative");
        //        }
        //    }
        //    else
        //    {
        //        throw new FormatException("Fail parsing cargo volume");
        //    }
        //}
    }
}
