using System;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.GarageEnums;

namespace Ex03.ConsoleUI
{
    public class Runner
    {
        private readonly GarageManager r_GarageManager = new GarageManager();
        private Vehicle? m_NewVehicle;

        public GarageManager GarageManagerToOperate
        {
            get { return r_GarageManager; }
        }

        public Vehicle NewVehicle
        {
            get { return m_NewVehicle; }
            set { m_NewVehicle = value; }
        }

        public void RunGarage()
        {
            Console.WriteLine(ConsoleRender.k_WelcomeMessage);
            bool stayInTheGarage = true;

            while (stayInTheGarage)
            {
                try
                {
                    RunnerUtils.showGarageMenu();
                    eGarageFunctionality userChoice = (eGarageFunctionality)Enum.Parse(typeof(eGarageFunctionality), Console.ReadLine());

                    switch (userChoice)
                    {
                        case eGarageFunctionality.InsertNewVehicle:
                            addVehicleToTheGarage();
                            break;
                        case eGarageFunctionality.ShowVehicleLicenseNumbers:
                            RunnerUtils.showVehicleLicenseNumbersList(GarageManagerToOperate);
                            break;
                        case eGarageFunctionality.UpdateVehicleStatus:
                            RunnerUtils.updateVehicleStatusInGarage(GarageManagerToOperate);
                            break;
                        case eGarageFunctionality.InflateWheels:
                            RunnerUtils.inflateWheelsToMax(GarageManagerToOperate);
                            break;
                        case eGarageFunctionality.FillFuelVehicle:
                            RunnerUtils.fillFuelVehicle(GarageManagerToOperate);
                            break;
                        case eGarageFunctionality.ChargeElectricVehicle:
                            RunnerUtils.chargeElectricVehicle(GarageManagerToOperate);
                            break;
                        case eGarageFunctionality.ShowFullVehicleInformation:
                            RunnerUtils.showFullVehicleInformation(GarageManagerToOperate);
                            break;
                        case eGarageFunctionality.Exit:
                            stayInTheGarage = false;
                            break;
                        default:
                            Console.WriteLine(ConsoleRender.k_InvalidNumberMessage);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void addVehicleToTheGarage()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine(ConsoleRender.k_EnterVehicleLicenseNumberMessage);
                string? vehicleLicenseNumber = Console.ReadLine();

                if (GarageManagerToOperate.IsContainVehicle(vehicleLicenseNumber))
                {
                    GarageManagerToOperate.ChangeStatusOfVehicle(vehicleLicenseNumber, GarageEnums.eVehicleStatus.InRepair);
                    Console.WriteLine(ConsoleRender.k_VehicleAlreadyRegisteredMessage);
                    return;
                }

                Console.WriteLine(ConsoleRender.k_EnterTypeOfVehicleMessage);
                string? inputTypeOfVehicle = Console.ReadLine();

                if (!inputTypeOfVehicle.All(char.IsDigit) && Enum.TryParse(inputTypeOfVehicle, true, out GarageEnums.eVehicleType typeOfVehicle) && Enum.IsDefined(typeof(GarageEnums.eVehicleType), typeOfVehicle))
                {
                    NewVehicle = createVehicle(typeOfVehicle, vehicleLicenseNumber);

                    if (NewVehicle != null)
                    {
                        isValidInput = true;

                        Console.WriteLine(ConsoleRender.k_EnterVehicleOwnerNameMessage);
                        string? ownerName = Console.ReadLine();

                        string? ownerPhoneNumber = "";
                        bool validPhoneNumber = false;
                        while (!validPhoneNumber)
                        {
                            Console.WriteLine(ConsoleRender.k_EnterVehicleOwnerPhoneNumberMessage);
                            ownerPhoneNumber = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(ownerPhoneNumber) || !ownerPhoneNumber.All(char.IsDigit))
                            {
                                Console.WriteLine("Invalid phone number. Please enter a valid numerical phone number.");
                            }
                            else
                            {
                                validPhoneNumber = true;
                            }
                        }

                        GarageCard garageCard = new GarageCard(ownerName, ownerPhoneNumber);
                        GarageManagerToOperate.RegisterVehicle(NewVehicle, garageCard);

                        Console.WriteLine(ConsoleRender.k_VehicleAddedSuccessMessage);
                    }
                }
                else
                {
                    Console.WriteLine(ConsoleRender.k_InvalidVehicleTypeMessage);
                }
            }
        }

        private Vehicle createVehicle(GarageEnums.eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            Console.WriteLine(ConsoleRender.k_EnterModelNameMessage);
            string? i_ModelName = Console.ReadLine();

            switch (i_VehicleType)
            {
                case GarageEnums.eVehicleType.Car:
                    return createCar(i_LicenseNumber, i_ModelName);
                case GarageEnums.eVehicleType.Motorcycle:
                    return createMotorcycle(i_LicenseNumber, i_ModelName);
                case GarageEnums.eVehicleType.Truck:
                    return createTruck(i_LicenseNumber, i_ModelName);
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_VehicleType), i_VehicleType, null);
            }
        }

        private Car createCar(string i_LicenseNumber, string i_ModelName)
        {
            GarageEnums.eCarColor carColor = getEnumInput<GarageEnums.eCarColor>(ConsoleRender.k_EnterCarColorMessage);
            GarageEnums.eNumberOfCarDoors numberOfDoors = getEnumInput<GarageEnums.eNumberOfCarDoors>(ConsoleRender.k_EnterNumberOfCarDoorsMessage);
            (float remainingEnergy, Engine engine) = createEngine(ConsoleRender.k_MaxRemainingElectricCarEnergy, ConsoleRender.k_MaxRemainingFuelCarEnergy, true);
            Wheel[] wheels = createWheels(ConsoleRender.k_NumOfCarWheels, (float)GarageEnums.eMaxAirPressure.CarMaxPressure);

            return new Car(carColor, numberOfDoors, i_ModelName, i_LicenseNumber, remainingEnergy, wheels, engine);
        }

