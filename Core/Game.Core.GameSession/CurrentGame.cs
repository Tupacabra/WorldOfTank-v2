using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.GameSession.Models;
using Game.Core.Interfaces.Location.Models;
using Game.Core.Interfaces.UI;

namespace Game.Core.GameSession
{
	class CurrentGame: ICurrentGame
	{
		private readonly IUIDrawing ui;
		private readonly ILocation location;
		public CurrentGame(IUIDrawing ui, ILocation location)
		{
			this.ui = ui;
			this.location = location;
			ui.OnDraw += (sender, direction) =>
			{
				int userIndex = Convert.ToInt32(sender);
				location.MovePlayer(userIndex, direction);
			};
		}

		public void Start()
		{
			
			ui.DrawLocation(this.location);

		}
	}
}
