using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public static void PrintOptions()
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
7.Charge an electric vehicles
8.Display full details of a vehicle
9.Quit.");

            Console.WriteLine(options);
        }
    }
}
