using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.GameSession.Models;
using Game.Core.Interfaces.Location;
using Game.Core.Interfaces.Location.Models;
using Game.Core.Interfaces.UI;

namespace Game.Core.GameSession
{
    public class GameSession:IGameSession
    {
	    private readonly IUIDrawing _ui;
	    private readonly ILocationManager _locationManager;

	    public GameSession(IUIDrawing ui, ILocationManager locationManager)
	    {
		    this._ui = ui;
		    this._locationManager = locationManager;
	    }

	    ILocation CreateLocation(NewGameParams param)
	    {
			var locationParam = new LocationParams()
			{
				Height = param.MapHeight,
				Width = param.MapWidth,
				PlayerNumber = param.PlayerNumber
			};

			return _locationManager.CreateLocation(locationParam);
		}
	    public ICurrentGame NewGame(NewGameParams param)
	    {
			var location = this.CreateLocation(param);

			var result = new CurrentGame(_ui, location);

		    return result;

	    }
    }
}
