using Game.Core.Interfaces.Location.Models;

namespace Game.Core.GameManager.Interfaces
{
	public interface ILocationManager
	{
		ILocation CreateLocation(LocationParams param);
	}
}
