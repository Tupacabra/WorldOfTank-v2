using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.Location.Models;
using Game.Core.Interfaces.UI;
using Game.Map.Interfaces.Map;
using Game.Player.Interfaces;

namespace Game.Core.Location
{
	sealed class Location:ILocation
	{
		private readonly IMap _map;
		private readonly IEnumerable<IPlayer> _players;

		public Location(IEnumerable<IPlayer> players, IMap map)
		{
			this._players = players;
			this._map = map;
			this.Height = map.Height;
			this.Width = map.Width;
		}

		public int Height { get; private set; }

		public int Width { get; private set; }
		public int PlayerCount { get { return _players.Count(); } }
		public void MovePlayer(int userIndex, MoveDirection direction)
		{
			var user = _players.Skip(userIndex-1).FirstOrDefault();
			if (user != null)
			{
				int newXpos = user.XPosition,
					newYpos = user.YPosition;
				switch (direction)
				{
					case MoveDirection.Botton:
					{
							newXpos++;
						break;
					}
					case MoveDirection.Left:
					{
							newYpos--;
						break;
					}
					case MoveDirection.Right:
					{
							newYpos++;
						break;
					}
					case MoveDirection.Top:
					{
							newXpos--;
						break;
					}
					default:
					{
						return;
					}
				}
				if (newXpos >= 0 && newYpos >= 0 && newXpos < this.Width && newYpos < this.Width&&_map.Fields[newXpos, newYpos].IsMoveAble)
				{
					user.XPosition = newXpos;
					user.YPosition = newYpos;
				}

			}
			
		}

		public IEnumerable<Field> GetFields(int x, int y)
		{
			if (_map.Height>x&&_map.Width>y)
			{
				var field = this._map.Fields[x, y];
				yield return new Field() { Type = Convert.ToInt32(field.IsMoveAble), Label = field.IsMoveAble ?"+" : "-" };
				foreach (var player in this._players.Where(n => n.XPosition == x && n.YPosition == y).Select(n => new Field() { Type = 3 ,Label = n.Id.ToString()}))
				{
					yield return player;
				}
			}
		}

	}
}
