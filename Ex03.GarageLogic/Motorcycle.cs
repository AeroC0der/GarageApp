using System;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Motorcycle : Vehicle
	{
		private readonly GarageEnums.eMotorcycleLicenseType r_LicenseType;
		private readonly int r_EngineVolume;

		public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_RemainEnergy,
			Wheel[] i_Wheels, GarageEnums.eMotorcycleLicenseType i_LicenseType, int i_EngineVolume, Engine i_Engine)
			: base(i_ModelName, i_LicenseNumber, i_RemainEnergy, i_Wheels, i_Engine)
		{
			r_LicenseType = i_LicenseType;
			r_EngineVolume = i_EngineVolume;
		}

		public GarageEnums.eMotorcycleLicenseType LicenseType
		{
			get { return r_LicenseType; }
		}

		public int EngineVolume
		{
			get { return r_EngineVolume; }
		}

        public override string ToString()
        {
            StringBuilder MotorcycleInfo = new StringBuilder();
            string vehicleInfo = base.ToString();

            MotorcycleInfo.Append("Vehicle Type: Motorcycle\n");
            MotorcycleInfo.Append($"{vehicleInfo}\n");
            MotorcycleInfo.Append($"License Type: {LicenseType}\n");
            MotorcycleInfo.Append($"Engine Volume {EngineVolume}\n");
            MotorcycleInfo.Append("=============\n");

            return MotorcycleInfo.ToString();
        }
    }
}
