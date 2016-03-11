using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.GameSession.Models;
using Game.IoC;
using Game.IoC.Implementation;

namespace Game
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var container = new IoCContainer())
			{

				var gameManager = container.GetService<IGameSession>();
				var game = gameManager.NewGame(new NewGameParams()
				{
					MapHeight = 10,
					MapWidth = 10,
					PlayerNumber = 1
				});
				

				for (int i = 0; i < map.Height; i++)
				{
					for (int j = 0; j < map.Width; j++)
					{
						Console.Write(" | "+(map.Fields[i,j].IsMoveAble ?"+" :"-"));
					}
					Console.WriteLine(" |");
				}
				ConsoleKeyInfo info = Console.ReadKey();
				while (info.Key != ConsoleKey.Escape )
				{
					Console.Write(info.Key);


					info = Console.ReadKey();
				}
				

			}
		}
	}
}
