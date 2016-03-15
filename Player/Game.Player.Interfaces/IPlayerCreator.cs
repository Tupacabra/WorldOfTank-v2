using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Interfaces.Map;

namespace Game.Player.Interfaces
{
	public interface IPlayerCreator
	{
		IEnumerable<IPlayer> CreatePlayers(IMap map, int playerNumber);
	}
}
