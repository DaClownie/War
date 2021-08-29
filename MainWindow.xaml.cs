using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace War
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			List<Card> DeckOfCards = new List<Card>();


		}

		private void MinimizeOnClick(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void CloseOnClick(object sender, RoutedEventArgs e)
		{
			//TODO: Needs something to save the current values as new default values?
			Application.Current.Shutdown();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}
	}
}
