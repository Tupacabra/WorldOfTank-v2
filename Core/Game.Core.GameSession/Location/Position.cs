using Game.Core.Interfaces.Location.Models;

namespace Game.Core.GameManager.Location
{
	sealed class Position:IPosition
	{
		public int X { get; set; }

		public int Y { get; set; }
	}
}
