using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Interfaces.Map;
using Game.Player.Interfaces;

namespace Game.Player.Implementation
{
	public class PlayerCreator:IPlayerCreator
	{
		public IEnumerable<IPlayer> CreatePlayers(IMap map, int playerNumber)
		{
			if (map.MaxPlayers < playerNumber)
			{
				throw new IndexOutOfRangeException("playerNumber");
			}
			Random r = new Random();
			List<IPlayer> players = new List<IPlayer>();

			for (int i = 0; i < playerNumber; i++)
			{
				var xPos = r.Next(map.Height);
				var yPos = r.Next(map.Width);
				while (!map.Fields[xPos, yPos].IsMoveAble && (!players.Any(n => n.XPosition == xPos && n.YPosition == yPos)))
				{
					xPos = r.Next(map.Height);
					yPos = r.Next(map.Width);
				}

				var newPlayer = new Player(i + 1)
				{
					XPosition = xPos,
					YPosition = yPos
				};

				players.Add(newPlayer);
			}
			return players;
		}
	}
}
