using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Issue220607_2_MAUI_DarkGrayLightGray;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
