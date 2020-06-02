using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected VehicleData m_VehicleData = null;

        protected void IntialNewWheelsOfVehicle(byte i_NumOfWheels, byte i_MaxAirPressure)
        {
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_VehicleData.VehicleWheels.Add(new VehicleData.Wheel(
                    string.Empty,
                    0,
                    i_MaxAirPressure));
            }
        }

        public abstract string[] SetVehicleData
        {
            set;
        }

        public StringBuilder AskForData
        {
            get
            {
                return m_VehicleData.AskForData();
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return m_VehicleData.VehicleLicenseNumber;
            }
        }

        internal float CurrentEnergy
        {
            get
            {
                return m_VehicleData.CurrentEnergy;
            }
        }

        internal float MaxEnergy
        {
            get
            {
                return m_VehicleData.MaxEnergy;
            }
        }

        internal List<VehicleData.Wheel> Wheels
        {
            get
            {
                return m_VehicleData.VehicleWheels;
            }
        }

        public override string ToString()
        { 
            return string.Format(
                format: @"Vehicle Model: {0}
Vehicle License: {1}
Wheel Data: 
{2}
Energy Left: {3:0.00} %
Current Energy: {4}",
                m_VehicleData.VehicleModel,
                m_VehicleData.VehicleLicenseNumber,
                printWheels(),
                m_VehicleData.EnergyLeft * 100,
                m_VehicleData.CurrentEnergy);
        }

        private StringBuilder printWheels()
        {
            StringBuilder wheelList = new StringBuilder();
            int index = 0;
            foreach (VehicleData.Wheel currentWheel in m_VehicleData.VehicleWheels)
            {
                wheelList.AppendLine(string.Format(format:@"Wheel {0}: {1}", ++index, currentWheel));
            }

            return wheelList;
        }
    }
}
