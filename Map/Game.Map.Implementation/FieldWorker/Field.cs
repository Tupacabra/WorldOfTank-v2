using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Interfaces.Map.Models;

namespace Game.Map.Implementation.FieldWorker
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
