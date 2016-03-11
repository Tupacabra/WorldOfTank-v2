using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.Location;
using Game.Core.Interfaces.Location.Models;
using Game.Map.Interfaces.MapWorker;
using Game.Map.Interfaces.MapWorker.Models;

namespace Game.Core.Location
{
	public class LocationManager: ILocationManager
	{
		private readonly IMapWorker _mapWorker;

		public LocationManager(IMapWorker mapWorker)
		{
			_mapWorker = mapWorker;
		}

		public Interfaces.Location.Models.Location CreateLocation(LocationParams param)
		{
			var map = _mapWorker.CreateMap(new MapCreateRequest() {Height = param.Height, Width = param.Width});
			return new Location(null, map);
		}
	}
}
