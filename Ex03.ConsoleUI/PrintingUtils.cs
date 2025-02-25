﻿using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class PrintingUtils
    {
        public static void PrintingOpening()
        {
            string opening = @"
*************************************************************************
*************************************************************************
$$$$$$$$$$       $$       $$$$$$$        $$       $$$$$$$$$$  $$$$$$$$$$ 
$$             $$  $$     $$   $$       $$ $$     $$          $$
$$            $$    $$    $$$$$$$      $$   $$    $$          $$
$$  $$$$$$   $$$$$$$$$$   $$ $$$      $$$$$$$$$   $$  $$$$$$  $$$$$$$$$$
$$  $$  $$  $$        $$  $$   $$$   $$       $$  $$  $$  $$  $$
$$$$$$$$$$ $$          $$ $$    $$$ $$         $$ $$$$$$$$$$  $$$$$$$$$$  
*************************************************************************
*************************************************************************";

            Console.Clear();
            Console.WriteLine(opening);
            printOptions();
        }

        public static void PrintListOfEnum(string i_Message, Type i_TypeOfEnum)
        {
            string[] types = Enum.GetNames(i_TypeOfEnum);
            Console.WriteLine(i_Message);
            for (int i = 0; i < types.Length; ++i)
            {
                Console.WriteLine("{0}. {1}", i + 1, types[i]);
            }
        }

        public static void PrintExceptionErrors(Exception i_Ex)
        {
            Exception inner = i_Ex.InnerException;
            while (inner != null)
            {
                Console.WriteLine(inner.Message);
                inner = inner.InnerException;
            }

            Console.WriteLine(i_Ex.Message);
        }

        public static void StatusModified(
            string i_LicenseNumber,
            AutoRepairShop.VehicleInShop.eVehicleStatus? i_NewStatus,
            bool i_IsModifeid)
        {
            if(i_IsModifeid)
            {
                Console.WriteLine(
                    string.Format(
                    format:
                    @"Status to vehicle {0} has been modified to: {1}",
                    i_LicenseNumber,
                    i_NewStatus));
            }
            else
            {
                Console.WriteLine("Fail modify vehicle {0}", i_LicenseNumber);
            }
        }

        public static void InflateWheels(string i_LicenseNumber, bool i_IsInflated)
        {
            if(i_IsInflated)
            {
                Console.WriteLine(string.Format(format:@"All the wheels of vehicle {0} inflated to maximum", i_LicenseNumber));
            }
            else
            {
                Console.WriteLine("Fail inflating vehicle {0}", i_LicenseNumber);
            }
        }

        public static void VehicleAdded(string i_LicenseNumber, bool i_IsAdded)
        {
            if(i_IsAdded)
            {
                Console.WriteLine(string.Format(format:@"Vehicle {0} added successfully to the garage", i_LicenseNumber));
            }
            else
            {
                Console.WriteLine("Fail adding vehicle {0}", i_LicenseNumber);
            }
        }

        public static void EnergyAdded(string i_LicenseNumber, bool i_IsEnergyAdded, FuelVehicle.eFuelType? i_FuelType = null)
        {
            if(i_IsEnergyAdded)
            {
                string fuelType = string.Empty;
                if(i_FuelType != null)
                {
                    fuelType = string.Format(format: @"fuel added: {0}", i_FuelType);
                }

                Console.WriteLine(string.Format(format: @"Energy added to vehicle {0} {1}", i_LicenseNumber, fuelType));
            }
            else
            {
                Console.WriteLine("Fail fill in energy to vehicle {0}", i_LicenseNumber);
            }
        }

        public static void PrintLicensesList(
                                             List<string> i_LicensesList, 
                                             AutoRepairShop.VehicleInShop.eVehicleStatus? i_Status = null)
        {
            if(i_LicensesList.Count == 0 && i_Status != null)
            {
                Console.WriteLine("There are no vehicles in the garage with the status: {0}", i_Status);
            }
            else if(i_LicensesList.Count == 0)
            { 
                Console.WriteLine("There are no vehicles in the garage");
            }
            else
            {
                string header = i_Status != null
                                    ? string.Format(format: @"The list of licenses by {0} status:", i_Status.ToString())
                                    : "The list of licenses:";
                Console.WriteLine(header);
                foreach (string currentLicense in i_LicensesList)
                {
                    Console.WriteLine(currentLicense);
                }
            }
        }

        public static void PrintVehicleDetails(string i_VehicleDetails, bool i_IsExist)
        {
            Console.WriteLine(
                string.Format(
                    format: @"
The vehicle details:
{0}",
                    i_IsExist ? i_VehicleDetails : "Vehicle was not found"));
        }

        public static void Delay()
        {
            Console.WriteLine(
                @"
press any key to continue...");
            Console.ReadLine();
        }

        private static void printOptions()
        {
            string options = @"
Please choose from the following options(1 - 9):
1.Add a new vehicle to the auto repair shop
2.Display vehicles by license plate numbers in the auto repair shop
3.Display vehicles by license plate numbers and by repairing status in the auto repair shop
4.Modify a vehicle's status
5.Inflate a vehicle's wheels to maximum
6.Refuel a fuel vehicles
7.Load an electric vehicles
8.Display full details of a vehicle
9.Quit.";

            Console.WriteLine(options);
        }
    }
}
