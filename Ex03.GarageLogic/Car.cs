using System;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Car : Vehicle
	{
		private readonly GarageEnums.eCarColor r_CarColor;
		private readonly GarageEnums.eNumberOfCarDoors r_NumOfCarDoors;

		public Car(GarageEnums.eCarColor i_CarColor, GarageEnums.eNumberOfCarDoors
			i_NumOfCarDoors, string i_ModelName, string i_LicenseNumber,
			float i_RemainEnergy, Wheel[] i_Wheels, Engine i_Engine) :
			base(i_ModelName, i_LicenseNumber, i_RemainEnergy, i_Wheels, i_Engine)
		{
			r_CarColor = i_CarColor;
			r_NumOfCarDoors = i_NumOfCarDoors;
		}

		public GarageEnums.eCarColor CarColor
		{
			get { return r_CarColor; }
		}

		public GarageEnums.eNumberOfCarDoors NumOfCarDoors
		{
			get { return r_NumOfCarDoors; }
		}

        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder();
            string vehicleInfo = base.ToString();

            carInfo.Append("Vehicle Type: Car\n");
            carInfo.Append($"{vehicleInfo}\n");
            carInfo.Append($"Color: {CarColor}\n");
            carInfo.Append($"Number of Doors: {NumOfCarDoors}\n");
            carInfo.Append("=============\n");

            return carInfo.ToString();
        }
    }
}
