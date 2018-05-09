using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;



namespace Ex03.ConsoleUI
{
    public class ConsoleUser
    {
        Garage m_Garage;

        public ConsoleUser()
        {
            m_Garage = new Garage();
        }

        public void RunGarage()
        {
            try
            { 
                int action = getALeagalActionFromUser();
                while (action != 0)
                {
                        switch (action)
                        {
                            case 1:
                                addVehicle();
                                break;
                            case 2:
                                showLicensePlatesByState();
                                break;
                            case 3:
                                changeVehiclesStatus();
                                break;
                            case 4:
                                inflateWeels();
                                break;
                            case 5:
                                fuelVehicle();
                                break;
                            case 6:
                                break;
                            case 7:
                                printAllVehicles();
                                break;
                        }   

                        action = getALeagalActionFromUser();
                }
            }

            catch(ValueOutOfRangeException i_Exeption)
            {
                Console.WriteLine("Value out of range! min value: {0}. max value: {1}.", i_Exeption.MinValue, i_Exeption.MaxValue);
                Console.ReadLine();
                RunGarage();
            }

            catch(FormatException)
            {
                Console.WriteLine("Format Error!");
                Console.ReadLine();
                RunGarage();
            }

            catch(ArgumentException)
            {
                Console.WriteLine("Logical error: wrong energy type");
                Console.ReadLine();
                RunGarage();
            }
            
            catch(Exception Exception)
            {
                Console.WriteLine(Exception.Message);
                Console.ReadLine();
                RunGarage();
            }
        }

        private void fuelVehicle()
        {
            Console.WriteLine("Enter the amount of fuel to be added");
            string stringAmount = Console.ReadLine();
            float floatAmount;
            if(!float.TryParse(stringAmount, out floatAmount))
            {
                throw new FormatException();
            }

            Console.WriteLine("Enter the wanted fuel type");
            int intFuelType = getIntInRanges(0, 3);
            m_Garage.fuelVehicle(getLicnsePlateFromUser(), (EnergyType)intFuelType, floatAmount);
        }

        private void inflateWeels()
        {
            string licensePlate = getLicnsePlateFromUser();
            m_Garage.InflateAllWheelsToMax(licensePlate);
        }
        private void showLicensePlatesByState()
        {
            Console.Clear();
            Console.WriteLine("Enter 0 to show from In Repair vehicels. 1 to show from Repaired vehicles. 2 to Show from Paid vehicles. 3 to show all licnse plates. ");
            int vehicleStateInt = getIntInRanges(0, 3);
            if(vehicleStateInt == 3)
            {
                Console.WriteLine(m_Garage.GetAllLicensePlates());
            }
            else
            {
                Console.WriteLine(m_Garage.GetLicensePlatesByState((VehicleState)vehicleStateInt));
            }

            Console.ReadLine();
        }
            
        private void printAllVehicles()
        {
            Console.WriteLine(m_Garage.ToString());
            Console.ReadLine();
        }

