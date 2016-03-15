using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Player.Interfaces;

namespace Game.Core.Location
{
	class Player:IPlayer
	{
		public int Id { get; set; }

		public int XPosition
		{
			get; set;
		}

		public int YPosition
		{
			get; set;
		}
	}
}
