using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private string m_NameOfOwner;
        private string m_PhoneOfOwner;
        private VehicleState m_VehicleState;
       
        private Vehicle m_Vehicle;
        
        public VehicleInGarage(string i_NameOfOwner, string i_PhoneOfOwner, Vehicle i_Vehicle)
        {
            m_NameOfOwner = i_NameOfOwner;
            m_PhoneOfOwner = i_PhoneOfOwner;
            m_Vehicle = i_Vehicle;
            m_VehicleState = VehicleState.InRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public VehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }

            set
            {
                m_VehicleState = value;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendLine(m_Vehicle.ToString());
            toString.AppendFormat("State: {0}", m_VehicleState.ToString());
            toString.AppendLine();
            toString.AppendFormat("Name of owner: {0}", m_NameOfOwner);
            toString.AppendLine();
            toString.AppendFormat("Phone of owner: {0}", m_PhoneOfOwner);
            toString.AppendLine();

            return toString.ToString();
        }
    }
}
