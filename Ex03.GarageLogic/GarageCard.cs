using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageCard
    {
        private readonly string r_VehicleOwnerName;
        private readonly string r_OwnerPhoneNumber;
        private GarageEnums.eVehicleStatus m_VehicleStatus;

        public GarageCard(string i_VehicleOwnerName, string i_OwnerPhoneNumber)
        {
            r_VehicleOwnerName = i_VehicleOwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = GarageEnums.eVehicleStatus.InRepair;
        }

        public string VehicleOwnerName
        {
            get { return r_VehicleOwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return r_OwnerPhoneNumber; }
        }

        public GarageEnums.eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public override string ToString()
        {
            StringBuilder garageCardInfo = new StringBuilder();

            garageCardInfo.Append("---- Garage Card ----\n");
            garageCardInfo.Append($"Owner's Name: {VehicleOwnerName}\n");
            garageCardInfo.Append($"Owner's Phone: {OwnerPhoneNumber}\n");
            garageCardInfo.Append($"Vehicle's Status: {VehicleStatus}\n");

            return garageCardInfo.ToString();
        }
    }
}
