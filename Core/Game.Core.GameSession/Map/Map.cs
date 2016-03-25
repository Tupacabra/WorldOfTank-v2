using Game.Core.GameManager.Interfaces.Map;
using Game.Core.GameManager.Interfaces.Map.Models;

namespace Game.Core.GameManager.Map
{
	class Map:IMap
	{

		public Map(int height, int width)
		{
			Height = height;
			Width = width;
			Fields = new IField[Height, Width];
			
		}

		public int MaxPlayers
		{
			get
			{
				var count = 0;
				foreach (var field in this.Fields)
				{
					if (field.IsMoveAble)
					{
						count++;
					}
				}
				return count;
			}
		}

		public int Height { get; private set; }
		public int Width { get; private set; }

		public IField[,] Fields
		{
			get;private set;
		}
	}
}
