using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class AutoRepairShop
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
        }

        public void ShowAllVehiclesInGarage(VehicleInShop.eVehicleStatus? i_Status = null)
        {
        }

        public void SetNewStatusToVehicle(VehicleInShop.eVehicleStatus i_NewStatus)
        {
        }

        public void SetWheelsPressureToMaximum(string i_LicenseNumber)
        {
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
