using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.Location.Models;

namespace Game.Core.Player
{
	internal class Position : IPosition
	{
		public int X { get; set; }

		public int Y { get; set; }
	}
}
