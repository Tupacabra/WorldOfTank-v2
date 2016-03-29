using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.Location.Models;
using Game.Player.Interfaces;

namespace Game.Core.Interfaces.GameSession.Models
{
	public interface ICurrentGame
	{
		void Start();
		void Pause();
		void Stop();
		ILocation MapLocation { get; }		
	}
	
}
