using Game.Core.GameManager.Interfaces.Map;
using Game.Core.GameManager.Interfaces.MapWorker.Models;

namespace Game.Core.GameManager.Interfaces.MapWorker
{
	/// <summary>
	/// Main map worker
	/// </summary>
	interface IMapWorker
	{
		/// <summary>
		/// Create map based on params
		/// </summary>
		/// <param name="param">create map params</param>
		/// <returns>New map</returns>
		IMap CreateMap(MapCreateRequest param);
	}
}
