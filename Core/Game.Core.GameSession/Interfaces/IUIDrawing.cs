using System;
using Game.Core.Interfaces.Location.Models;

namespace Game.Core.GameManager.Interfaces
{
	public interface IUIDrawing
	{
		void ClearMap();
		void DrawLocation(ILocation location);
		void ChangeStep(int newValue);
		event EventHandler<MoveDirection> OnDraw;
	}
}
