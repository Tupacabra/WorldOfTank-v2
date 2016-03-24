using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.UI;

namespace Game.Core.UI
{

	public class UIDrawing : IUIDrawing
	{
		object objectLock = new Object();

		public UIDrawing()
		{
			Console.WriteLine("Click for start...");

		}
		public void DrawLocation(Game.Core.Interfaces.Location.Models.ILocation location)
		{
			Draw(0,location,MoveDirection.None);
			ConsoleKeyInfo info = Console.ReadKey();
			while (info.Key != ConsoleKey.Escape)
			{
				for (int playerIndex = 1; playerIndex <= location.PlayerCount; playerIndex++)
				{
					var direction = getMoveDirection(info.Key);
					Console.WriteLine("Pressed: " + info.Key + ", Move Direction: " + direction);
					Draw(playerIndex,location, direction);//event
					info = Console.ReadKey();
				}

			}
		}

		private MoveDirection getMoveDirection(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.LeftArrow:
				{
					return MoveDirection.Left;
				}
				case ConsoleKey.RightArrow:
				{
					return MoveDirection.Right;

				}
				case ConsoleKey.UpArrow:
				{
					return MoveDirection.Top;
				}
				case ConsoleKey.DownArrow:
				{
					return MoveDirection.Botton;
				}
				default:
				{
					return MoveDirection.None;
				}
			}
		}

		event EventHandler<MoveDirection>  OnDrawHandler;


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
		
 
		void Draw(int playerIndex,Game.Core.Interfaces.Location.Models.ILocation location, MoveDirection direction)
		{
			Console.Clear();

			// Raise IDrawingObject's event before the object is drawn.
			var handler = OnDrawHandler;
			if (handler != null && playerIndex > 0)
			{
				//direction
				handler(playerIndex, direction);
				Console.WriteLine("Player moved " + playerIndex.ToString());
			}
			else
			{
				Console.WriteLine("Press any key to start");

			}
			for (int i = 0; i < location.Height; i++)
			{
				for (int j = 0; j < location.Width; j++)
				{
					var layouts = location.GetFields(i, j).ToArray();
					Console.Write(" | "+(int)layouts.Last().Type);
					
				}
				Console.WriteLine(" |");
			}
			
			
		}
	}
}
