using System.Text;

namespace Ex03.GarageLogic;

public abstract class Vehicle
{
    private readonly string r_ModelName;
    private readonly string r_LicenseNumber;
    private float m_RemainEnergy;
    private readonly Wheel[] r_Wheels;
    private readonly Engine r_Engine;

    public Vehicle(string i_ModelName, string i_LicenseNumber, float i_RemainEnergy, Wheel[] i_Wheels, Engine i_Engine)
    {
        r_ModelName = i_ModelName;
        r_LicenseNumber = i_LicenseNumber;
        m_RemainEnergy = i_RemainEnergy;
        r_Wheels = i_Wheels;
        r_Engine = i_Engine;
        m_RemainEnergy = (i_Engine.CurrentAmountOfEnergy / i_Engine.MaxCapacity) * 100;
    }

    public string ModelName
    {
        get { return r_ModelName; }
    }

    public string LicenseNumber
    {
        get { return r_LicenseNumber; }
    }

    public float RemainEnergy
    {
        get { return m_RemainEnergy; }
        set { m_RemainEnergy = value; }
    }

    public Wheel[] Wheels
    {
        get { return r_Wheels; }
    }

    public Engine Engine
    {
        get { return r_Engine; }
    }

    public void InflateWheelsToMax()
    {
        foreach (Wheel wheel in r_Wheels)
        {
            wheel.InfalteToMax();
        }
    }

    public override string ToString()
    {
        StringBuilder vehicleInfo = new StringBuilder();

        vehicleInfo.Append($"Model Name: {ModelName}\n");
        vehicleInfo.Append($"License Number: {LicenseNumber}\n");
        vehicleInfo.Append($"Remaining Energy: {RemainEnergy}%\n\n");
        vehicleInfo.Append($"{Engine.ToString()}");
        vehicleInfo.Append("\n--- Tire Information ---\n");

        for(int i = 0; i < Wheels.Length; i++)
        {
            vehicleInfo.Append($"Wheel {i + 1}: {Wheels[i].ToString()}\n");
        }

        return vehicleInfo.ToString();
    }
}
