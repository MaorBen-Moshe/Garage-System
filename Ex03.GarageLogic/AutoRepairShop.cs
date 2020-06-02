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
                InRepair = 1,
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

            public string VehicleLicensNumber
            {
                get
                {
                    return m_VehicleInShop.LicenseNumber;
                }
            }

            internal eVehicleStatus VehicleStatus
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

        private const string k_IsNotExistError = "Vehicle do not exist in the garage";
        private readonly Dictionary<string, VehicleInShop> r_VehicleList;

        public AutoRepairShop()
        {
            r_VehicleList = new Dictionary<string, VehicleInShop>();
        }

        public void AddVehicleToStore(VehicleInShop i_VehicleToAdd, out bool o_IsSucceeded)
        {
            bool isExist = ContainsLicenseNumber(i_VehicleToAdd.VehicleLicensNumber);
            if(isExist)
            {
                string argumentFormat = string.Format(
                    format: @"vehicle of type {0}, is in the garage with status: {1}, changed to be InRepair.",
                    i_VehicleToAdd.m_VehicleInShop.GetType().Name,
                    i_VehicleToAdd.VehicleStatus);
                i_VehicleToAdd.VehicleStatus = VehicleInShop.eVehicleStatus.InRepair;
                o_IsSucceeded = false;
                throw new ArgumentException(argumentFormat);
            }

            r_VehicleList.Add(i_VehicleToAdd.VehicleLicensNumber, i_VehicleToAdd);
            o_IsSucceeded = true;
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

        public void SetNewStatusToVehicle(string i_LicenseNumber, VehicleInShop.eVehicleStatus? i_NewStatus, out bool o_IsSucceeded)
        {
            bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toChange);
            if(isExist)
            {
                if(toChange.VehicleStatus.Equals(i_NewStatus) == false)
                {
                    if(i_NewStatus != null)
                    {
                        toChange.VehicleStatus = (VehicleInShop.eVehicleStatus)i_NewStatus;
                    }
                }

                o_IsSucceeded = true;
            }
            else
            {
                o_IsSucceeded = false;
                throw new ArgumentException(k_IsNotExistError);
            }
        }

        public void SetWheelsPressureToMaximum(string i_LicenseNumber, out bool o_IsSucceeded)
        {
            bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop pressureToMaximum);
            if(isExist)
            {
                for (int i = 0; i < pressureToMaximum.m_VehicleInShop.Wheels.Count; i++)
                {
                    float maxPressure = pressureToMaximum.m_VehicleInShop.Wheels[i].MaxAirPressure;
                    float currentPressure = pressureToMaximum.m_VehicleInShop.Wheels[i].CurrentAirPressure;
                    pressureToMaximum.m_VehicleInShop.Wheels[i].WheelBlowing(maxPressure - currentPressure);
                }

                o_IsSucceeded = true;
            }
            else
            {
                o_IsSucceeded = false;
                throw new ArgumentException(k_IsNotExistError);
            }
        }

        public void FillInEnergyToVehicle(
            string i_LicenseNumber,
            float i_AmountToAdd,
            out bool o_IsSucceeded,
            FuelVehicle.eFuelType? i_FuelType = null)
        {
            try
            {
                o_IsSucceeded = false;
                bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toRefuel);
                if (isExist)
                {
                    if (toRefuel.m_VehicleInShop is FuelVehicle && i_FuelType != null)
                    {
                        FuelVehicle fuelVehicle = toRefuel.m_VehicleInShop as FuelVehicle;
                        if(fuelVehicle != null)
                        {
                            fuelVehicle.Refueling(i_AmountToAdd, (FuelVehicle.eFuelType)i_FuelType);
                            o_IsSucceeded = true;
                        }
                    }
                    else if(toRefuel.m_VehicleInShop is ElectricVehicle)
                    {
                        ElectricVehicle electricVehicle = toRefuel.m_VehicleInShop as ElectricVehicle;
                        if(electricVehicle != null)
                        {
                            electricVehicle.Loading(i_AmountToAdd / 60);
                            o_IsSucceeded = true;
                        }
                    }
                }
                else
                {
                    o_IsSucceeded = false;
                    throw new ArgumentException(k_IsNotExistError);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to fill in the energy in the vehicle", ex);
            }
        }

        public string ShowDetailsOfVehicle(string i_LicenseNumber, out bool o_IsSucceeded)
        {
            string vehicleDetails;
            bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toShow);
            if(isExist)
            {
                vehicleDetails = toShow.m_VehicleInShop.ToString();
                o_IsSucceeded = true;
            }
            else
            {
                o_IsSucceeded = false;
                throw new ArgumentException(k_IsNotExistError);
            }

            return vehicleDetails;
        }

        public bool ContainsLicenseNumber(string i_LicenseNumber)
        {
            return r_VehicleList.ContainsKey(i_LicenseNumber);
        }
    }
}
