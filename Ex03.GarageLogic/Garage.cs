using System;
using System.Collections.Generic;
using System.Text;

public enum VehicleState
{
    InRepair,
    Repaired,
    Paid
}

/*
 המערכת תספק את הפונקציונאליות הבאה למשתמש בה:
1. י"להכניס" רכב חדש למוסך. אם מנסים להכניס רכב שכבר נמצא במוסך
(עפ"י מספר רישוי),
המערכת תוציא הודעה מתאימה ותשתמש ברכב שכבר נמצא במוסך
(ותעביר את מצב הרכב ל- "בתיקון")
2. להציג את רשימת את מספרי הרישוי של הרכבים במוסך, עם אפשרות לסינון לפי המצב
שלהם במוסך.
3. לשנות מצב של רכב במוסך (מספר רישוי, המצב החדש).י
4. לנפח אוויר בגלגלים של רכב למקסימום (לפי מספר רישוי)י
5. לתדלק רכב שמונע ע"י דלק (מספר רישוי, סוג דלק למילוי, כמות למילוי)י
6. להטעין רכב חשמלי (מספר רישוי, כמות דקות להטענה)י
7. להציג נתונים מלאים של רכב לפי מספר רישוי 
(מספר רישוי, שם דגם, שם בעלים, מצב במוסך, פירוט הגלגלים 
(לחץ אוויר ויצרן), מצב דלק + סוג דלק / מצב מצבר, ושאר הפרטים הרלוונטיים לסוג הרכב הספציפי)
*/

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
        
        /*
        1. י"להכניס" רכב חדש למוסך. אם מנסים להכניס רכב שכבר נמצא במוסך
        (עפ"י מספר רישוי),
        המערכת תוציא הודעה מתאימה ותשתמש ברכב שכבר נמצא במוסך
        (ותעביר את מצב הרכב ל- "בתיקון")
        */
        public void AddVehicle(VehicleInGarage m_VehicleToAdd)
        {
            m_Vehicles.Add(m_VehicleToAdd);
        }

        /*
        2. להציג את רשימת את מספרי הרישוי של הרכבים במוסך, עם אפשרות לסינון לפי המצב
        שלהם במוסך.
        */
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

        //3. לשנות מצב של רכב במוסך(מספר רישוי, המצב החדש).י    
        private void changeVehicleState(string i_LicensePlate, VehicleState i_VehicleState)
        {
            //TODO
            VehicleInGarage vehicle = find(i_LicensePlate);
            if (vehicle != null)
            {
                vehicle.VehicleState = i_VehicleState;
            }
            else
            {
                //TODO NotExsistException
            }
        }


        private void InflateAllWheelsToMax(string i_LicensePlate)
        {
            VehicleInGarage vehicleWanted = find(i_LicensePlate);

            if (vehicleWanted != null)
            {
                vehicleWanted.Vehicle.InflateAllWheelsToMaxCapaciy();
            }

        }

        public void fuelVehicle(string i_LicencePlate, EnergyType i_FuelType, float i_AddedFuel)
        {
            VehicleInGarage vehicleInGarage = find(i_LicencePlate);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.Fuel(i_AddedFuel, i_FuelType);
            }
        }

        public void chargeVehicle(string i_LicencePlate, float i_AddedFuel)
        {
            VehicleInGarage vehicleInGarage = find(i_LicencePlate);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.Fuel(i_AddedFuel);
            }
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
