using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Map.Interfaces.MapWorker.Models
{
	/// <summary>
	/// Model for map cteating
	/// </summary>
	public class MapCreateRequest
	{
		public int Height { get; set; }
		public int Width { get; set; }
		public IEnumerable<string> Validate()
		{
			if (Height <= 0)
				yield return "Height is less than 0";

			if (Width <= 0)
				yield return "Width is less than 0";
		}
	}
}
