using System;
using System.Collections.Generic;
using System.Text;

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

        protected readonly List<Wheel> r_VehicleWheels;
        protected string m_VehicleModel;
        protected string m_VehicleLicenseNumber;
        protected float m_EnergyLeft; // out of 100%
        protected float m_MaxEnergy;
        protected float m_CurrentEnergy;

        protected VehicleData()
        {
            r_VehicleWheels = new List<Wheel>();
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
                if(value > 1)
                {
                    m_EnergyLeft = 1;
                }
                else
                {
                    m_EnergyLeft = value;
                }
            }
        }

        internal string VehicleLicenseNumber
        {
            get
            {
                return m_VehicleLicenseNumber;
            }

            set
            {
                m_VehicleLicenseNumber = value;
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
                if (value >= 0 && value <= m_MaxEnergy)
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

        internal string SetCurrentEnergy
        {
            set
            {
                bool isFloat = float.TryParse(value, out float currentEnergy);
                if(isFloat)
                {
                    if (currentEnergy >= 0 && currentEnergy <= m_MaxEnergy)
                    {
                        m_CurrentEnergy = currentEnergy;
                    }
                    else
                    {
                        string message = "Energy added is off the limit";
                        throw new ValueOutOfRangeException(0, m_MaxEnergy, message);
                    }
                }
                else
                {
                    throw new FormatException("Fail adding current energy");
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
                return r_VehicleWheels;
            }
        }

        public virtual StringBuilder AskForData()
        {
            StringBuilder askForData = new StringBuilder();
            askForData.AppendLine("Enter your vehicle model: ");
            askForData.AppendLine("Enter your vehicle license number: ");
            askForData.AppendLine("Enter your vehicle current energy: ");
            return askForData;
        }

        public abstract void GetData(string[] i_AllData);

        public abstract override string ToString();
    }
}
