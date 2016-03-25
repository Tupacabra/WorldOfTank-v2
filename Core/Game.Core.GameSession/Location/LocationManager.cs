using System;
using Game.Core.GameManager.Interfaces;
using Game.Core.GameManager.Interfaces.MapWorker;
using Game.Core.GameManager.Interfaces.MapWorker.Models;
using Game.Core.Interfaces.Location.Models;

namespace Game.Core.GameManager.Location
{
	class LocationManager: ILocationManager
	{
		private readonly IMapWorker _mapWorker;
		private readonly IPlayerCreator _playerCreator;

		public LocationManager(IMapWorker mapWorker, IPlayerCreator playerCreator)
		{
			_mapWorker = mapWorker;
			_playerCreator = playerCreator;
		}


		public Core.Interfaces.Location.Models.ILocation CreateLocation(LocationParams param)
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
