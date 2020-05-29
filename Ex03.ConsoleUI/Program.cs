using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            UserInterface garageController = new UserInterface();
            garageController.ControlGarage();
        }
    }
}
