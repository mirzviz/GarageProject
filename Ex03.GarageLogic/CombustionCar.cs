using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CombustionCar : Vehicle
    {
        private CarProperties m_CarProperties;

        public CombustionCar(string i_WheelManufacturerName, string i_ModelName, string i_LicensePlate) 
            : base(4, 32, i_WheelManufacturerName, i_ModelName, i_LicensePlate)
        {
            Tank = new Tank(EnergyType.Octan98, 45f);
        }

        public CarProperties CarProperties
        {
            get
            {
                return m_CarProperties;
            }

            set
            {
                m_CarProperties = value;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendLine(base.ToString());
            toString.AppendLine(m_CarProperties.ToString());

            return toString.ToString();
        }
    }
}
