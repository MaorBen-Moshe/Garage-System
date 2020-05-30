using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class VehicleData
    {
        protected internal struct Wheel
        {
            private readonly float r_MaxAirPressure;
            private readonly string r_Manufacturer;
            private float m_CurrentAirPressure;

            internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
            {
                r_Manufacturer = i_ManufacturerName ?? "Michelin";
                m_CurrentAirPressure = i_CurrentAirPressure;
                r_MaxAirPressure = i_MaxAirPressure;
            }

            internal float CurrentAirPressure
            {
                get
                {
                    return m_CurrentAirPressure;
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
                    format: @"Manufacturer: {0},Current Air Pressure: {1}",
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
            float i_CurrentEnergy)
        {
            m_VehicleModel = i_VehicleModel;
            m_VehicleLicenseNumber = i_VehicleLicenseNumber;
            m_VehicleWheels = new List<Wheel>(i_NumberOfWheels);
            CurrentEnergy = i_CurrentEnergy;
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

            set
            {
                if(value >= 0)
                {
                    m_EnergyLeft = value < 1 ? value : 1;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, 1);
                }
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
                    throw new ValueOutOfRangeException(0, m_MaxEnergy);
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
                if(m_VehicleWheels.Count > 0)
                {
                    return m_VehicleWheels;
                }

                throw new NullReferenceException("Wheels list is Empty");
            }
        }

        public abstract override string ToString();
    }
}
