using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public struct Wheel
        {
            private string m_Manufacturer;
            private float m_CurrentAirPressure;
            private readonly float r_MaxAirPressure;

            public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
            {
                m_Manufacturer = i_ManufacturerName;
                m_CurrentAirPressure = i_CurrentAirPressure;
                r_MaxAirPressure = i_MaxAirPressure;
            }

            public void WheelBlowing(float i_AirToAdd)
            {
                float afterBlowing = m_CurrentAirPressure + i_AirToAdd;
                if(afterBlowing.CompareTo(r_MaxAirPressure) <= 0)
                {
                    m_CurrentAirPressure += i_AirToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException();
                }
            }
        }

        protected string m_VehicleModel;
        protected string m_VehicleLicenseNumber;
        protected float m_EnergyLeft; // out of 100%
        protected List<Wheel> m_VehicleWheels;

        public string VehicleLicenseNumber
        {
            get
            {
                return m_VehicleLicenseNumber;
            }
        }

        protected Vehicle(string i_VehicleModel, string i_VehicleLicenseNumber, float i_EnergyLeft, byte i_NumberOfWheels)
        {
            m_VehicleModel = i_VehicleModel;
            m_VehicleLicenseNumber = i_VehicleLicenseNumber;
            m_EnergyLeft = i_EnergyLeft;
            m_VehicleWheels = new List<Wheel>(i_NumberOfWheels);
        }


    }
}
