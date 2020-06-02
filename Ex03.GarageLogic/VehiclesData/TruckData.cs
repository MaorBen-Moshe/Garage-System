using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehiclesData
{
    public class TruckData : VehicleData
    {
        internal static readonly float sr_MaxTankFuel = 120;
        internal static readonly byte sr_NumberOfWheels = 16;
        internal static readonly byte sr_MaxPressureInWheel = 28;
        private float m_CargoVolume = 0;
        private bool m_IsHaveHazardousMaterials;

        private string CargoVolume
        {
            set
            {
                bool isValid = float.TryParse(value, out float cargoVolume);
                if (isValid)
                {
                    if (cargoVolume < 0)
                    {
                        throw new ArgumentException("Cargo volume cannot be negative");
                    }
                }
                else
                {
                    throw new FormatException("Fail parsing cargo volume");
                }
            }
        }

        public override StringBuilder AskForData()
        {
            StringBuilder data = base.AskForData();
            data.AppendLine("Enter cargo volume: ");
            data.AppendLine("Does your vehicle move hazardous materials: (y/n)");
            return data;
        }

        public override void GetData(string[] i_AllData)
        {
            m_VehicleModel = i_AllData[0];
            VehicleLicenseNumber = i_AllData[1];
            SetCurrentEnergy = i_AllData[2];
            CargoVolume = i_AllData[3];
            m_IsHaveHazardousMaterials = i_AllData[4].Equals("y");
            MaxEnergy = sr_MaxTankFuel;
            EnergyLeft = CurrentEnergy / MaxEnergy;
        }

        public override string ToString()
        {
            return string.Format(
                format: @"
Cargo volume: {0}
Truck {1} deliver hazardous materials",
                m_CargoVolume,
                m_IsHaveHazardousMaterials ? "is" : "is not");
        }
    }
}
