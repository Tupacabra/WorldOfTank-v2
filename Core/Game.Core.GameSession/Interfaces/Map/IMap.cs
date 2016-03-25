using Game.Core.GameManager.Interfaces.Map.Models;

namespace Game.Core.GameManager.Interfaces.Map
{
	/// <summary>
	/// Main map item
	/// </summary>
	interface IMap
	{
		/// <summary>
		/// Get Fields
		/// </summary>
		IField[,] Fields { get; }
		int MaxPlayers { get; }
		int Height { get; }
		int Width { get;  }
	}
}
