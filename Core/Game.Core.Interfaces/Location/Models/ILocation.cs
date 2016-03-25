using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interfaces.Location.Models
{
	public interface ILocation
	{
		int Height { get;  }
		int Width { get;  }
		int PlayerCount { get; }
		void MovePlayer(int userIndex, MoveDirection direction);
		IEnumerable<Field> GetFields(int x, int y);
	}
	public class Field
	{
		public FieldType Type { get; set; }
	}

	public enum FieldType
	{
		Location,
		BlokedField,
		Player
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
