using System.Reflection;
using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Controls.Shapes;

namespace Issue220607_2_MAUI_DarkGray;

public class MainPage : ContentPage {

	public MainPage() {
		var grid=new Grid{VerticalOptions = LayoutOptions.Start};
		for (int i = 0; i < Enum.GetValues<Row>().Length; i++) grid.RowDefinitions.Add(new RowDefinition());
		for (int i = 0; i < 4; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());
		foreach (var e in Enum.GetValues<Row>()) {
			if (e == Row.Header) {
				var c = 0;
				grid.Children.Add(new Label{Text = "Header"}.Column(c++).Row((int)e));
				grid.Children.Add(new Label{Text = "ARGB"}.Column(c++).Row((int)e));
				grid.Children.Add(new Label{Text = "Luminosity"}.Column(c++).Row((int)e));
				grid.Children.Add(new Label{Text = "Sample"}.Column(c++).Row((int)e));
			}
			else if(e == Row.DarkGrayFix){
				var c = 0;
				grid.Children.Add(new Label{Text = e.ToString()}.Column(c++).Row((int)e));
				var color = new Color(1f - Colors.LightGray.GetLuminosity()); //#FF2B2B2B
				grid.Children.Add(new Label{Text = color.ToArgbHex()}.Column(c++).Row((int)e));
				grid.Children.Add(new Label{Text = color.GetLuminosity().ToString()}.Column(c++).Row((int)e));
				grid.Children.Add(new Rectangle{WidthRequest = 32, Fill=new SolidColorBrush(color)}.Column(c++).Row((int)e));
			}
			else {
				var c = 0;
				grid.Children.Add(new Label{Text = e.ToString()}.Column(c++).Row((int)e));
				var color = (Color) typeof(Colors).InvokeMember(e.ToString(), BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField, null, null, null);
				grid.Children.Add(new Label{Text = color.ToArgbHex()}.Column(c++).Row((int)e));
				grid.Children.Add(new Label{Text = color.GetLuminosity().ToString()}.Column(c++).Row((int)e));
				grid.Children.Add(new Rectangle{WidthRequest = 32, Fill=new SolidColorBrush(color)}.Column(c++).Row((int)e));
			}
		}
		Content = new ScrollView{Content = new VerticalStackLayout() {
			Children = {
				grid,
			}
		}};
	}

	private enum Row {Header, Black, DarkGray, DarkGrayFix, Gray, LightGray, White, 
		DarkBlue, Blue, LightBlue,
		DarkGreen, Green, LightGreen,
		DarkRed, Red, /*LightRed,*/
	}
}