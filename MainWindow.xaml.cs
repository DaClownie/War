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
			NumberOfGames.ItemsSource = Enumerable.Range(5, 96);


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

		private void GitHubButton_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer.exe", "https://github.com/DaClownie/War");
		}

		private void SimulateButton_Click(object sender, RoutedEventArgs e)
		{
			//TODO: Should read all settings, send those to the methods for deck building, initialize the simulation x number of times based on input as well
		}

		private void JokersWildCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			//TODO: This will apply a flag that adds the Joker to the deck, and makes it lose to 2-6, beat 7-A.
		}
	}
}
