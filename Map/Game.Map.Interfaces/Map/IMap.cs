using Game.Map.Interfaces.Map.Models;

namespace Game.Map.Interfaces.Map
{
	/// <summary>
	/// Main map item
	/// </summary>
	public interface IMap
	{
		/// <summary>
		/// Return temp message
		/// </summary>
		/// <returns>mesage</returns>
		string Message();
		/// <summary>
		/// Get Fields
		/// </summary>
		IField[,] Fields { get; }
		int Height { get; }
		int Width { get;  }
	}
}
