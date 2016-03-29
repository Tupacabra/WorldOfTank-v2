using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interfaces.GameSession.Models
{
	public class NewGameParams
	{
		public int MapHeight { get; set; }
		public int MapWidth { get; set; }
		public int Steps { get; set; }
		public int PlayerNumber { get; set; }
	}
}
