using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class VehicleData
    {
        protected internal class Wheel
        {
            private readonly float r_MaxAirPressure;
            private readonly string r_Manufacturer;
            private float m_CurrentAirPressure;

            internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
            {
                r_Manufacturer = i_ManufacturerName == string.Empty ? "Michelin" : i_ManufacturerName;
                m_CurrentAirPressure = i_CurrentAirPressure;
                r_MaxAirPressure = i_MaxAirPressure;
            }

            internal float CurrentAirPressure
            {
                get
                {
                    return m_CurrentAirPressure;
                }

                set
                {
                    float afterBlowing = m_CurrentAirPressure + value;
                    if(afterBlowing <= r_MaxAirPressure)
                    {
                        m_CurrentAirPressure = value;
                    }
                    else
                    {
                        string message = "Fail adding air to the wheel";
                        throw new ValueOutOfRangeException(0, r_MaxAirPressure, message);
                    }
                }
            }

            internal float MaxAirPressure
            {
                get
                {
                    return r_MaxAirPressure;
                }
            }

            internal void WheelBlowing(float i_AirToAdd)
            {
                float afterBlowing = CurrentAirPressure + i_AirToAdd;
                if (afterBlowing <= r_MaxAirPressure)
                {
                    m_CurrentAirPressure += i_AirToAdd;
                }
                else
                {
                    string message = "Fail add air to the wheel";
                    throw new ValueOutOfRangeException(0, r_MaxAirPressure, message);
                }
            }

            public override string ToString()
            {
                return string.Format(
                    format: @"Manufacturer: {0}, Current Air Pressure: {1}",
                    r_Manufacturer,
                    m_CurrentAirPressure);
            }
        }

        protected string m_VehicleModel;
        protected string m_VehicleLicenseNumber;
        protected float m_EnergyLeft; // out of 100%
        protected List<Wheel> m_VehicleWheels;
        protected float m_MaxEnergy;
        protected float m_CurrentEnergy;

        protected VehicleData(
            string i_VehicleModel,
            string i_VehicleLicenseNumber,
            byte i_NumberOfWheels,
            float i_CurrentEnergy,
            float i_MaxEnergy)
        {
            m_VehicleModel = i_VehicleModel;
            m_VehicleLicenseNumber = i_VehicleLicenseNumber;
            m_VehicleWheels = new List<Wheel>(i_NumberOfWheels);
            m_MaxEnergy = i_MaxEnergy;
            CurrentEnergy = i_CurrentEnergy;
            m_EnergyLeft = m_CurrentEnergy / m_MaxEnergy;
        }
        
        internal string VehicleModel
        {
            get
            {
               return m_VehicleModel;
            } 

            set
            {
                m_VehicleModel = value;
            } 
        }

        protected internal float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }
        }

        internal string VehicleLicenseNumber
        {
            get
            {
                return m_VehicleLicenseNumber;
            }
        }

        internal float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                if(value >= 0 && value <= m_MaxEnergy)
                {
                    m_CurrentEnergy = value;
                }
                else
                {
                    string message = "Energy added is off the limit";
                    throw new ValueOutOfRangeException(0, m_MaxEnergy, message);
                }
            }
        }

        internal float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }

            set
            {
                if(value >= 0)
                {
                    m_MaxEnergy = value;
                }
            }
        }

        internal List<Wheel> VehicleWheels
        {
            get
            {
                return m_VehicleWheels;
            }
        }

        public abstract override string ToString();
    }
}
