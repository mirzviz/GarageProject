using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum FuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
        Electricity
    }

    public class Tank
    {

        private readonly FuelType r_FuelType;
        private float m_CurrentCapacity;
        private readonly float r_MaxCapacity;

        public Tank(FuelType i_FuelType, float i_MaxCapacity)
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
        
        public FuelType FuelType
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
            if(r_FuelType == FuelType.Electricity)
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

        //private readonly float r_MaxCapacity;
        //private float m_CurrentCapacity;

        //protected Tank(float i_MaxCapacity)
        //{
        //    r_MaxCapacity = i_MaxCapacity;
        //    m_CurrentCapacity = 0;
        //}

        //public void Fuel(float i_Amount)
        //{
        //    if (i_Amount < 0 || m_CurrentCapacity + i_Amount > r_MaxCapacity)
        //    {
        //        //throw new ValueOutOfRangeException();
        //    }
        //    m_CurrentCapacity += i_Amount;
        //}

        //public float RemainingEnergyPercentage
        //{
        //    get
        //    {
        //       return (m_CurrentCapacity / r_MaxCapacity) * 100;
        //    }
        //}



    }
}