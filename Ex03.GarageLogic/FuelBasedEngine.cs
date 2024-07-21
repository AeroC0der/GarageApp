using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelBasedEngine : Engine
    {
        private readonly GarageEnums.eFuelType r_FuelType;
        private float m_CurrentAmountOfFuel;

        public FuelBasedEngine(GarageEnums.eFuelType i_FuelType, float i_CurrentAmountOfEnergy, float i_MaxCapacity) : base(i_MaxCapacity, i_CurrentAmountOfEnergy)
        {
            r_FuelType = i_FuelType;
            m_CurrentAmountOfFuel = i_CurrentAmountOfEnergy;
        }

        public float CurrentAmountOfFuel
        {
            get { return m_CurrentAmountOfFuel; }
            set { m_CurrentAmountOfFuel = value; }
        }

        public GarageEnums.eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public override Type GetEngineType()
        {
            return this.GetType();
        }

        public string GetEngineTypeString()
        {
            return "Fuel";
        }

        public override bool Refill(float i_FuelAmountInLiters, GarageEnums.eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException("The given fuel is invalid for the selected vehicle.");
            }
            bool isSucceed = false;

            try
            {
                if (i_FuelAmountInLiters + CurrentAmountOfEnergy <= MaxCapacity && i_FuelAmountInLiters > 0)
                {
                    CurrentAmountOfEnergy += i_FuelAmountInLiters;
                    isSucceed = true;
                }
            }
            catch (ValueOutOfRangeException valueOutOfRangeExce)
            {
                throw new ValueOutOfRangeException("Fuel amount must be positive and not exceed the maximal amount", valueOutOfRangeExce, MaxCapacity, 0);
            }
            return isSucceed;
        }

        public override string ToString()
        {
            StringBuilder fuelEngineInfo = new StringBuilder();

            fuelEngineInfo.Append($"{base.ToString()}\n");
            fuelEngineInfo.Append($"Engine Type: {GetEngineTypeString()}\n");
            fuelEngineInfo.Append($"Fuel Type: {FuelType}\n");
            fuelEngineInfo.Append($"Current Amount of Fuel: {CurrentAmountOfEnergy}\n\n");

            return fuelEngineInfo.ToString();
        }
    }
}
