using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Implementation.MapWorker;
using Game.Map.Interfaces.FieldWorker;
using Game.Map.Interfaces.Map.Models;

namespace Game.Map.Implementation.FieldWorker
{
	public class FieldWorker: IFieldWorker
	{
		static Random randomKey = new Random();

		public IField CreateModel()
		{
			return new Field()
			{
				IsMoveAble = !Convert.ToBoolean(randomKey.Next(3)%2),
				SpeedModify = randomKey.NextDouble()
			};
		}
	}
}
