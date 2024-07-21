using System;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Truck : Vehicle
	{
		private readonly bool r_DoesContainDangerousMaterials;
		private readonly float r_CargoTankVolume;

		public Truck(string i_ModelName, string i_LicenseNumber, float i_RemainEnergy,
			Wheel[] i_Wheels, bool i_DoesContainDangerousMaterials, float i_CargoTankVolume, Engine i_Engine) :
			base(i_ModelName, i_LicenseNumber, i_RemainEnergy, i_Wheels, i_Engine)
		{
			r_DoesContainDangerousMaterials = i_DoesContainDangerousMaterials;
			r_CargoTankVolume = i_CargoTankVolume;
		}

		public bool DoesContainDangerousMaterials
		{
			get { return r_DoesContainDangerousMaterials; }
		}

		public float CargoTankVolume
		{
			get { return r_CargoTankVolume; }
		}

        public override string ToString()
        {
            StringBuilder truckInfo = new StringBuilder();
			string vehicleInfo = base.ToString();

			truckInfo.Append("Vehicle Type: Truck\n");
			truckInfo.Append(vehicleInfo);
			truckInfo.Append($"Dangerous Goods: {(DoesContainDangerousMaterials ? "Yes": "No")}\n");
			truckInfo.Append($"Cargo Tank Volume {CargoTankVolume}\n");
            truckInfo.Append("=============\n");

			return truckInfo.ToString();
        }
    }
}
