using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        bool m_IsTrunkCool;
        float m_TrunkSize;
        public Truck(string i_WheelManufacturerName, string i_ModelName, string i_LicensePlate)
            : base(12, 28, i_WheelManufacturerName, i_ModelName, i_LicensePlate)
        {
            Tank = new Tank(FuelType.Soler, 115f);
        }

        public bool IsTrunkCool
        {
            get
            {
                return m_IsTrunkCool;
            }
            set
            {
                m_IsTrunkCool = value;
            }
        }

        public float TrunkSize
        {
            get
            {
                return m_TrunkSize;
            }
            set
            {
                m_TrunkSize = value;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendLine(base.ToString());
            toString.AppendFormat("The Trumk is Cool: {0}. The Trunk's size is: {1}. ",m_IsTrunkCool, m_TrunkSize);
            toString.AppendLine();

            return toString.ToString();
        }
    }
}
