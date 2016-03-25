using System.Collections.Generic;
using Game.Player.Interfaces;

namespace Game.Core.GameManager.Interfaces
{
	public interface IPlayerCreator
	{
		IEnumerable<IPlayer> CreatePlayers(int playerNumber);
	}
}
