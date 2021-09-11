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
		const int SINGLE = 1;
		const int WAR = 4;
		static bool gameState = true;
		static Random random = new();

		public bool JokersAreWild;
		static List<Card> UnshuffledDeck = new();
		static List<Card> ShuffledDeck = new();
		static List<Card> PlayerOne = new();
		static List<Card> PlayerTwo = new();
		static List<Card> Pot = new();

		public MainWindow()
		{
			InitializeComponent();
			NumberOfGames.ItemsSource = Enumerable.Range(5, 96);
		}

		private static void CreateUnshuffledDeck(bool jokersAreWild)
		{
			for (int i = 2; i <= (int)Values.Ace; i++)
			{
				for (int j = 0; j <= (int)Suits.Clubs; j++)
				{
					Card card = new((Values)i, (Suits)j);
					UnshuffledDeck.Add(card);
				}
			}
			if (jokersAreWild)
			{
				Card joker1 = new(Values.Joker, Suits.Wild);
				Card joker2 = new(Values.Joker, Suits.Wild);
				UnshuffledDeck.Add(joker1);
				UnshuffledDeck.Add(joker2);
			}
		}
		private static void ShuffleTheUnshuffledDeck()
		{
			int deckSize = UnshuffledDeck.Count;
			for (int i = 0; i < deckSize; i++)
			{
				int index = random.Next(UnshuffledDeck.Count);

				ShuffledDeck.Add(UnshuffledDeck[index]);
				UnshuffledDeck.RemoveAt(index);
			}
		}
		private static void DealTheCardsToThePlayers()
		{
			int deckSize = ShuffledDeck.Count;
			for (int i = 0; i < deckSize; i++)
			{
				if (i % 2 == 0)
				{
					PlayerOne.Add(ShuffledDeck[i]);
				}
				else
				{
					PlayerTwo.Add(ShuffledDeck[i]);
				}
			}
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
			//TODO: Needs Simulation method created, and able to iterated x number of times and saved to a csv file for graphing.
			//TODO: CsvHelper @ https://https://joshclose.github.io/CsvHelper/getting-started/
			//TODO: Graphing @ https://https://github.com/Microsoft/InteractiveDataDisplay.WPF
			CreateUnshuffledDeck(JokersAreWild);
			ShuffleTheUnshuffledDeck();
			DealTheCardsToThePlayers();
		}

		private void JokersWildChecked(object sender, RoutedEventArgs e)
		{
			JokersAreWild = true;
		}

		private void JokersWildUnchecked(object sender, RoutedEventArgs e)
		{
			JokersAreWild = false;
		}
	}
}
