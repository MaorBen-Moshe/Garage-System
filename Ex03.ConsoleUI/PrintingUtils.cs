using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class PrintingUtils
    {
        public static void PrintingOpening()
        {
            string opening = string.Format(format:
                @"
*************************************************************************
*************************************************************************
$$$$$$$$$$       $$       $$$$$$$        $$       $$$$$$$$$$  $$$$$$$$$$ 
$$             $$  $$     $$   $$       $$ $$     $$          $$
$$            $$    $$    $$$$$$$      $$   $$    $$          $$
$$  $$$$$$   $$$$$$$$$$   $$ $$$      $$$$$$$$$   $$  $$$$$$  $$$$$$$$$$
$$  $$  $$  $$        $$  $$   $$$   $$       $$  $$  $$  $$  $$
$$$$$$$$$$ $$          $$ $$    $$$ $$         $$ $$$$$$$$$$  $$$$$$$$$$  
*************************************************************************
*************************************************************************");

            Console.WriteLine(opening);
            printOptions();
        }

        public static void TypeOfVehicle()
        {
            string type = string.Format(format: @"Please choose the type of vehicle:
1.FuelCar
2.ElectricCar
3.FuelMotorcycle
4.ElectricMotorcycle
5.Truck");

            Console.WriteLine(type);
        }

        public static void ColorType()
        {
            string color = string.Format(format: @"Please write below the color:
1.Red
2.Silver
3.White
4.Black");

            Console.WriteLine(color);
        }

        public static void LicenseType()
        {
            string type = string.Format(format: @"Please write below the license type:
1.A
2.A1
3.AA
4.B");

            Console.WriteLine(type);
        }

        public static void VehicleStatus()
        {
            string status = string.Format(format: @"Please write below the vehicle status:
1.InRepair
2.Repaired
3.Paid");

            Console.WriteLine(status);
        }

        public static void FuelToAdd()
        {
            string fuel = string.Format(format: @"Please write below the fuel type:
1.Octan95
2.Octan96
3.Octan98
4.Soler");

            Console.WriteLine(fuel);
        }

        public static void PrintExceptionErrors(Exception i_Ex)
        {
            while (i_Ex.InnerException != null)
            {
                Console.WriteLine(i_Ex.InnerException.Message);
            }

            Console.WriteLine(i_Ex.Message);
        }

        public static void PrintLicensesList(List<string> i_LicensesList, 
                                             AutoRepairShop.VehicleInShop.eVehicleStatus? i_Status = null)
        {
            string header = i_Status != null
                                ? string.Format("The list of licenses by {0} status:", i_Status.ToString())
                                : "The list of licenses:"; 
            Console.WriteLine(header);
            foreach(string currentLicense in i_LicensesList)
            {
                Console.WriteLine(currentLicense);
            }
        }

        private static void printOptions()
        {
            string options = string.Format(format:
                @"
Please choose from the following options(1 - 9):
1.Add a new vehicle to the auto repair shop
2.Display vehicles by license plate numbers in the auto repair shop
3.Display vehicles by license plate numbers and by repairing status in the auto repair shop
4.Modify a vehicle's status
5.Inflate a vehicle's wheels to maximum
6.Refuel a fuel vehicles
7.Load an electric vehicles
8.Display full details of a vehicle
9.Quit.");

            Console.WriteLine(options);
        }
    }
}
