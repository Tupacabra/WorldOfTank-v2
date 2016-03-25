using System;
using System.Linq;
using Game.Core.GameManager.Interfaces.FieldWorker;
using Game.Core.GameManager.Interfaces.Map;
using Game.Core.GameManager.Interfaces.MapWorker;
using Game.Core.GameManager.Interfaces.MapWorker.Models;

namespace Game.Core.GameManager.Map.MapWorker
{
	class MapCreator:IMapWorker
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
			var map = new Core.GameManager.Map.Map(param.Height, param.Width);

			FillFields(map);

			return map;
		}
	}
}