        private Motorcycle createMotorcycle(string i_LicenseNumber, string i_ModelName)
        {
            GarageEnums.eMotorcycleLicenseType licenseType = getEnumInput<GarageEnums.eMotorcycleLicenseType>(ConsoleRender.k_EnterMotorcycleLicenseTypeMessage);
            int engineVolume = (int)getInputFloat(ConsoleRender.k_EnterMotorcycleEngineVolumeMessage, float.MaxValue);
            (float remainingEnergy, Engine i_Engine) = createEngine(ConsoleRender.k_MaxRemainingElectricBikeEnergy, ConsoleRender.k_MaxRemainingFuelBikeEnergy, true);
            Wheel[] wheels = createWheels(ConsoleRender.k_NumOfMotorcycleWheels, (float)GarageEnums.eMaxAirPressure.MotorcycleMaxPressure);

            return new Motorcycle(i_ModelName, i_LicenseNumber, remainingEnergy, wheels, licenseType, engineVolume, i_Engine);
        }

        private Truck createTruck(string i_LicenseNumber, string i_ModelName)
        {
            bool containsDangerousMaterials = getYesNoInput("Does the truck contain dangerous materials? (Yes/No)");
            float cargoVolume = getInputFloat("Please enter the cargo tank volume", float.MaxValue);
            (float remainingEnergy, Engine i_Engine) = createEngine(ConsoleRender.k_MaxRemainingTruckEnergy, ConsoleRender.k_MaxRemainingTruckEnergy, false);
            Wheel[] wheels = createWheels(ConsoleRender.k_NumOfTruckWheels, (float)GarageEnums.eMaxAirPressure.TruckMaxPressure);

            return new Truck(i_ModelName, i_LicenseNumber, remainingEnergy, wheels, containsDangerousMaterials, cargoVolume, i_Engine);
        }

        private Wheel[] createWheels(int i_NumberOfWheels, float i_MaxAirPressure)
        {
            Console.WriteLine(ConsoleRender.k_SetSameWheelManufacturerNameAndAirPressureMessage);
            string setAllWheelsSame = Console.ReadLine().ToLower();
            Wheel[] wheels = new Wheel[i_NumberOfWheels];

            if (setAllWheelsSame == "yes")
            {
                Console.WriteLine(ConsoleRender.k_EnterManufacturerNameForAllWheelsMessage);
                string manufacturerName = Console.ReadLine();
                float currentAirPressure = getInputFloat(ConsoleRender.k_EnterCurrentAirPressureForAllWheelsMessage, i_MaxAirPressure);

                for (int i = 0; i < i_NumberOfWheels; i++)
                {
                    wheels[i] = new Wheel(manufacturerName, currentAirPressure, i_MaxAirPressure);
                }
            }
            else
            {
                for (int i = 0; i < i_NumberOfWheels; i++)
                {
                    Console.WriteLine($"Enter the manufacturer name for wheel {i + 1}:");
                    string manufacturerName = Console.ReadLine();
                    float currentAirPressure = getInputFloat($"Enter the current air pressure for wheel {i + 1}", i_MaxAirPressure);
                    wheels[i] = new Wheel(manufacturerName, currentAirPressure, i_MaxAirPressure);
                }
            }
            return wheels;
        }

        private float getInputFloat(string i_Message, float i_MaxValidValue)
        {
            Console.WriteLine(i_Message);
            float userFloatInput;

            while (!float.TryParse(Console.ReadLine(), out userFloatInput) || userFloatInput < 0 || userFloatInput > i_MaxValidValue)
            {
                Console.WriteLine($"Invalid input! Please enter a valid number (0 to {i_MaxValidValue}).");
            }
            return userFloatInput;
        }

        private T getEnumInput<T>(string i_Message) where T : struct
        {
            Console.WriteLine(i_Message);
            T result;

            while (!Enum.TryParse(Console.ReadLine(), true, out result) || !Enum.IsDefined(typeof(T), result))
            {
                Console.WriteLine($"Invalid input! Please enter a valid {typeof(T).Name.ToString()}.");
            }
            return result;
        }

        private bool getYesNoInput(string i_Message)
        {
            Console.WriteLine(i_Message);
            string userInput;

            do
            {
                userInput = Console.ReadLine().ToLower();
                if (userInput == "yes")
                {
                    return true;
                }
                else if (userInput == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter 'Yes' or 'No'.");
                }
            } while (true);
        }

        private (float remainingEnergy, Engine engine) createEngine(float i_MaxElectricEnergy, float i_MaxFuelEnergy, bool i_AllowElectric)
        {
            Console.WriteLine(ConsoleRender.k_EnterEngineTypeMessage);
            string engineTypeInput = Console.ReadLine().ToLower();

            if (!i_AllowElectric && engineTypeInput == "electric")
            {
                throw new InvalidOperationException("Electric engines are not allowed for this vehicle type.");
            }

            float maxRemainingEnergy = engineTypeInput == "electric" ? i_MaxElectricEnergy : i_MaxFuelEnergy;
            float remainingEnergy = getInputFloat($"Please enter the amount of remaining energy (0 to {maxRemainingEnergy})", maxRemainingEnergy);
            Engine engine;

            if (engineTypeInput == "electric")
            {
                engine = new ElectricBasedEngine(remainingEnergy, i_MaxElectricEnergy);
            }
            else
            {
                engine = new FuelBasedEngine(GarageEnums.eFuelType.Octane95, remainingEnergy, i_MaxFuelEnergy);
            }
            return (remainingEnergy, engine);
        }
    }
}
