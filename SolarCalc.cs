using System;
namespace MauiUSBMeadowOct2022;

public class SolarCalc
{
	public int[] analogValue = new int[6];

	public SolarCalc()
	{
	}

	internal string GetCurrent(object value1, object value2)
	{
		throw new NotImplementedException();
	}

	internal string GetLEDCurrent(object value1, object value2)
	{
		throw new NotImplementedException();
	}

	internal string GetVoltage(object value)
	{
		throw new NotImplementedException();
	}

	internal void ParseSolarData(string validPacket)
	{

		for (int i = 0; i < 6; i++) { 
		analogValue[i] = Convert.ToInt32(validPacket.Substring((6 + 4*i), 4));
        }

    }
}
