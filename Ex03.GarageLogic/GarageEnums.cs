using System;
namespace Ex03.GarageLogic
{
    public class GarageEnums
    {
        public enum eMotorcycleLicenseType
        {
            A,
            A1,
            AA,
            B1,
        }

        public enum eCarColor
        {
            Red,
            White,
            Gray,
            Yellow,
        }

        public enum eNumberOfCarDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }

        public enum eFuelType
        {
            Soler,
            Octane95,
            Octane96,
            Octane98,
            Electric,
        }

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid,
        }

        public enum eMaxAirPressure
        {
            MotorcycleMaxPressure = 33,
            CarMaxPressure = 31,
            TruckMaxPressure = 28,
        }

        public enum eVehicleType
        {
            Car,
            Truck,
            Motorcycle
        }
    }
}
