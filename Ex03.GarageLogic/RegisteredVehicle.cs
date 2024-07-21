using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class RegisteredVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly GarageCard r_GarageCard;

        public RegisteredVehicle(Vehicle i_Vehicle, GarageCard i_GarageCard)
        {
            r_Vehicle = i_Vehicle;
            r_GarageCard = i_GarageCard;
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public GarageCard GarageCard
        {
            get { return r_GarageCard; }
        }

        public override string ToString()
        {
            StringBuilder registeredVehicleInfo = new StringBuilder();

            registeredVehicleInfo.Append(Vehicle.ToString());
            registeredVehicleInfo.Append(GarageCard.ToString());

            return registeredVehicleInfo.ToString();
        }
    }
}
