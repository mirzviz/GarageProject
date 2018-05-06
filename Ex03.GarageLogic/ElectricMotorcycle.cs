using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{ 
    public class ElectricMotorcycle : Vehicle
    {
        private MotorcycleProperties m_MotorcycleProperties;

        public ElectricMotorcycle(string i_WheelManufacturerName, string i_ModelName, string i_LicensePlate) : base(2, 30, i_WheelManufacturerName, i_ModelName, i_LicensePlate)
        {
            Tank = new Tank(FuelType.Electricity, 1.8f);
        }

        public MotorcycleProperties MotorcycleProperties
        {
            get
            {
                return m_MotorcycleProperties;
            }
            set
            {
                m_MotorcycleProperties = value;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendLine(base.ToString());
            toString.AppendLine(m_MotorcycleProperties.ToString());

            return toString.ToString();
        }
    }
}
