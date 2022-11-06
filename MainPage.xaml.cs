
using System.IO.Ports;
using System.Text;

namespace MauiUSBMeadowOct2022;

public partial class MainPage : ContentPage
{
	private bool bPortOpen = false;
	private string newPacket = "";
	private int oldPacketNumber = -1;
	private int newPacketNumber = 0;
	private int lostPacketCount = 0;
	private int packetRollover = 0;
	private int chkSumError = 0;


	StringBuilder stringBuilderSend = new StringBuilder("###1111196");

	SerialPort serialPort = new SerialPort();
	public MainPage()
	{
		InitializeComponent();

		string[] ports = SerialPort.GetPortNames();
		portPicker.ItemsSource = ports;
		portPicker.SelectedIndex = ports.Length;
		Loaded += MainPage_Loaded;
	}

	private void MainPage_Loaded(object sender, EventArgs e)
	{
		serialPort.BaudRate = 115200;
		serialPort.ReceivedBytesThreshold = 1;
		serialPort.DataReceived += SerialPort_DataReceived;
		setUpSerialPort();
	}

	private void setUpSerialPort()
	{
		
	}

	private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		newPacket = serialPort.ReadLine();
		//labelRXdata.Text = text;
		MainThread.BeginInvokeOnMainThread(MyMainThreadCode);
	}

	private void MyMainThreadCode()
	{
		//code to run on the main thread
		if (checkBoxHistory.IsChecked == true)
		{
			labelRxdata.Text = newPacket + labelRxdata.Text;
			}
		else
		{
			labelRxdata.Text = newPacket;
		}
		//labelPacketLenght.Text = newPacket.Lenght.ToString();
		int calChkSum = 0;
		if (newPacket.Length > 37)
		{
			if (newPacket.Substring(0, 3) == "###")
			{
				string parsedData = $"{newPacket.Length,-14}" +
									$"{newPacket.Substring(0, 3),-14}" +
									$"{newPacket.Substring(3, 3),-14}" +
									$"{newPacket.Substring(6, 4),-14}" +
									$"{newPacket.Substring(10, 4),-14}" +
									$"{newPacket.Substring(14, 4),-14}" +
									$"{newPacket.Substring(18, 4),-14}" +
									$"{newPacket.Substring(22, 4),-14}" +
									$"{newPacket.Substring(26, 4),-14}" +
									$"{newPacket.Substring(30, 4),-14}" +
									$"{newPacket.Substring(34, 3),-14}" + "\r\n";


				if (checkBoxParsedHistory.IsChecked == true)
				{
					labelParsedData.Text = parsedData + labelParsedData.Text;
				}
				else
				{
					labelParsedData.Text = parsedData;
				}

			}
		}
	}

	private void btnOpenClose_Clicked(object sender, EventArgs e)
	{
		if (!bPortOpen)
		{

			serialPort.PortName = portPicker.SelectedItem.ToString();
			serialPort.Open();
			btnOpenClose.Text = "Close";
			bPortOpen = true;
		}
		else
		{
			serialPort.Close();
			btnOpenClose.Text = "Open";
			bPortOpen = false;

		}

	}

	private void btnClear_Clicked(object sender, EventArgs e)
	{

	}

	private void btnSend_Clicked(object sender, EventArgs e)
	{

		try
		{
			string messageOut = entrySend.Text;
			messageOut += "\r\n";
			byte[] messageBytes = Encoding.UTF8.GetBytes(messageOut);
			serialPort.Write(messageBytes, 0, messageBytes.Length);
		}
		catch (Exception ex)
		{
			DisplayAlert("Alert", ex.Message, "Ok");
		}
	}
}

