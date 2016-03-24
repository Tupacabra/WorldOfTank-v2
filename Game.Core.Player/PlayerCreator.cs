using System;
using System.Collections.Generic;
using System.Linq;
using Game.Core.Interfaces.Location.Models;
using Game.Map.Interfaces.Map;
using Game.Player.Interfaces;

namespace Game.Core.Player
{
	public class PlayerCreator:IPlayerCreator
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
