using System;
using Game.Core.GameManager.Interfaces;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.GameSession.Models;
using Game.Core.Interfaces.Location.Models;

namespace Game.Core.GameManager.GameManager
{
    public class GameManager:IGameManager
    {
	    private readonly IoCContainer _serviceContainer;
	    private readonly IUIDrawing _currentUI;

	    public GameManager(IUIDrawing currentUi)
	    {
		    _currentUI = currentUi;
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
			return new CurrentGame(_currentUI, location, param.Steps);

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
