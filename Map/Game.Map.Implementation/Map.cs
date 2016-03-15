using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Map.Interfaces;
using Game.Map.Interfaces.Map;
using Game.Map.Interfaces.Map.Models;

namespace Game.Map.Implementation
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

		public string Message()
		{
			return "VDV";
		}

		public IField[,] Fields
		{
			get;private set;
		}
	}
}
