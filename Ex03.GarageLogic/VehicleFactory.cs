using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum TypeOfVehicle
    {
        ElectricCar,
        CombustionCar,
        ElectricMotorcycle,
        CombustionMotorcycle,
        Truck
    }

    public class VehicleFactory
    {
        private const string m_supports = "Electric Car, Combustion Car, Electric Motorcycle, Combustion Motorcycle, Truck";
        
        public static Vehicle Generate(string i_WheelManufacturerName, string i_ModelName, string i_LicensePlate, TypeOfVehicle type)
        {
            Vehicle vehicleToReturn = null;
            switch(type)
            {
                case TypeOfVehicle.CombustionCar:
                    vehicleToReturn = new CombustionCar(i_WheelManufacturerName, i_ModelName, i_LicensePlate);
                    break;
                case TypeOfVehicle.CombustionMotorcycle:
                    vehicleToReturn = new CombustionMotorcycle(i_WheelManufacturerName, i_ModelName, i_LicensePlate);
                    break;
                case TypeOfVehicle.ElectricCar:
                    vehicleToReturn = new ElectricCar(i_WheelManufacturerName, i_ModelName, i_LicensePlate);
                    break;
                case TypeOfVehicle.ElectricMotorcycle:
                    vehicleToReturn = new ElectricMotorcycle(i_WheelManufacturerName, i_ModelName, i_LicensePlate);
                    break;
                case TypeOfVehicle.Truck:
                    vehicleToReturn = new Truck(i_WheelManufacturerName, i_ModelName, i_LicensePlate);
                    break;
            }

            return vehicleToReturn;
        }
    }
}
