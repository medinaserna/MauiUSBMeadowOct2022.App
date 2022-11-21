using System;
namespace MauiUSBMeadowOct2022;

public class SolarCalc
{
	public int[] analogValue = new int[6]; //take the values sent by the Tx packet and select only the analog values
	public double[] analogVoltageArray = new double[6];
	public double analogVoltage = 0;

	//public SolarCalc()
	//{
	//}

	internal string GetCurrent(object value1, object value2)
	{
		throw new NotImplementedException();
	}

	internal string GetLEDCurrent(object value1, object value2)
	{
		throw new NotImplementedException();
	}

	public string GetVoltage(double analogVoltage)
	{


		analogVoltage = analogVoltage / 1000;
		return Convert.ToString(analogVoltage);



	}

	public void ParseSolarData(string validPacket)
	{

	//	analogVoltageArray[0] = 11;

		for (int i = 0; i < 6; i++)
		{

			analogValue[i] = Convert.ToInt32(validPacket.Substring((6 + 4 * i), 4));
			 analogVoltageArray[i] = analogValue[i]; //this analog voltage is in milivolts
			//Console.WriteLine("analog value %i %i", i, analogValue[i]); no me funciono
		}

	}
}

