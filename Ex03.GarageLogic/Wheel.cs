using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressuer;

        public Wheel(float i_MaxAirPressuer, string i_ManufacturerName = "")
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaxAirPressuer = i_MaxAirPressuer;
            m_CurrentAirPressure = 0;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendFormat("Wheel manufacturer name: {0}. Current air pressuer: {1}. Max air pressuer: {2}. ", r_ManufacturerName, m_CurrentAirPressure, r_MaxAirPressuer);
            toString.AppendLine();

            return toString.ToString(); 
        }
        public void Inflate(float i_WantedPressuer)
        {
            if(i_WantedPressuer > m_CurrentAirPressure && i_WantedPressuer <= r_MaxAirPressuer)
            {
                m_CurrentAirPressure = i_WantedPressuer;
            }
        }

        public float CurrentAirPressuer
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public float MaxAirPressuer
        {
            get
            {
                return r_MaxAirPressuer;
            }
        }
        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
            
        }
    }
}
