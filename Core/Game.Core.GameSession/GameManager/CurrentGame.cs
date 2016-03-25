using System;
using System.Collections.Generic;
using Game.Core.GameManager.Interfaces;
using Game.Core.Interfaces.GameSession.Models;
using Game.Core.Interfaces.Location.Models;
using Game.Player.Interfaces;

namespace Game.Core.GameManager.GameManager
{
	class CurrentGame: ICurrentGame
	{
		private readonly IUIDrawing ui;
		private readonly ILocation location;
		public CurrentGame(IUIDrawing ui, ILocation location)
		{
			this.ui = ui;
			this.location = location;
		}

		public void Start()
		{
			ui.OnDraw += UiOnOnDraw;

			ui.DrawLocation(this.location);
		}

		private void UiOnOnDraw(object sender, MoveDirection direction)
		{
			int userIndex = Convert.ToInt32(sender);
			location.MovePlayer(userIndex, direction);
		}

		public void Pause()
		{
			throw new NotImplementedException();
		}

		public void Stop()
		{
			ui.OnDraw -= UiOnOnDraw;
		}

		public ILocation MapLocation
		{
			get { throw new NotImplementedException(); }
		}

		public IEnumerable<IPlayer> Players
		{
			get { throw new NotImplementedException(); }
		}
	}
}
