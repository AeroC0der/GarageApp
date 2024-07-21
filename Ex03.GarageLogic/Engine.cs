using System;
using static Ex03.GarageLogic.GarageEnums;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {

        private readonly float r_MaxCapacity;
        private float m_CurrentAmountOfEnergy;

        public Engine(float i_MaxCapacity, float i_CurrentAmountOfEnergy)
        {
            r_MaxCapacity = i_MaxCapacity;
            m_CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
        }

        public float MaxCapacity
        {
            get { return r_MaxCapacity; }
        }

        public float CurrentAmountOfEnergy
        {
            get { return m_CurrentAmountOfEnergy; }
            set { m_CurrentAmountOfEnergy = value; }
        }

        public abstract Type GetEngineType();

        public abstract bool Refill(float i_AmountToFill, GarageEnums.eFuelType i_FuelType);

        public override string ToString()
        {
            StringBuilder engineInfo = new StringBuilder();

            engineInfo.Append("---- Engine Information ----\n");
            engineInfo.Append($"Max Capacity: {MaxCapacity}");

            return engineInfo.ToString();
        }
    }
}
