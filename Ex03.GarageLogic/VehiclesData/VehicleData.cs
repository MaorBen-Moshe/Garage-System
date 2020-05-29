using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class VehicleData
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

            public float CurrentAirPressure
            {
                get
                {
                    return m_CurrentAirPressure;
                }
            }

            public float MaxAirPressure
            {
                get
                {
                    return r_MaxAirPressure;
                }
            }

            public void WheelBlowing(float i_AirToAdd)
            {
                float afterBlowing = m_CurrentAirPressure + i_AirToAdd;
                if (afterBlowing.CompareTo(r_MaxAirPressure) <= 0)
                {
                    m_CurrentAirPressure += i_AirToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxAirPressure);
                }
            }

            public override string ToString()
            {
                return string.Format(
                    format: @"Manufacter: {0},Current Air Pressure: {1}",
                    m_Manufacturer,
                    m_CurrentAirPressure);
            }
        }

        protected string m_VehicleModel;
        protected string m_VehicleLicenseNumber;
        protected float m_EnergyLeft; // out of 100%
        protected List<Wheel> m_VehicleWheels;
        protected float m_MaxEnergy;
        protected float m_CurrentEnergy;

        protected VehicleData(string i_VehicleModel,
                              string i_VehicleLicenseNumber,
                              byte i_NumberOfWheels,
                              float i_CurrentEnergy)
        {
            m_VehicleModel = i_VehicleModel;
            m_VehicleLicenseNumber = i_VehicleLicenseNumber;
            m_VehicleWheels = new List<Wheel>(i_NumberOfWheels);
            m_CurrentEnergy = i_CurrentEnergy;
        }
        

        public string VehicleModel
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
        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }

            set
            {
                m_EnergyLeft = value < 1 ? value : 1;
            }
        }

        public string VehicleLicenseNumber
        {
            get
            {
                return m_VehicleLicenseNumber;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                m_CurrentEnergy = value;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
            set
            {
                m_MaxEnergy = value;
            }
        }

        public List<Wheel> VehicleWheels
        {
            get
            {
                return m_VehicleWheels;
            }
        }

        public abstract override string ToString();
    }
}
