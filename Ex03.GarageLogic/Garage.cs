using System;
using System.Collections.Generic;
using System.Text;

public enum VehicleState
{
    InRepair,
    Repaired,
    Paid
}

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public List<VehicleInGarage> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new List<VehicleInGarage>();
        }
        
        public void AddVehicle(VehicleInGarage m_VehicleToAdd )
        {
            m_Vehicles.Add(m_VehicleToAdd);
        }

        public string getLicensePlatesByState(VehicleState i_vehicleState)
        {
            StringBuilder licensePlates = new StringBuilder();
            foreach(VehicleInGarage vehicleInGarage in m_Vehicles)
            {
                if(vehicleInGarage.VehicleState == i_vehicleState)
                {
                    licensePlates.AppendFormat("{0}, ", vehicleInGarage.Vehicle.LicensePlate);
                    licensePlates.AppendLine();
                }
            }

            return licensePlates.ToString();
        }

        public string GetAllLicensePlates()
        {
            StringBuilder licensePlates = new StringBuilder();
            foreach (VehicleInGarage vehicleInGarage in m_Vehicles)
            {
                    licensePlates.AppendFormat("{0}, ", vehicleInGarage.Vehicle.LicensePlate);
                    licensePlates.AppendLine();
            }

            return licensePlates.ToString();
        }




        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();   
            if(m_Vehicles.Count == 0)
            {
                toString.AppendLine("The garage is empty!");
                goto END;
            }
            foreach(VehicleInGarage vehicleInGarage in m_Vehicles)
            {
                toString.Append(vehicleInGarage.ToString());
            }
            toString.AppendLine();

            END:
            return toString.ToString();
        }
    }
    
}
