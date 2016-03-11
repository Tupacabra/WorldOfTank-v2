using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Map.Interfaces.Map.Models
{
	public interface IField
	{
		bool IsMoveAble { get; }
		double SpeedModify { get; }
	}
}
