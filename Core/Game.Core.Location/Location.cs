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
		private readonly IMap _map;
		private readonly IPlayer[] _players;
		public Location(IPlayer[] players, IMap map)
		{
			this._players = players;
			this._map = map;
		}
		public override IEnumerable<Location.Field> GetFields(int x, int y)
		{
			if (_map.Height>x&&_map.Width>y)
			{
				var field = this._map.Fields[x, y];
				yield return new Field() { Type = Convert.ToInt32(field.IsMoveAble) };
				foreach (var player in this._players.Where(n => n.XPosition == x && n.YPosition == y).Select(n => new Field() { Type = 3 }))
				{
					yield return player;
				}
			}
		}

	}
}
