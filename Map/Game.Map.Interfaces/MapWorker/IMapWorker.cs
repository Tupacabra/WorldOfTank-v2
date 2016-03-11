using Game.Map.Interfaces.Map;
using Game.Map.Interfaces.MapWorker.Models;

namespace Game.Map.Interfaces.MapWorker
{
	/// <summary>
	/// Main map worker
	/// </summary>
	public interface IMapWorker
	{
		/// <summary>
		/// Create map based on params
		/// </summary>
		/// <param name="param">create map params</param>
		/// <returns>New map</returns>
		IMap CreateMap(MapCreateRequest param);
	}
}
