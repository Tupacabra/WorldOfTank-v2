using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Map.Implementation.MapWorker;
using Game.Map.Interfaces.MapWorker;
using LightInject;

namespace Game.IoC.Implementation
{
    public class IoCContainer : IIoCContainer
    {
	    private readonly LightInject.ServiceContainer _container = new ServiceContainer();

	    public IoCContainer()
	    {
			_container.Register<IMapWorker, MapCreator> ();

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
