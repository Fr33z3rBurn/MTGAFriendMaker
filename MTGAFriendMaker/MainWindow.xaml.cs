using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace MTGAFriendMaker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void GetInfo_Click(object sender, RoutedEventArgs e)
		{
			var filePath = $"C:\\Users\\frees\\AppData\\LocalLow\\Wizards Of The Coast\\MTGA\\Player.log";

			string destinationFile = $"C:\\Users\\frees\\AppData\\LocalLow\\Wizards Of The Coast\\MTGA\\Player2.log";
			try
			{
				File.Copy(filePath, destinationFile, true);
			}
			catch (IOException iox)
			{
				Console.WriteLine(iox.Message);
			}

			List<string> opponents = new List<string>();

			foreach (var line in File.ReadAllLines(destinationFile))
			{
				if (line.Contains("playerName"))
				{
					var root = JsonSerializer.Deserialize<Root>(line);
					var opponent = root.matchGameRoomStateChangedEvent.gameRoomInfo.gameRoomConfig.reservedPlayers.FirstOrDefault(x => x.playerName != "BigFreeze#94052").playerName;
					opponents.Add(opponent);
				}
			}

			PlayerName.Content = opponents.Last();
			Clipboard.SetText(opponents.Last());
		}
	}
}
