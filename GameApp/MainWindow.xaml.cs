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
using Game.Core.GameManager.GameManager;
using Game.Core.GameManager.Interfaces;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.GameSession.Models;

namespace GameApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IGameManager _gameManager;
		public MainWindow()
		{
			IUIDrawing uiDrawing = new GameApp.Modules.UIDrawing();
			_gameManager =new GameManager(uiDrawing);
			InitializeComponent();
		}

		private void StartButtonClick(object sender, RoutedEventArgs e)
		{
			var param = new NewGameParams
			{
				MapHeight = int.Parse(MapHeight.Text),
				MapWidth = int.Parse(MapWidth.Text),
				PlayerNumber = 1
			};
			var game=_gameManager.NewGame(param);
			game.Start();
		}



		protected override void OnClosed(EventArgs e)
		{
			if (_gameManager != null)
			{
				_gameManager.Dispose();
			}
			base.OnClosed(e);
		}
	}
}
