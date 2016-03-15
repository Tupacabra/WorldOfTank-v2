using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.Location;

namespace Game.Core.Interfaces.UI
{
	public interface IUIDrawing
	{
		void DrawLocation(Location.Models.ILocation location);
		event EventHandler<MoveDirection> OnDraw;
	}

	public enum MoveDirection
	{
		None,
		Top,
		Left,
		Right,
		Botton
	}
}
