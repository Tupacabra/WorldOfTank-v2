using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.GameSession;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.Location;
using Game.Core.Interfaces.UI;
using Game.Core.Location;
using Game.Core.UI;
using Game.Map.Implementation.FieldWorker;
using Game.Map.Implementation.MapWorker;
using Game.Map.Interfaces.FieldWorker;
using Game.Map.Interfaces.MapWorker;
using LightInject;

namespace Game.IoC.Implementation
{
    public class IoCContainer : IIoCContainer
    {
	    private readonly LightInject.ServiceContainer _container = new ServiceContainer();

	    public IoCContainer()
	    {
			_container.Register<IFieldWorker, FieldWorker>();
			_container.Register<IMapWorker, MapCreator> ();
			_container.Register<ILocationManager, LocationManager>();
		    _container.Register<Player.Interfaces.IPlayerCreator, Player.Implementation.PlayerCreator>();
			_container.Register<IGameSession, GameSession>();
			_container.Register<IUIDrawing, UIDrawing>();
		}

	    public T GetService<T>()
	    {
		    return _container.GetInstance<T>();
	    }

	    public IDisposable CreateScope()
	    {
		    return _container.BeginScope();
	    }

		public void Dispose()
	    {
			_container.Dispose();
		}
	}
}
