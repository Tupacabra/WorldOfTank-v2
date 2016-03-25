using System;
using Game.Core.GameManager.Interfaces;
using Game.Core.GameManager.Interfaces.FieldWorker;
using Game.Core.GameManager.Interfaces.MapWorker;
using Game.Core.GameManager.Location;
using Game.Core.GameManager.Map.FieldWorker;
using Game.Core.GameManager.Map.MapWorker;
using Game.Core.GameManager.Player;
using Game.Core.Player;
using LightInject;

namespace Game.Core.GameManager.GameManager
{
    class IoCContainer:IDisposable
    {
	    private readonly LightInject.ServiceContainer _container = new ServiceContainer();

	    public IoCContainer()
	    {
			_container.SetDefaultLifetime<PerContainerLifetime>();
			_container.Register<IFieldWorker, FieldWorker>();
			_container.Register<IMapWorker, MapCreator> ();
			_container.Register<ILocationManager, LocationManager>();
		    _container.Register<IPlayerCreator, PlayerCreator>();
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
