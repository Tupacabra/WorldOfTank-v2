using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.GameSession.Models;

namespace Game.Core.Interfaces.GameSession
{
	/// <summary>
	/// Manager for game session
	/// </summary>
	public interface IGameManager:IDisposable
	{
		/// <summary>
		/// Create new game, base on params
		/// </summary>
		/// <param name="param">game params</param>
		/// <returns>new game session</returns>
		ICurrentGame NewGame(NewGameParams param);

		bool SaveGame(ICurrentGame currentGame);

		ICurrentGame LoadGame(int backupId);

		bool ExitGame(ICurrentGame currentGame);
	}
}
