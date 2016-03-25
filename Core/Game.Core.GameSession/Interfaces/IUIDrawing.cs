using System;
using Game.Core.Interfaces.Location.Models;

namespace Game.Core.GameManager.Interfaces
{
	public interface IUIDrawing
	{
		void DrawLocation(ILocation location);
		event EventHandler<MoveDirection> OnDraw;
	}
}
