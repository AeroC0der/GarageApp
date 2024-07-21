using System;
using System.Text;
using static Ex03.GarageLogic.GarageEnums;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, RegisteredVehicle> m_VehiclesInTheGarage;

        public GarageManager()
        {
            m_VehiclesInTheGarage = new Dictionary<string, RegisteredVehicle>();
        }

        public Dictionary<string, RegisteredVehicle> VehiclesInTheGarage
        {
            get { return m_VehiclesInTheGarage; }
        }

        public bool IsContainVehicle(string i_LicenseNumber)
        {
            return m_VehiclesInTheGarage.ContainsKey(i_LicenseNumber);
        }

        public RegisteredVehicle GetVehicleByLicenseNumber(string i_LicenseNumber)
        {
            return m_VehiclesInTheGarage[i_LicenseNumber];
        }

        public void RegisterVehicle(Vehicle i_Vehicle, GarageCard i_GarageCard)
        {
            RegisteredVehicle vehicleToRegister = new RegisteredVehicle(i_Vehicle, i_GarageCard);
            m_VehiclesInTheGarage[i_Vehicle.LicenseNumber] = vehicleToRegister;
        }

        public void ChangeStatusOfVehicle(string i_LicenseNumber, GarageEnums.eVehicleStatus i_NewStatus)
        {
            m_VehiclesInTheGarage[i_LicenseNumber].GarageCard.VehicleStatus = i_NewStatus;
        }

        public Dictionary<string, RegisteredVehicle> GetVehicleByStatus(GarageEnums.eVehicleStatus i_VehicleStatus)
        {
            Dictionary<string, RegisteredVehicle> registeredVehiclesByStatusDict = new Dictionary<string, RegisteredVehicle>();

            foreach (string registeredVehicleLicenseNumber in m_VehiclesInTheGarage.Keys)
            {
                if (m_VehiclesInTheGarage[registeredVehicleLicenseNumber].GarageCard.VehicleStatus == i_VehicleStatus)
                {
                    registeredVehiclesByStatusDict.Add(registeredVehicleLicenseNumber, m_VehiclesInTheGarage[registeredVehicleLicenseNumber]);
                }
            }

            return registeredVehiclesByStatusDict;
        }

        public Type GetVehicleEnergyType(string i_LicenceNumber)
        {
            return GetVehicleByLicenseNumber(i_LicenceNumber).Vehicle.Engine.GetEngineType();
        }

        public void FillVehicleFuel(string i_LicenseNumber, float i_FuelAmountToFill, GarageEnums.eFuelType i_FuelType)
        {
            try
            {
                GetVehicleByLicenseNumber(i_LicenseNumber).Vehicle.Engine.Refill(i_FuelAmountToFill, i_FuelType);

            }
            catch (InvalidCastException invalidCastExce)
            {
                throw new ArgumentException("Invalid fuel format to fill.", invalidCastExce);
            }
        }

        public void ChargeVehicleEnergy(string i_LicenseNumber, float i_MinutesToCharge)
        {
            try
            {
                GetVehicleByLicenseNumber(i_LicenseNumber).Vehicle.Engine.Refill(i_MinutesToCharge, eFuelType.Electric);

            }
            catch (InvalidCastException invalidCastExce)
            {
                throw new ArgumentException("Invalid electric charge format to fill.", invalidCastExce);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("==== Garage Vehicles Summary: ====");
            foreach (KeyValuePair<string, RegisteredVehicle> vehicleEntry in m_VehiclesInTheGarage)
            {
                stringBuilder.AppendLine($"License Number: {vehicleEntry.Key}");
                stringBuilder.AppendLine($"Vehicle Type: {vehicleEntry.Value.Vehicle.GetType().Name}");
                stringBuilder.AppendLine($"Vehicle Status: {vehicleEntry.Value.GarageCard.VehicleStatus}");
                stringBuilder.AppendLine("==============================");
            }

            return stringBuilder.ToString();
        }
    }
}
