using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.IoC
{
	/// <summary>
	/// IoC Container for game
	/// </summary>
	public interface IIoCContainer: IDisposable
	{
		/// <summary>
		/// Get instance for service
		/// </summary>
		/// <typeparam name="T">type of interface</typeparam>
		/// <returns>instance</returns>
		T GetService<T>();

		/// <summary>
		/// create scope of container
		/// </summary>
		/// <returns></returns>
		IDisposable CreateScope();
	}
}
