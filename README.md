
# Garage Management System

A C# console application for managing a garage. The system allows users to register vehicles, track their status, and perform various operations on them. This project demonstrates object-oriented programming principles, inheritance, and exception handling.

## Table of Contents

- [Description](#description)
- [Installation](#installation)
- [Usage](#usage)
- [File Structure](#file-structure)
- [Classes and Methods](#classes-and-methods)

## Description

The Garage Management System is a console-based application that allows users to manage different types of vehicles in a garage. Users can register cars, trucks, and motorcycles, track their status, and perform various operations like refueling or charging.

## Installation

To run this project, you need to have .NET installed on your machine. You can download it from the official [.NET website](https://dotnet.microsoft.com/download).

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/GarageManagementSystem.git
   ```

2. Navigate to the project directory:
   ```sh
   cd GarageManagementSystem
   ```

3. Build the project:
   ```sh
   dotnet build
   ```

## Usage

Run the project using the following command:
```sh
dotnet run
```

Follow the on-screen instructions to manage the garage.

## File Structure

### GarageLogic

- **Car.cs**: Public class that inherits from `Vehicle` and holds all the additional relevant fields for Car.
- **Truck.cs**: Public class that inherits from `Vehicle` and holds all the additional relevant fields for Truck.
- **Motorcycle.cs**: Public class that inherits from `Vehicle` and holds all the additional relevant fields for Motorcycle.
- **Vehicle.cs**: An abstract class that holds the shared vehicle properties such as Model Name, Engine, Wheels[], Remaining Energy Percentage, and License Number, that is, the shared structure between all the different vehicle types.
- **Wheel.cs**: Public class that represents the Wheel object and its properties.
- **Engine.cs**: An abstract class that holds the mutual information of an engine (Max capacity, current amount of energy).
- **FuelBasedEngine.cs**: Public class that inherits from `Engine` and holds the field of fuel type that the engine consumes, and also implements the `Refill()` method from the abstract `Engine` class.
- **ElectricBasedEngine.cs**: Public class that inherits from `Engine` and implements the `Refill()` method from the abstract `Engine` class.
- **GarageCard.cs**: Public class that holds the owner's name, owner phone number, and the owner's vehicle status.
- **RegisteredVehicle.cs**: Public class that represents a registered vehicle inside the garage.
- **GarageManager.cs**: Public class that holds all the registered vehicles in the garage and provides the functions that the UI uses for its functionality.
- **ValueOutOfRangeException.cs**: An extended inherited exception class for values that are out of the valid range. It holds two fields (`minValue`, `maxValue`) in addition to the inherited exception properties (`message`, `innerException`).

### ConsoleUI

- **Runner.cs**: Public class that runs the program, including all the functionality that the user needs to manage the garage and creates the program flow.
- **RunnerUtils.cs**: Public class that holds static methods, which get a `GarageManager` instance as a parameter to perform logic and manipulate it according to the client's requirements.
- **ConsoleRender.cs**: Public static class that consists of all the public constants for values known at compilation and needed for specific logics of the program, as well as the console string outputs.

### Enums

- **GarageEnums.cs**: Consists of all the relevant enums for the program, including `eMotorcycleLicenseType`, `eCarColor`, `eNumberOfCarDoors`, `eFuelType`, `eVehicleStatus`, `eMaxAirPressure`, and `eVehicleType` (Car, Motorcycle, Truck).
- **eGarageFunctionality.cs**: The garage's menu that holds all the options that can be done in the garage in the form of a ConsoleUI, letting the user access the console.

## Classes and Methods

### GarageLogic

#### Car.cs
Represents a car with specific properties inherited from `Vehicle`.

#### Truck.cs
Represents a truck with specific properties inherited from `Vehicle`.

#### Motorcycle.cs
Represents a motorcycle with specific properties inherited from `Vehicle`.

#### Vehicle.cs
Abstract class representing common properties of all vehicles.

#### Wheel.cs
Represents a wheel and its properties.

#### Engine.cs
Abstract class representing common properties of all engines.

#### FuelBasedEngine.cs
Represents a fuel-based engine with methods to refill fuel.

#### ElectricBasedEngine.cs
Represents an electric-based engine with methods to recharge.

#### GarageCard.cs
Represents the garage card with owner information and vehicle status.

#### RegisteredVehicle.cs
Represents a registered vehicle in the garage.

#### GarageManager.cs
Manages all registered vehicles and provides necessary functionality for the UI.

#### ValueOutOfRangeException.cs
Custom exception for handling values out of range with additional properties.

### ConsoleUI

#### Runner.cs
Runs the program and manages the main flow of the garage management system.

#### RunnerUtils.cs
Static methods to manipulate `GarageManager` according to client requirements.

#### ConsoleRender.cs
Contains constants and methods for rendering the console UI.

### Enums

#### GarageEnums.cs
Contains all the relevant enums for the program.

#### eGarageFunctionality.cs
Defines the menu options available in the garage console UI.

