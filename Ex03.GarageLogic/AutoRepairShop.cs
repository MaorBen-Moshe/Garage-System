using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class AutoRepairShop
    {
        public class VehicleInShop
        {
            public enum eVehicleStatus
            {
                InRepair,
                Repaired,
                Paid
            }

            private string m_OwnerName;
            private string m_OwnerNumber;
            private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
            private Vehicle m_VehicleInShop;

            public VehicleInShop(string i_OwnerName, string i_OwnerNumber, Vehicle i_VehicleInShop)
            {
                m_OwnerName = i_OwnerName;
                m_OwnerNumber = i_OwnerNumber;
                m_VehicleInShop = i_VehicleInShop;
            }

            public string Name
            {
                get
                {
                    return m_OwnerName;
                }
            }

            public string Number
            {
                get
                {
                    return m_OwnerNumber;
                }
            }

            public string VehicleLicensNumber
            {
                get
                {
                    return m_VehicleInShop.VehicleLicenseNumber;
                }
            }

            public eVehicleStatus VehicleStatus
            {
                get
                {
                    return m_VehicleStatus;
                }

                set
                {
                    m_VehicleStatus = value;
                }
            }
        }

        Dictionary<string, VehicleInShop> m_VehicleList;

        public AutoRepairShop()
        {
            m_VehicleList = new Dictionary<string, VehicleInShop>();
        }

        public void AddVehicleToStore()
        {
            Console.WriteLine("Please enter your vehicle model: ");
            string vehicleModel = Console.ReadLine();
            Console.WriteLine("Please enter your vehicle license number: ");
            string licenseNumber = Console.ReadLine();
            if(licenseNumber != null)
            {
                if(m_VehicleList.ContainsKey(licenseNumber))
                {
                    m_VehicleList[licenseNumber].VehicleStatus = VehicleInShop.eVehicleStatus.InRepair;
                }
                else
                {
                    handleCreatingVehicle(vehicleModel, licenseNumber);
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Vehicle license number"));
            }
        }

        private void handleCreatingVehicle(string i_VehicleModel, string i_VehicleLicenseNumber)
        {
            try
            {
                Console.WriteLine("Please enter the type of the vehicle: ");
                string vehicleType = Console.ReadLine();
                CreatingVehicles vehicleMaker = new CreatingVehicles(vehicleType, i_VehicleModel, i_VehicleLicenseNumber);
                switch(vehicleMaker.VehicleType)
                {
                    case CreatingVehicles.eTypeOfVehicles.FuelCar:
                        //vehicleMaker.CreateFuelCar();
                        break;
                    case CreatingVehicles.eTypeOfVehicles.ElectricCar:
                        //vehicleMaker.CreateElectricCar();
                        break;
                    case CreatingVehicles.eTypeOfVehicles.ElectricMotorcycle:
                        //vehicleMaker.CreateElectricMotorcycle();
                        break;
                    case CreatingVehicles.eTypeOfVehicles.FuelMotorcycle:
                        //vehicleMaker.CreateFuelMotorcycle();
                        break;
                    case CreatingVehicles.eTypeOfVehicles.Truck:
                        //vehicleMaker.CreateTruck();
                        break;
                    default:
                        throw new ArgumentException("Invalid vehicle type");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Fail adding the vehicle"), ex);
            }
        }

        public void ShowAllVehiclesInGarage(VehicleInShop.eVehicleStatus? i_Status = null)
        {
            foreach (KeyValuePair<string, VehicleInShop> current in m_VehicleList)
            {
                if(i_Status != null && current.Value.VehicleStatus == i_Status)
                {
                }
                else
                {
                }
            }
        }

        public void SetNewStatusToVehicle(string i_LicenseNumber, VehicleInShop.eVehicleStatus i_NewStatus)
        {
            bool isExist = m_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toChange);
            if(isExist)
            {
                toChange.VehicleStatus = i_NewStatus;
            }
            else
            {
                throw new FormatException(string.Format("Vehicle is not available"));
            }
        }

        public void SetWheelsPressureToMaximum(string i_LicenseNumber)
        {
            bool isExist = m_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toChange);
            if(isExist)
            {
            }
            else
            {
                throw new FormatException(string.Format("Vehicle is not available"));
            }
        }

        public void RefuelingVehicle(string i_LicenseNumber, FuelVehicle.eFuelType i_FuelType, float i_AmountToAdd)
        {
        }

        public void LoadingVehicle(string i_LicenseNumber, float i_MinutesToLoad)
        {
        }

        public void ShowDetailsOfVehicle(string i_LicenseNumber)
        {
        }
    }
}
