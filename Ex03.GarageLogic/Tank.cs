using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum EnergyType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
        Electricity
    }

    public class Tank
    {

        private readonly EnergyType r_FuelType;
        private float m_CurrentCapacity;
        private readonly float r_MaxCapacity;

        public Tank(EnergyType i_FuelType, float i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
            r_MaxCapacity = i_MaxCapacity;
        }
        
        public void Fuel(float i_EnergyToAdd)
        {
            if (i_EnergyToAdd < 0 || m_CurrentCapacity + i_EnergyToAdd > r_MaxCapacity)
            {
                //  throw new ValueOutOfRangeException();
            }
            m_CurrentCapacity += i_EnergyToAdd;
        }

        public void Fuel(float i_EnergyToAdd, EnergyType i_FuelType)
        {
            if (r_FuelType == i_FuelType)
            {
                Fuel(i_EnergyToAdd);
            }
        }
         
        public EnergyType FuelType
        {
            get
            {
                return r_FuelType;
            }
        } 
        public float MaxCapacity
        {
            get
            {
                return r_MaxCapacity;
            }
        }
        public float CurrentCapacity
        {
            get
            {
                return m_CurrentCapacity;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return (m_CurrentCapacity / r_MaxCapacity) * 100;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            if(r_FuelType == EnergyType.Electricity)
            {
                toString.AppendLine("Tank: Electric Tank");
                toString.AppendLine();
                toString.AppendFormat("{0} Hours left out of {1}", m_CurrentCapacity, r_MaxCapacity);
            }
            else
            {
                toString.Append("Tank: Fuel Tank");
                toString.AppendLine();
                toString.AppendFormat("{0} Liters of {1} fuel are left out of {2} liters", m_CurrentCapacity, r_FuelType , r_MaxCapacity);
            }
            toString.AppendLine();

            return toString.ToString();
        }
        


    }
}