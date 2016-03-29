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
	interface IWindowObj
	{
		void Toogle(Visibility visibility);
		void ChangeStep(int value);
		event EventHandler<Key> OnDraw;
	}

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IWindowObj
	{
		private readonly IGameManager _gameManager;
		public MainWindow()
		{
			InitializeComponent();
			IUIDrawing uiDrawing = new GameApp.Modules.UIDrawing(Map,this);
			_gameManager =new GameManager(uiDrawing);
		}

		public void Toogle(Visibility visibility)
		{
			this.Dispatcher.InvokeAsync(() =>
			{
				MapHeight.Visibility = HeightLabel.Visibility = visibility;
				MapWidth.Visibility = WidthLabel.Visibility = visibility;
				MaxStepCount.Visibility = StepLabel.Visibility = visibility;
				StartButton.Visibility = visibility;
			});			
		}

		public void ChangeStep(int value)
		{
			StepState.Dispatcher.InvokeAsync(() =>
			{
				StepState.Content = value + " шагов";
			});
		}

		public event EventHandler<Key> OnDraw;

		private void StartButtonClick(object sender, RoutedEventArgs e)
		{
			var param = new NewGameParams
			{
				MapHeight = int.Parse(MapHeight.Text),
				MapWidth = int.Parse(MapWidth.Text),
				Steps= int.Parse(MaxStepCount.Text),
				PlayerNumber = 1
			};
			var game=_gameManager.NewGame(param);
			game.Start();
			Toogle(Visibility.Hidden);
		}



		protected override void OnClosed(EventArgs e)
		{
			if (_gameManager != null)
			{
				_gameManager.Dispose();
			}
			base.OnClosed(e);
		}



		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			this.OnDraw(sender, e.Key);
		}
	}
}
