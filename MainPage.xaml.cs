using System.IO.Ports;

namespace MauiUSBMeadowOct2022;

public partial class MainPage : ContentPage
{

	private bool bPortOpen = false;
	private string newPacket = "";


	public MainPage()
	{
		InitializeComponent();
		string[] ports = SerialPort.GetPortNames();

		foreach (string port in ports) { 
		
			portPicker.Items.Add(port);
		}
	}


	private void btnOpenClose_Clicked(object sender, EventArgs e)
		{
	
}

private void btnClear_Clicked(object sender, EventArgs e)
		{
	
}

	private void btnSend_Clicked(object sender, EventArgs e) { 
	
	
	}


	
}

