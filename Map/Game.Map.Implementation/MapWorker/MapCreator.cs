using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Interfaces;
using Game.Map.Interfaces.FieldWorker;
using Game.Map.Interfaces.Map;
using Game.Map.Interfaces.Map.Models;
using Game.Map.Interfaces.MapWorker;
using Game.Map.Interfaces.MapWorker.Models;

namespace Game.Map.Implementation.MapWorker
{
	public class MapCreator:IMapWorker
	{
		private IFieldWorker _fieldWorker;
		public MapCreator(IFieldWorker fieldWorker)
		{
			this._fieldWorker = fieldWorker;
		}

		void FillFields(IMap map)
		{
			var fields = map.Fields;

			for (int i = 0; i < map.Height; i++)
			{
				for (int j = 0; j < map.Width; j++)
				{
					fields[i, j] = _fieldWorker.CreateModel();
				}
			}
		}

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
			var map = new Map(param.Height, param.Width);

			FillFields(map);

			return map;
		}
	}
}
