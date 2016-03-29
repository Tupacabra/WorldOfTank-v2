using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Game.Core.GameManager.Interfaces;
using Game.Core.Interfaces.Location.Models;

namespace GameApp.Modules
{
	class UIDrawing:IUIDrawing
	{
		object objectLock = new Object();

		private Panel _panel;
		private Dictionary<string, Zone> fieldLocation=new Dictionary<string, Zone>();
		private IWindowObj _windowObj;
		private ILocation _currentLocation;

		public UIDrawing(Panel panel, IWindowObj windowObj)
		{
			this._panel = panel;
			_windowObj = windowObj;
			_windowObj.OnDraw += (sender, args) =>
			{
				if (_currentLocation == null)
				{
					return;
				}
				var direction = getMoveDirection(args);
				if (OnDrawHandler != null)
				{
					this.OnDrawHandler(_currentLocation, direction);
				}
				Refresh();//event
			};
		}

		public void ClearMap()
		{
			Task.Factory.StartNew(() =>
			{
				lock (objectLock)
				{
					_currentLocation = null;
					fieldLocation.Clear();
					_panel.Dispatcher.Invoke(() =>
					{
						if (_panel.Children != null)
						{
							_panel.Children.Clear();
						}
						_windowObj.Toogle(Visibility.Visible);
					});
				}
			});
				
		}


		public void DrawLocation(ILocation location)
		{
			Task.Factory.StartNew(() =>
			{
				lock (objectLock)
				{
					_currentLocation = location;
					_windowObj.Toogle(Visibility.Hidden);
					Draw();
				}
			});
		}

		public void ChangeStep(int newValue)
		{
			Task.Factory.StartNew(() =>
			{
				lock (objectLock)
				{
					_windowObj.ChangeStep(newValue);
				}
			});
		}

		private MoveDirection getMoveDirection(Key key)
		{
			switch (key)
			{
				case Key.Left:
					{
						return MoveDirection.Left;
					}
				case Key.Right:
					{
						return MoveDirection.Right;

					}
				case Key.Up:
					{
						return MoveDirection.Top;
					}
				case Key.Down:
					{
						return MoveDirection.Botton;
					}
				default:
					{
						return MoveDirection.None;
					}
			}
		}

		event EventHandler<MoveDirection> OnDrawHandler;


		// Explicit interface implementation required.
		// Associate IDrawingObject's event with
		// PreDrawEvent
		public event EventHandler<MoveDirection> OnDraw
		{
			add
			{
				lock (objectLock)
				{
					OnDrawHandler += value;
				}
			}
			remove
			{
				lock (objectLock)
				{
					OnDrawHandler -= value;
				}
			}
		}

		Color GetColor(FieldType type)
		{
			return type == FieldType.Player
				? Colors.Crimson
				: (type == FieldType.Location
					? Colors.Green
					: Colors.DarkOrange);
		}

		void Draw()
		{
			lock (objectLock)
			{
				for (int i = 0; i < _currentLocation.Height; i++)
				{
					for (int j = 0; j < _currentLocation.Width; j++)
					{
						var layouts = _currentLocation.GetFields(i, j).ToArray();

						FieldType type = layouts.Last().Type;
						
						_panel.Dispatcher.Invoke(() => {
							var temp = new Rectangle()
							{
								Width = 30,
								Height = 30,
								Fill = new SolidColorBrush(this.GetColor(type)),
								Margin = new Thickness(j * 30, i * 30, 0, 0)
							};

							fieldLocation.Add(i + "_" + j, new Zone() { Rectangle = temp, Type = type });

							_panel.Children.Add(temp);

						});
					}
				}
			}
			
		}

		private void Refresh()
		{
			lock (objectLock)
			{
				if (_currentLocation == null)
				{
					return;
				}
				for (int i = 0; i < _currentLocation.Height; i++)
				{
					for (int j = 0; j < _currentLocation.Width; j++)
					{
						var layouts = _currentLocation.GetFields(i, j).ToArray();
						FieldType type = layouts.Last().Type;
						var zone = fieldLocation[i + "_" + j];
						if (zone.Type != type)
						{
							zone.Type = type;
							zone.Rectangle.Dispatcher.InvokeAsync(() =>
							{
								zone.Rectangle.Fill = new SolidColorBrush(this.GetColor(type));
							});

						}
					}
				}
			}
		}

		class Zone
		{
			public FieldType Type { get; set; }
			public Rectangle Rectangle { get; set; }
		}
	}
}
