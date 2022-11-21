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

	public string GetCurrent(double AnalogVoltage1, double AnalogVoltage2)
	{
		double diffVoltage = AnalogVoltage1 - AnalogVoltage2;
		diffVoltage = diffVoltage / 100;
		string myCurrent = $"{Convert.ToString(diffVoltage)}" + "mA";
		return myCurrent;
    }

	internal string GetLEDCurrent(double AnalogVoltage1, double AnalogVoltage2)
	{
        double diffVoltage = AnalogVoltage1 - AnalogVoltage2;
		string myCurrent;

        if (diffVoltage > 0) {

            diffVoltage = diffVoltage / 100;
            myCurrent = $"{Convert.ToString(diffVoltage)}" + "mA";
          

        } else {
			myCurrent = $" 0 mA";
			
		}
		
		return myCurrent;
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

