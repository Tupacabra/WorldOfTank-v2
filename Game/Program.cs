using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.GameSession.Models;
using Game.Core.Interfaces.UI;
using Game.IoC;
using Game.IoC.Implementation;

namespace Game
{
	

	class Program
	{
		static void Main(string[] args)
		{
			var gameParams = new NewGameParams()
				{
					MapHeight = 10,
					MapWidth = 20,
					PlayerNumber = 2
				};
			using (var container = new IoCContainer())
			{

				var gameManager = container.GetService<IGameSession>();
				
				ICurrentGame game = gameManager.NewGame(gameParams);

				game.Start();

			}
		}
	}
}
