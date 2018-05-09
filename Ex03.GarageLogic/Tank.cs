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
        private readonly EnergyType r_EnergyType;
        private float m_CurrentCapacity;
        private readonly float r_MaxCapacity;

        public Tank(EnergyType i_FuelType, float i_MaxCapacity)
        {
            r_EnergyType = i_FuelType;
            r_MaxCapacity = i_MaxCapacity;
        }
        
        public void FillTank(float i_EnergyToAdd, EnergyType i_FuelType)
        {
            if (r_EnergyType != i_FuelType)
            {
                throw new ArgumentException();
            }

            if (i_EnergyToAdd < 0 || m_CurrentCapacity + i_EnergyToAdd > r_MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, r_MaxCapacity - m_CurrentCapacity);
            }

            m_CurrentCapacity += i_EnergyToAdd;
        }
         
        public EnergyType FuelType
        {
            get
            {
                return r_EnergyType;
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
            if(r_EnergyType == EnergyType.Electricity)
            {
                toString.AppendLine("Tank: Electric Tank");
                toString.AppendLine();
                toString.AppendFormat("{0} Hours left out of {1}", m_CurrentCapacity, r_MaxCapacity);
            }
            else
            {
                toString.Append("Tank: Fuel Tank");
                toString.AppendLine();
                toString.AppendFormat("{0} Liters of {1} fuel are left out of {2} liters", m_CurrentCapacity, r_EnergyType , r_MaxCapacity);
            }
            toString.AppendLine();

            return toString.ToString();
        }
    }
}