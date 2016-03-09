using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.IoC;
using Game.IoC.Implementation;
using Game.Map.Interfaces;
using Game.Map.Interfaces.MapWorker;
using Game.Map.Interfaces.MapWorker.Models;

namespace Game
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var container = new IoCContainer())
			{

				var map = container.GetService<IMapWorker>();

				Console.WriteLine(map.CreateMap(new MapCreateRequest() {Height = 10,Width = 10}).Message());

			}
		}
	}
}
