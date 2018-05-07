
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlate;
        private readonly List<Wheel> r_Wheels;
        private Tank m_Tank;
        protected readonly int r_NumberOfWheels;
        
        protected Vehicle(int i_NumOfWheels, float i_MaxAirPressuer, string i_WheelManufacturerName, string i_ModelName, string i_LicensePlate)
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            r_NumberOfWheels = i_NumOfWheels;
            r_Wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < r_NumberOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_MaxAirPressuer, i_WheelManufacturerName));
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendLine();
            toString.AppendLine("----------------------------------------------------------------------------------------");
            toString.AppendFormat("Model Name: {0}. License Plate: {1}.", r_ModelName, r_LicensePlate);
            toString.AppendLine();
            toString.AppendLine();
            toString.AppendFormat("---------------------------Wheels info ({0})----------------------", r_NumberOfWheels);
            toString.AppendLine();
            foreach(Wheel wheel in r_Wheels)
            {
                toString.AppendLine(wheel.ToString());
            }
            toString.AppendLine("-------------------------------Tank info---------------------------");
            toString.AppendLine(m_Tank.ToString());
            toString.AppendLine("-------------------------------Extra info--------------------------");
            return toString.ToString();
        }

        public void InflateAllWheelsToMaxCapaciy()
        {
            foreach(Wheel wheel in r_Wheels)
            {
                wheel.Inflate(wheel.MaxAirPressuer);
            }
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_Tank.RemainingEnergyPercentage;
            }
        }

        public void Fuel(float i_Amount)
        {
            m_Tank.Fuel(i_Amount);
        }

        public void Fuel(float i_EnergyToAdd, EnergyType i_FuelType)
        {
            m_Tank.Fuel(i_EnergyToAdd, i_FuelType);
        }

        protected Tank Tank
        {
            set
            {
                m_Tank = value;
            }
        }

        protected List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }
    }
}
