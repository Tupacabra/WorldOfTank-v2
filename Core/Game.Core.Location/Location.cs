using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Interfaces.Map;
using Game.Player.Interfaces;

namespace Game.Core.Location
{
	sealed class Location:Game.Core.Interfaces.Location.Models.Location
	{
		private IMap _map;
		private Player.Interfaces.IPlayer[] _players;
		public Location(IPlayer[] players, IMap map)
		{
			this._players = players;
			this._map = map;
		}

		public override IEnumerable<Field> GetFields(int x, int y)
		{
			return 

			throw new NotImplementedException();
		}
	}
}
