using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.GameSession;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.GameSession.Models;
using Game.Core.Interfaces.Location;
using Game.Core.Interfaces.Location.Models;
using Game.Core.Interfaces.UI;

namespace Game.Core.GameManager
{
    public class GameManager:IGameManager,IDisposable
    {
	    private IoCContainer _serviceContainer;
	   

	    public GameManager()
	    {
		    this._serviceContainer = new IoCContainer();
	    }

	    ILocation CreateLocation(NewGameParams param)
	    {
			var locationParam = new LocationParams()
			{
				Height = param.MapHeight,
				Width = param.MapWidth,
				PlayerNumber = param.PlayerNumber
			};

			return _serviceContainer.GetService<ILocationManager>().CreateLocation(locationParam);
		}
	    public ICurrentGame NewGame(NewGameParams param)
	    {
			var location = this.CreateLocation(param);
		    var ui = _serviceContainer.GetService<IUIDrawing>();
			var result = new CurrentGame(ui, location);

		    return result;

	    }

	    public bool SaveGame(ICurrentGame currentGame)
	    {
		    throw new NotImplementedException();
	    }

	    public ICurrentGame LoadGame(int backupId)
	    {
		    throw new NotImplementedException();
	    }

	    public bool ExitGame(ICurrentGame currentGame)
	    {
		    throw new NotImplementedException();
	    }

	    public void Dispose()
	    {
			_serviceContainer.Dispose();

		}
    }

}
