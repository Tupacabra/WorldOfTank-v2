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
		private IEnumerable<IPlayer> _players;
		private static Random r=new Random();

		void SetPlayersPosiotion(IMap map, IEnumerable<IPlayer> players)
		{
			foreach (var player in players)
			{
				var xPos = r.Next(map.Height);
				var yPos = r.Next(map.Width);

				while (map.Fields[xPos, yPos].IsMoveAble &&
						(!players.Any(n => n.CurentPosition.X == xPos && n.CurentPosition.Y == yPos))
					)
				{
					xPos = r.Next(map.Height);
					yPos = r.Next(map.Width);
				}
				var newPosition = new Position() {X = xPos, Y = yPos};
				player.SetPosition(newPosition);
			}
		}

		public Location(IMap map,IEnumerable<IPlayer> players)
		{
			this._map = map;
			_players = players;
			SetPlayersPosiotion(map, _players);
		}




		public int Height { get { return _map.Height; } }

		public int Width { get { return _map.Width; } }
		public int PlayerCount { get { return _players.Count(); } }

		public void MovePlayer(int userIndex, MoveDirection direction)
		{
			var user = _players.Skip(userIndex-1).FirstOrDefault();
			if (user != null)
			{
				var newPosition = new Position()
				{
					X = user.CurentPosition.X,
					Y = user.CurentPosition.Y
				};
				
				switch (direction)
				{
					case MoveDirection.Botton:
					{
						newPosition.X++;
						break;
					}
					case MoveDirection.Left:
					{
							newPosition.Y--;
						break;
					}
					case MoveDirection.Right:
					{
							newPosition.Y++;
							break;
					}
					case MoveDirection.Top:
					{
							newPosition.X--;
							break;
					}
					default:
					{
						return;
					}
				}
				if (this.TryMove(newPosition))
				{
					user.SetPosition(newPosition);
				}
			}
		}

		bool TryMove(IPosition newPosition)
		{
			var isInRange = newPosition.X >= 0 && newPosition.Y >= 0 && newPosition.X < this.Height && newPosition.Y < this.Width;

			return isInRange &&
			       _map.Fields[newPosition.X, newPosition.Y].IsMoveAble;
			
		}

		public IEnumerable<Field> GetFields(int x, int y)
		{
			if (_map.Height <= x || _map.Width <= y) yield break;
			var map = this._map.Fields[x, y];

			yield return new Field()
			{
				Type = map.IsMoveAble
					? FieldType.Location
					: FieldType.BlokedField
			};

			foreach (
				var playerField in
					this._players.Where(n => n.CurentPosition.X == x && n.CurentPosition.Y == y).Select(n => new Field() {Type = FieldType.Player}))

			{
				yield return playerField;
			}
		}

	}
}
