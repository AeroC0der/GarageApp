using System;
namespace Ex03.GarageLogic
{
	public class ValueOutOfRangeException : Exception
	{
		private readonly float r_MaxValue;
		private readonly float r_MinValue;

		public ValueOutOfRangeException(string i_Message, Exception i_InnerException
			, float i_MaxValue, float i_MinValue) : base(i_Message, i_InnerException)
		{
			r_MaxValue = i_MaxValue;
			r_MinValue = i_MinValue;
		}

		public float MaxValue
		{
			get { return r_MaxValue; }
		}

        public float MinValue
        {
            get { return r_MinValue; }
        }
    }
}