        private void addVehicle()
        {
            Console.Clear();
            Console.WriteLine("Enter 0 for an Electric Car");
            Console.WriteLine("Enter 1 for a Combustion Car");
            Console.WriteLine("Enter 2 for an Electric Motorcycle");
            Console.WriteLine("Enter 3 for a Combustion Motorcycle");
            Console.WriteLine("Enter 4 for a Truck");
            string inputString = Console.ReadLine();
            int inputInt;
            while (!int.TryParse(inputString, out inputInt))
            {
                Console.WriteLine("Please enter a number");
                inputString = Console.ReadLine();
            }

            while (inputInt < 0 || inputInt > 4)
            {
                Console.WriteLine("Please enter a number from the list :)");
                inputString = Console.ReadLine();
            }

            int numberOfDoors;
            Color color;
            LicenseType licenseType;
            int intCapacity;
            TypeOfVehicle typeOfVehicle = (TypeOfVehicle)inputInt;
            Console.WriteLine("Enter Wheel Manufacturer Name");
            string weelManufaturerName = Console.ReadLine();
            Console.WriteLine("Enter Model Name");
            string ModelName = Console.ReadLine();
            Console.WriteLine("Enter License Plate");
            string LicensePlate = Console.ReadLine();
            Vehicle newVehicle = VehicleFactory.Generate(weelManufaturerName, ModelName, LicensePlate, typeOfVehicle);
            switch (typeOfVehicle)
            {
                case TypeOfVehicle.CombustionCar:
                    color = getColorFromUser();
                    Console.WriteLine("Enter the number of doors (2 - 5)");
                    numberOfDoors = getIntInRanges(2, 5);
                    ((CombustionCar)newVehicle).CarProperties = new CarProperties(color, numberOfDoors);
                    break;
                case TypeOfVehicle.ElectricCar:
                    color = getColorFromUser();
                    numberOfDoors = getNumberOfDoorsFromUser();
                    ((ElectricCar)newVehicle).CarProperties = new CarProperties(color, numberOfDoors);
                    break;
                case TypeOfVehicle.CombustionMotorcycle:
                    licenseType = getLicenseTypeFromUser();
                    intCapacity = getEngineCapacityFromUser();
                    ((CombustionMotorcycle)newVehicle).MotorcycleProperties = new MotorcycleProperties(intCapacity, licenseType);
                    break;
                case TypeOfVehicle.ElectricMotorcycle:
                    licenseType = getLicenseTypeFromUser();
                    intCapacity = getEngineCapacityFromUser();
                    ((ElectricMotorcycle)newVehicle).MotorcycleProperties = new MotorcycleProperties(intCapacity, licenseType);
                    break;
                case TypeOfVehicle.Truck:
                    Console.WriteLine("is trunk cool? 1 for yes, 0 for no.");
                    int isTrunkCoolInt = getIntInRanges(0, 1);
                    bool isTrunkCoolBool = isTrunkCoolInt == 1;
                    Console.WriteLine("Enter the trunk size");
                    float trunkSize;
                    if (!float.TryParse(Console.ReadLine(), out trunkSize))
                    {
                        throw new FormatException("Format Error");
                    }

                    if(trunkSize < 0)
                    {
                        throw new ValueOutOfRangeException(0, 1000);
                    }

                    Truck newTruck = newVehicle as Truck;
                    if(newTruck != null)
                    {
                        newTruck.IsTrunkCool = isTrunkCoolBool;
                        newTruck.TrunkSize = trunkSize;
                    }

                    break;
            }

            Console.WriteLine("Enter Name Of Owner");
            string nameOfOwner = Console.ReadLine();
            Console.WriteLine("Enter Phone Of Owner");
            string phoneOfOwner = Console.ReadLine();
            m_Garage.AddVehicle(new VehicleInGarage(nameOfOwner, phoneOfOwner, newVehicle));
        }

        private Color getColorFromUser()
        {
            Console.WriteLine("Enter the color of the car: 0 for gray. 1 for blue. 2 for white. 3 for black.");
            int intColor = getIntInRanges(0, 3);
            Color color = (Color)intColor;

            return color;
        }

        private int getNumberOfDoorsFromUser()
        {
            Console.WriteLine("Enter the number of doors (2 - 5)");
            int numberOfDoors = getIntInRanges(2, 5);

            return numberOfDoors;
        }

        private LicenseType getLicenseTypeFromUser()
        {
            Console.WriteLine("Enter the license type. 0 for A. 1 for A1. 2 for B1, 3 for B2");
            int intLicenseType = getIntInRanges(0, 3);
            LicenseType licenseType = (LicenseType)intLicenseType;

            return licenseType;
        }

        private int getEngineCapacityFromUser()
        {
            Console.WriteLine("Enter the engine capacity");
            int intCapacity = getIntInRanges(0, 800);

            return intCapacity;
        }
    
        private int getALeagalActionFromUser()
        {
            Console.Clear();
            Console.WriteLine("0 - Quit");
            Console.WriteLine("1 - Add a vehicle to the garage");
            Console.WriteLine("2 - Show license plates");
            Console.WriteLine("3 - Change a vehicle's status");
            Console.WriteLine("4 - Inflate all tires");
            Console.WriteLine("5 - Fuel a vehicle");
            Console.WriteLine("6 - Charge a vehicle");
            Console.WriteLine("7 - Show all the cars in the garage");
            Console.WriteLine("Enter action:");
            int inputInt =  getIntInRanges(0, 7);
            Console.Clear();

            return inputInt;
        }


        private int getIntInRanges(int i_Low, int i_High)
        {
            string inputString = Console.ReadLine();
            int inputInt;
            if (!int.TryParse(inputString, out inputInt))
            {
                throw new FormatException();
            }

            if (inputInt < i_Low || inputInt > i_High)
            {
                throw new ValueOutOfRangeException(i_Low, i_High);
            }

            return inputInt;
        }

        private void changeVehiclesStatus()
        {
            string licensePlate = getLicnsePlateFromUser();
            Console.WriteLine("Enter wanted state: 0 - in repair. 1 - repaired. 2 - paid");
            int intState = getIntInRanges(0, 2);
            m_Garage.ChangeVehicleState(licensePlate, (VehicleState)intState);
       }

        private string getLicnsePlateFromUser()
        {
            Console.WriteLine("Enter the vehicle's license plate");
            string licensePlate = Console.ReadLine();

            return licensePlate;
        }
    }
}
