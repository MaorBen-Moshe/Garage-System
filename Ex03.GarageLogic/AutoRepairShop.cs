using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
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
            private string m_OwnerPhoneNumber;
            private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
            internal Vehicle m_VehicleInShop;

            public VehicleInShop(string i_OwnerOwenerName, string i_OwnerPhoneNumber, Vehicle i_VehicleInShop)
            {
                m_OwnerName = i_OwnerOwenerName;
                m_OwnerPhoneNumber = i_OwnerPhoneNumber;
                m_VehicleInShop = i_VehicleInShop;
            }

            public string OwenerName
            {
                get
                {
                    return m_OwnerName;
                }
            }

            public string PhoneNumber
            {
                get
                {
                    return m_OwnerPhoneNumber;
                }
            }

            public string VehicleLicensNumber
            {
                get
                {
                    return m_VehicleInShop.LicenseNumber;
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

        private readonly Dictionary<string, VehicleInShop> r_VehicleList;
        private readonly string r_IsNotExistError = "Vehicle do not exsit in the garage";

        public AutoRepairShop()
        {
            r_VehicleList = new Dictionary<string, VehicleInShop>();
        }

        public void AddVehicleToStore(VehicleInShop i_VehicleToAdd)
        {
            bool isExist = r_VehicleList.ContainsKey(i_VehicleToAdd.VehicleLicensNumber);
            if(isExist)
            {
                i_VehicleToAdd.VehicleStatus = VehicleInShop.eVehicleStatus.InRepair;
            }
            else
            {
                r_VehicleList.Add(i_VehicleToAdd.VehicleLicensNumber, i_VehicleToAdd);
            }
        }

        public List<string> ShowAllVehiclesInGarage(VehicleInShop.eVehicleStatus? i_Status = null)
        {
            List<string> vehiclesToShow = new List<string>(r_VehicleList.Count);
            foreach(KeyValuePair<string, VehicleInShop> current in r_VehicleList)
            {
                if(i_Status != null)
                {
                    if(current.Value.VehicleStatus.Equals(i_Status))
                    {
                        vehiclesToShow.Add(current.Value.VehicleLicensNumber);
                    }
                }
                else
                {
                    vehiclesToShow.Add(current.Value.VehicleLicensNumber);
                }
            }

            return vehiclesToShow;
        }

        public void SetNewStatusToVehicle(string i_LicenseNumber, VehicleInShop.eVehicleStatus i_NewStatus)
        {
            bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toChange);
            if(isExist)
            {
                if(toChange.VehicleStatus.Equals(i_NewStatus) == false)
                {
                    toChange.VehicleStatus = i_NewStatus;
                }
            }
            else
            {
                throw new ArgumentException(r_IsNotExistError);
            }
        }

        public void SetWheelsPressureToMaximum(string i_LicenseNumber)
        {
            bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop pressureToMaximum);
            if(isExist)
            {
                List<VehicleData.Wheel> wheelsList = pressureToMaximum.m_VehicleInShop.Wheels;
                foreach(VehicleData.Wheel currentWheel in wheelsList)
                {
                    currentWheel.WheelBlowing(currentWheel.MaxAirPressure - currentWheel.CurrentAirPressure);
                }
            }
            else
            {
                throw new ArgumentException(r_IsNotExistError);
            }
        }

        public void RefuelingVehicle(string i_LicenseNumber, FuelVehicle.eFuelType i_FuelType, float i_AmountToAdd)
        {
            try
            {
                bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toRefuel);
                if(isExist)
                {
                    FuelVehicle vehicle = toRefuel.m_VehicleInShop as FuelVehicle;
                    if(vehicle != null)
                    {
                        vehicle.Refueling(i_AmountToAdd, i_FuelType);
                    }
                }
                else
                {
                    throw new ArgumentException(r_IsNotExistError);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Fail refueling the vehicle", ex);
            }
        }

        public void LoadingVehicle(string i_LicenseNumber, float i_MinutesToLoad)
        {
            try
            {
                bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toRefuel);
                if (isExist)
                {
                    ElectricVehicle vehicle = toRefuel.m_VehicleInShop as ElectricVehicle;
                    if (vehicle != null)
                    {
                        vehicle.Loading(i_MinutesToLoad / 60);
                    }
                }
                else
                {
                    throw new ArgumentException(r_IsNotExistError);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fail loading the vehicle", ex);
            }
        }

        public string ShowDetailsOfVehicle(string i_LicenseNumber)
        {
            string vehicleDetails;
            bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toShow);
            if(isExist)
            {
                vehicleDetails = toShow.m_VehicleInShop.ToString();
            }
            else
            {
                throw new ArgumentException(r_IsNotExistError);
            }

            return vehicleDetails;
        }
    }
}
