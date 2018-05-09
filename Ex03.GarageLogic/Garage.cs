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

        private VehicleInGarage find(string i_LicensePlate)
        {
            VehicleInGarage vehicleWanted = null;
            foreach (VehicleInGarage vehicle in m_Vehicles)
            {
                if (vehicle.Vehicle.LicensePlate == i_LicensePlate)
                {
                    vehicleWanted = vehicle;
                }
            }

            return vehicleWanted;
        }
        
        public void AddVehicle(VehicleInGarage m_VehicleToAdd)
        {
            VehicleInGarage vehicleWithSameLicensePlate = find(m_VehicleToAdd.Vehicle.LicensePlate);
            if(vehicleWithSameLicensePlate != null)
            {
                vehicleWithSameLicensePlate.VehicleState = VehicleState.InRepair;
                throw new Exception("Vehicle Is Already in the garage! The state of the vehicle is changed to: in repair");
            }

            m_Vehicles.Add(m_VehicleToAdd);
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

        //עם אפשרות לסינון לפי המצב שלהם במוסך
        public string GetLicensePlatesByState(VehicleState i_vehicleState)
        {
            StringBuilder licensePlates = new StringBuilder();
            foreach (VehicleInGarage vehicleInGarage in m_Vehicles)
            {
                if (vehicleInGarage.VehicleState == i_vehicleState)
                {
                    licensePlates.AppendFormat("{0}, ", vehicleInGarage.Vehicle.LicensePlate);
                    licensePlates.AppendLine();
                }
            }

            return licensePlates.ToString();
        }
   
        public void ChangeVehicleState(string i_LicensePlate, VehicleState i_VehicleState)
        {
            VehicleInGarage vehicle = find(i_LicensePlate);
            if (vehicle == null)
            {
                throw new Exception("Changing state failed. Vehicle's license plate wasn't found");
            }

            vehicle.VehicleState = i_VehicleState;
        }


        public void InflateAllWheelsToMax(string i_LicensePlate)
        {
            VehicleInGarage vehicleWanted = find(i_LicensePlate);
            if (vehicleWanted == null)
            {
                throw new Exception("Inflating failed. Vehicle's license plate wasn't found");
            }

            vehicleWanted.Vehicle.InflateAllWheelsToMaxCapaciy();
        }

        public void fuelVehicle(string i_LicencePlate, EnergyType i_FuelType, float i_AddedFuel)
        {
            VehicleInGarage vehicleInGarage = find(i_LicencePlate);
            if (vehicleInGarage == null)
            {
                throw new Exception("Can't fuel! The vehicle's license plate is not found");
            }

            vehicleInGarage.Vehicle.FillTank(i_AddedFuel, i_FuelType);
        }

        public void chargeVehicle(string i_LicencePlate, float i_AddedTime)
        {
            VehicleInGarage vehicleInGarage = find(i_LicencePlate);
            if (vehicleInGarage != null)
            {
                throw new Exception("Can't charge! The vehicle's license plate is not found");
            }

            vehicleInGarage.Vehicle.FillTank(i_AddedTime, EnergyType.Electricity);
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            if (m_Vehicles.Count == 0)
            {
                toString.AppendLine("The garage is empty!");
                goto END;
            }
            foreach (VehicleInGarage vehicleInGarage in m_Vehicles)
            {
                toString.Append(vehicleInGarage.ToString());
            }
            toString.AppendLine();

            END:
            return toString.ToString();
        }
    }

}
