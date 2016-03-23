using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.GameManager;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.GameSession.Models;

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
					PlayerNumber = 1
				};
			using (IGameManager gameManager = new GameManager())
			{
				ICurrentGame game = gameManager.NewGame(gameParams);
				game.Start();

			}
		}
	}
}
//1. Init GameParams
//2. GameManager
// - NewGame
// - SaveGame
// - LoadGame
// - ExitGame
//3. GameType -> GameParams

//4. Game
// - Start
// - Stop
// - Pause
// - MapStructure
// - Player[]

// Player

// Location
// - MovePlayer(Left)
