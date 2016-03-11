using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Interfaces.Map.Models;

namespace Game.Map.Interfaces.FieldWorker
{
	public interface IFieldWorker
	{
		IField CreateModel();
	}
}
