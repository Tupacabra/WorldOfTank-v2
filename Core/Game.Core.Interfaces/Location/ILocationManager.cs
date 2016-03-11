using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interfaces.Location
{
	public interface ILocationManager
	{
		Models.Location CreateLocation(Models.LocationParams param);
	}
}
