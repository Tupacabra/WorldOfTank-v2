using System;
using Game.Core.GameManager.Interfaces.FieldWorker;
using Game.Core.GameManager.Interfaces.Map.Models;

namespace Game.Core.GameManager.Map.FieldWorker
{
	class FieldWorker: IFieldWorker
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
