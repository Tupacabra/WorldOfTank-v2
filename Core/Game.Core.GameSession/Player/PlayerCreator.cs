using System.Collections.Generic;
using Game.Core.GameManager.Interfaces;
using Game.Player.Interfaces;

namespace Game.Core.GameManager.Player
{
	class PlayerCreator:IPlayerCreator
	{

		public IEnumerable<IPlayer> CreatePlayers(int playerNumber)
		{
			var players = new List<IPlayer>();

			for (var i = 0; i < playerNumber; i++)
			{
				var newPlayer = new Core.Player.Player(i + 1);
				players.Add(newPlayer);
			}
			return players;
		}
	}
}
