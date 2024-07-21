using System;
using System.Text;

namespace Ex03.GarageLogic
{
	public class ElectricBasedEngine : Engine
	{
        private float m_CurrentAmountOfBattery;

        public ElectricBasedEngine(float i_CurrentAmountOfEnergy, float i_MaxCapacity) : base(i_MaxCapacity, i_CurrentAmountOfEnergy)
        {
            m_CurrentAmountOfBattery = i_CurrentAmountOfEnergy;
        }

        public float CurrentAmountOfBattery
        {
            get { return m_CurrentAmountOfBattery; }
            set { m_CurrentAmountOfBattery = value; }
        }

        public override Type GetEngineType()
        {
            return this.GetType();
        }

        public string GetEngineTypeString()
        {
            return "Electric";
        }

        public override bool Refill(float i_ChargeAmountInHours, GarageEnums.eFuelType i_FuelType = GarageEnums.eFuelType.Electric)
        {
            bool isSucceed = false;

            try
            {
                if (i_ChargeAmountInHours + CurrentAmountOfEnergy <= MaxCapacity && i_ChargeAmountInHours > 0)
                {
                    CurrentAmountOfEnergy += i_ChargeAmountInHours;
                    isSucceed = true;
                }
            }
            catch (ValueOutOfRangeException valueOutOfRangeExce)
            {
                throw new ValueOutOfRangeException("Charge amount must be positive and up to the maximal capacity.", valueOutOfRangeExce, MaxCapacity, 0);
            }
            return isSucceed;
        }

        public override string ToString()
        {
            StringBuilder electricEngineInfo = new StringBuilder();

            electricEngineInfo.Append($"{base.ToString()}\n");
            electricEngineInfo.Append($"Engine Type: {GetEngineTypeString()}\n");
            electricEngineInfo.Append($"Current Battery Life: {CurrentAmountOfEnergy}\n");

            return electricEngineInfo.ToString();
        }
    }
}
