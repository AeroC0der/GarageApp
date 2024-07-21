using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string? r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            this.r_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public string? ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        private bool Inflate(float i_AirToFill)
        {
            bool isSucceed = false;

            try
            {
                if (this.CurrentAirPressure + i_AirToFill <= this.MaxAirPressure && i_AirToFill > 0)
                {
                    this.CurrentAirPressure += i_AirToFill;
                    isSucceed = true;
                }
            }
            catch (ValueOutOfRangeException valueOutOfRangeExce)
            {
                throw new ValueOutOfRangeException("Air amount exceeds max. capacity", valueOutOfRangeExce, MaxAirPressure, 0);
            }
            return isSucceed;
        }

        public void InfalteToMax()
        {
            Inflate(MaxAirPressure - CurrentAirPressure);
        }

        public override string ToString()
        {
            StringBuilder wheelInfo = new StringBuilder();

            wheelInfo.Append($"Manufacturer: {ManufacturerName}\n");
            wheelInfo.Append($"Current Air Pressure: {CurrentAirPressure}\n");
            wheelInfo.Append($"Max Air Pressure: {MaxAirPressure}\n");
            wheelInfo.Append("=============");

            return wheelInfo.ToString();
        }
    }
}
