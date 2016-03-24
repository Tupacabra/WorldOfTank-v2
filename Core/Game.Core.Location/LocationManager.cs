using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.Location;
using Game.Core.Interfaces.Location.Models;
using Game.Map.Interfaces.Map;
using Game.Map.Interfaces.MapWorker;
using Game.Map.Interfaces.MapWorker.Models;
using Game.Player.Interfaces;

namespace Game.Core.Location
{
	public class LocationManager: ILocationManager
	{
		private readonly IMapWorker _mapWorker;
		private readonly IPlayerCreator _playerCreator;

		public LocationManager(IMapWorker mapWorker, IPlayerCreator playerCreator)
		{
			_mapWorker = mapWorker;
			_playerCreator = playerCreator;
		}


		public Interfaces.Location.Models.ILocation CreateLocation(LocationParams param)
		{
			var mapParams = new MapCreateRequest() {Height = param.Height, Width = param.Width};
			var map = _mapWorker.CreateMap(mapParams);
			if (map.MaxPlayers < param.PlayerNumber)
			{
				throw new ArgumentException("PlayerNumber");
			}
			var players = _playerCreator.CreatePlayers(param.PlayerNumber);
			var location = new Location(map,players);
			return location;
		}
	}
}
