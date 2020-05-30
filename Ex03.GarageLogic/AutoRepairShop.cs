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

            internal string VehicleLicensNumber
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

        public void AddVehicleToStore(VehicleInShop i_VehicleToAdd)
        {
            bool isExist = r_VehicleList.ContainsKey(i_VehicleToAdd.VehicleLicensNumber);
            if(isExist)
            {
                string argumentFormat = string.Format(
                    format: @"vehicle of type {0}, is in the garage with status: {1}, changed to be InRepair.",
                    i_VehicleToAdd.m_VehicleInShop.GetType(),
                    i_VehicleToAdd.VehicleStatus);
                i_VehicleToAdd.VehicleStatus = VehicleInShop.eVehicleStatus.InRepair;
                throw new ArgumentException(argumentFormat);
            }

            r_VehicleList.Add(i_VehicleToAdd.VehicleLicensNumber, i_VehicleToAdd);
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

        public void SetNewStatusToVehicle(string i_LicenseNumber, VehicleInShop.eVehicleStatus? i_NewStatus)
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
            }
            else
            {
                throw new ArgumentException(k_IsNotExistError);
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
                throw new ArgumentException(k_IsNotExistError);
            }
        }

        public void FillInEnergyToVehicle(
            string i_LicenseNumber,
            float i_AmountToAdd,
            FuelVehicle.eFuelType? i_FuelType = null)
        {
            try
            {
                bool isExist = r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInShop toRefuel);
                if (isExist)
                {
                    if (toRefuel.m_VehicleInShop is FuelVehicle)
                    {
                        FuelVehicle fuelVehicle = toRefuel.m_VehicleInShop as FuelVehicle;
                        fuelVehicle.Refueling(i_AmountToAdd, (FuelVehicle.eFuelType)i_FuelType);
                    }
                    else if(toRefuel.m_VehicleInShop is ElectricVehicle)
                    {
                        ElectricVehicle electricVehicle = toRefuel.m_VehicleInShop as ElectricVehicle;
                        electricVehicle.Loading(i_AmountToAdd / 60);
                    }
                }
                else
                {
                    throw new ArgumentException(k_IsNotExistError);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to fill in the energy in the vehicle", ex);
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
                throw new ArgumentException(k_IsNotExistError);
            }

            return vehicleDetails;
        }
    }
}
