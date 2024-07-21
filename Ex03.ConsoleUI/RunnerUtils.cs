using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
	public class RunnerUtils
	{
        internal static void showGarageMenu()
        {
            Console.WriteLine(string.Format(@"
--------------------------------------------------------
Please enter your choice number:

1. Add a new vehicle to the garage

2. Show vehicle license numbers

3. Change vehicle status

4. Inflate air pressure to max

5. To refuel vehicle

6. Charge electric vehicle

7. Print vehicle information according to license number

8. Exit menu
--------------------------------------------------------"));
        }

        internal static void showVehicleLicenseNumbersList(GarageManager i_GarageManagerToOperate)
        {
            Console.WriteLine("Do you want to filter the vehicles by status? (Yes/No):");
            string filterChoice = Console.ReadLine().ToLower();
            bool filterByStatus = filterChoice == "yes";

            if (filterByStatus)
            {
                Console.WriteLine("Enter the status to filter by (InRepair, Repaired, Paid):");
                string statusInput = Console.ReadLine();

                if (Enum.TryParse(statusInput, true, out GarageEnums.eVehicleStatus status) && Enum.IsDefined(typeof(GarageEnums.eVehicleStatus), status))
                {
                    Dictionary<string, RegisteredVehicle> filteredVehicles = i_GarageManagerToOperate.GetVehicleByStatus(status);

                    if (filteredVehicles.Count == 0)
                    {
                        Console.WriteLine($"No vehicles found with the status {status}");
                    }
                    else
                    {
                        Console.WriteLine($"Vehicles with the status {status}:");
                        foreach (RegisteredVehicle registeredVehicle in filteredVehicles.Values)
                        {
                            Console.WriteLine(registeredVehicle.Vehicle.LicenseNumber);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid status entered.");
                }
            }
            else
            {
                Dictionary<string, RegisteredVehicle> allVehicles = i_GarageManagerToOperate.VehiclesInTheGarage;

                if (allVehicles.Count == 0)
                {
                    Console.WriteLine("No vehicles are currently registered in the garage.");
                }
                else
                {
                    Console.WriteLine(" ---- All registered vehicles: ----");
                    foreach (RegisteredVehicle registeredVehicle in allVehicles.Values)
                    {
                        Console.WriteLine($"License Number: {registeredVehicle.Vehicle.LicenseNumber}, Status: {registeredVehicle.GarageCard.VehicleStatus}");
                    }
                    Console.WriteLine(" -----------------------------------");
                }
            }
        }

        internal static void updateVehicleStatusInGarage(GarageManager i_GarageManagerToOperate)
        {
            Console.WriteLine("Please enter the vehicle's license number:");
            string licenseNumber = Console.ReadLine();

            if (!i_GarageManagerToOperate.IsContainVehicle(licenseNumber))
            {
                Console.WriteLine("The vehicle is not registered in the garage.");
                return;
            }

            Console.WriteLine("Enter the new status (InRepair, Repaired, Paid):");
            string statusInput = Console.ReadLine();

            if (Enum.TryParse(statusInput, true, out GarageEnums.eVehicleStatus newStatus) && Enum.IsDefined(typeof(GarageEnums.eVehicleStatus), newStatus))
            {
                i_GarageManagerToOperate.ChangeStatusOfVehicle(licenseNumber, newStatus);
                Console.WriteLine("The status has been updated.");
            }
            else
            {
                Console.WriteLine("Invalid status entered.");
            }
        }

        internal static void inflateWheelsToMax(GarageManager i_GarageManagerToOperate)
        {
            Console.WriteLine("Please enter the vehicle license number:");
            string licenseNumber = Console.ReadLine();

            if (!i_GarageManagerToOperate.IsContainVehicle(licenseNumber))
            {
                Console.WriteLine("The vehicle is not registered in the garage.");
                return;
            }

            i_GarageManagerToOperate.GetVehicleByLicenseNumber(licenseNumber).Vehicle.InflateWheelsToMax();
            Console.WriteLine("All wheels have been inflated to their maximum pressure.");
        }

        internal static void fillFuelVehicle(GarageManager i_GarageManagerToOperate)
        {
            Console.WriteLine("Please enter the vehicle license number:");
            string licenseNumber = Console.ReadLine();

            if (!i_GarageManagerToOperate.IsContainVehicle(licenseNumber))
            {
                Console.WriteLine("The vehicle is not registered in the garage.");
                return;
            }

            Console.WriteLine("Please enter the fuel type (Soler, Octane95, Octane96, Octane98):");
            string fuelTypeInput = Console.ReadLine();

            if (Enum.TryParse<GarageEnums.eFuelType>(fuelTypeInput, true, out GarageEnums.eFuelType fuelType) && Enum.IsDefined(typeof(GarageEnums.eFuelType), fuelType))
            {
                Console.WriteLine("Please enter the amount of fuel to fill:");
                float amountToFill;
                if (float.TryParse(Console.ReadLine(), out amountToFill))
                {
                    try
                    {
                        i_GarageManagerToOperate.FillVehicleFuel(licenseNumber, amountToFill, fuelType);
                        Console.WriteLine("The vehicle has been refueled.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount entered.");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel type entered.");
            }
        }

        internal static void chargeElectricVehicle(GarageManager i_GarageManagerToOperate)
        {
            Console.WriteLine("Please enter the vehicle license number:");
            string licenseNumber = Console.ReadLine();

            if (!i_GarageManagerToOperate.IsContainVehicle(licenseNumber))
            {
                Console.WriteLine("The vehicle is not registered in the garage.");
                return;
            }

            Console.WriteLine("Please enter the number of hours to charge:");
            float hoursToCharge;
            if (float.TryParse(Console.ReadLine(), out hoursToCharge))
            {
                try
                {
                    i_GarageManagerToOperate.ChargeVehicleEnergy(licenseNumber, hoursToCharge);
                    Console.WriteLine("The vehicle has been charged.");
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid number of hours entered.");
            }
        }

        internal static void showFullVehicleInformation(GarageManager i_GarageManagerToOperate)
        {
            Console.WriteLine("Please enter the vehicle license number:");
            string licenseNumber = Console.ReadLine();

            if (!i_GarageManagerToOperate.IsContainVehicle(licenseNumber))
            {
                Console.WriteLine("The vehicle is not registered in the garage.");
                return;
            }

            RegisteredVehicle registeredVehicle = i_GarageManagerToOperate.GetVehicleByLicenseNumber(licenseNumber);

            if (registeredVehicle != null)
            {
                Console.WriteLine("---- Registered Vehicle Information: ----");
                Console.WriteLine(registeredVehicle.ToString());
            }
        }
    }
}
