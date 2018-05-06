using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum LicenseType
    {
        A,
        A1,
        B1,
        B2
    }

    public struct MotorcycleProperties
    {
        private int m_EngineCapacity;
        private LicenseType m_LicenseType;

        public MotorcycleProperties(int i_EngineCapacity, LicenseType i_LicenseType)
        {
            m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendFormat("Engine Capacity: {0}. License Type: {1}", m_EngineCapacity, m_LicenseType);

            return toString.ToString();
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }

        public LicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }
    }
}
