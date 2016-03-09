using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Interfaces;
using Game.Map.Interfaces.MapWorker;
using Game.Map.Interfaces.MapWorker.Models;

namespace Game.Map.Implementation.MapWorker
{
	public class MapCreator:IMapWorker
	{
		public IMap CreateMap(MapCreateRequest param)
		{
			if (param == null)
			{
				throw new ArgumentNullException("param");
			}
			if (param.Validate().Any())
			{
				throw new ArgumentOutOfRangeException("param");
			}

			return new Map();
		}
	}
}
