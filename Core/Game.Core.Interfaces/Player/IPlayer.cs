using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player.Interfaces
{
	public interface IPlayer
	{
		int Id { get; }
		int XPosition { get; }
		int YPosition { get; }

		void MoveTo(int x, int y);
	}

}
