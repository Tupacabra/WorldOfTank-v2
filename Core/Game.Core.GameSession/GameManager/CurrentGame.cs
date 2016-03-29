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
		private readonly IUIDrawing _ui;
		private readonly ILocation _location;
		private int _currentStep = 10;
		private int _currentUserId = 0;

		public CurrentGame(IUIDrawing ui, ILocation location,int maxStep)
		{
			this._ui = ui;
			this._location = location;
			_currentStep = maxStep;
		}

		public void Start()
		{
			_ui.OnDraw += UiOnOnDraw;
			_ui.ClearMap();
			_ui.DrawLocation(this._location);
			_ui.ChangeStep(_currentStep);
		}


		private void UiOnOnDraw(object sender, MoveDirection direction)
		{
			if (_currentUserId >= _location.PlayerCount)
			{
				_currentUserId = 0;
				_currentStep--;
				_ui.ChangeStep(_currentStep);
				if (_currentStep <= 0)
				{
					Stop();
				}
			}
			_currentUserId++;

			_location.MovePlayer(_currentUserId, direction);
		}

		public void Pause()
		{
			throw new NotImplementedException();
		}

		public void Stop()
		{
			_ui.OnDraw -= UiOnOnDraw;
			_ui.ClearMap();
		}

		public ILocation MapLocation
		{
			get {return this._location; }
		}		
	}
}
