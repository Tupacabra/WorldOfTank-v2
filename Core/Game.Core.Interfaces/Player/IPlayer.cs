using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.Location.Models;

namespace Game.Player.Interfaces
{
	public interface IPlayer
	{
		int Id { get; }
		IPosition CurentPosition { get; }
		void SetPosition(IPosition newPosition);
	}

}
