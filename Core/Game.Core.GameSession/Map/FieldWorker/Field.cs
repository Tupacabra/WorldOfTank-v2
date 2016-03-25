using Game.Core.GameManager.Interfaces.Map.Models;

namespace Game.Core.GameManager.Map.FieldWorker
{
	class Field : IField
	{
		public bool IsMoveAble { get; set; }

		public double SpeedModify
		{
			get; set;
		}
	}
}
