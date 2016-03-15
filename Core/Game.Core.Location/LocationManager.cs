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

		public LocationManager(IMapWorker mapWorker)
		{
			_mapWorker = mapWorker;
		}


		IEnumerable<IPlayer> CreatePlayerList(IMap map,int playerNumber)
		{
			if (map.MaxPlayers < playerNumber)
			{
				throw new IndexOutOfRangeException("playerNumber");
			}
			Random r=new Random();
			List<IPlayer> players = new List<IPlayer>();
			
			for (int i = 0; i < playerNumber; i++)
			{
				var xPos = r.Next(map.Height);
				var yPos = r.Next(map.Width);
				while (!map.Fields[xPos,yPos].IsMoveAble&& (!players.Any(n=>n.XPosition==xPos&&n.YPosition==yPos)))
				{
					xPos = r.Next(map.Height);
					yPos = r.Next(map.Width);
				}

				var newPlayer = new Player()
				{
					Id = i+1,
					XPosition = xPos,
					YPosition = yPos
				};

				players.Add(newPlayer);
			}
			return players;
		} 
		public Interfaces.Location.Models.ILocation CreateLocation(LocationParams param)
		{
			var map = _mapWorker.CreateMap(new MapCreateRequest() {Height = param.Height, Width = param.Width});
			var players = CreatePlayerList(map,param.PlayerNumber);
			return new Location(players, map);
		}
	}
}
