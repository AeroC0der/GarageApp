using System;
namespace Ex03.ConsoleUI
{
    public static class ConsoleRender
    {
        // Constants for maximum remaining energy
        public const float k_MaxRemainingElectricCarEnergy = 3.5f;
        public const float k_MaxRemainingFuelCarEnergy = 45f;
        public const float k_MaxRemainingElectricBikeEnergy = 2.5f;
        public const float k_MaxRemainingFuelBikeEnergy = 5.5f;
        public const float k_MaxRemainingTruckEnergy = 120f;

        // Constants for number of wheels of each vehicle type
        public const int k_NumOfMotorcycleWheels = 2;
        public const int k_NumOfCarWheels = 4;
        public const int k_NumOfTruckWheels = 12;

        // Output strings
        public const string k_WelcomeMessage = "Welcome to our garage";
        public const string k_InvalidNumberMessage = "Invalid number! Please try again";
        public const string k_EnterVehicleLicenseNumberMessage = "Please enter your vehicle license number:";
        public const string k_VehicleAlreadyRegisteredMessage = "The given license number belongs to a vehicle already registered in the garage. The status has been changed to 'In Repair'.";
        public const string k_EnterTypeOfVehicleMessage = "Please enter the type of vehicle (Car, Motorcycle, or Truck):";
        public const string k_InvalidVehicleTypeMessage = "Invalid input! Please choose an appropriate vehicle type.";
        public const string k_EnterVehicleOwnerNameMessage = "Please enter the vehicle owner's name:";
        public const string k_EnterVehicleOwnerPhoneNumberMessage = "Please enter the owner's phone number:";
        public const string k_VehicleAddedSuccessMessage = "The vehicle has been successfully added to the garage.";
        public const string k_InvalidEngineTypeMessage = "Invalid engine type.";
        public const string k_EnterModelNameMessage = "Please enter the model name:";
        public const string k_EnterCarColorMessage = "Please enter the car color:";
        public const string k_InvalidCarColorMessage = "Invalid input! Please enter a valid car color.";
        public const string k_EnterNumberOfCarDoorsMessage = "Please enter the number of doors:";
        public const string k_InvalidNumberOfDoorsMessage = "Invalid input! Please enter a valid number of doors.";
        public const string k_EnterEngineTypeMessage = "Please enter the engine type (Electric or Fuel):";
        public const string k_EnterManufacturerNameForAllWheelsMessage = "Enter the manufacturer name for all wheels:";
        public const string k_EnterCurrentAirPressureForAllWheelsMessage = "Enter the current air pressure for all wheels:";
        public const string k_EnterWheelManufacturerNameMessage = "Enter the manufacturer name for wheel ";
        public const string k_EnterWheelCurrentAirPressureMessage = "Enter the current air pressure for wheel ";
        public const string k_EnterMotorcycleLicenseTypeMessage = "Please enter the license type:";
        public const string k_InvalidMotorcycleLicenseTypeMessage = "Invalid input! Please enter a valid license type.";
        public const string k_EnterMotorcycleEngineVolumeMessage = "Please enter the engine volume:";
        public const string k_InvalidMotorcycleEngineVolumeMessage = "Invalid input! Please enter a valid integer for the engine volume.";
        public const string k_InvalidTruckContainsDangerousMaterialsInputMessage = "Invalid input! Please enter 'Yes' or 'No'.";
        public const string k_InvalidCargoVolumeMessage = "Invalid input! Please enter a valid number for the cargo tank volume.";
        public const string k_EnterAllWheelManufacturerNameMessage = "Enter the manufacturer name for all wheels:";
        public const string k_EnterAllWheelCurrentAirPressureMessage = "Enter the current air pressure for all wheels:";
        public const string k_SetSameWheelManufacturerNameAndAirPressureMessage = "Do you want to set the same manufacturer name and air pressure for all wheels? (Yes/No):";
    }
}
