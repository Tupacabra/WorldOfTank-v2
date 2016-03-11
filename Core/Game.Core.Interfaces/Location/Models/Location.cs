using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interfaces.Location.Models
{
	public abstract class Location
	{
		public int Height { get; set; }
		public int Width { get; set; }

		public abstract IEnumerable<Location.Field> GetFields(int x, int y);

		public class Field
		{
			 public int Type { get; set; }
		}
	}
}
