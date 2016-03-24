using Game.Core.Interfaces.Location.Models;
using Game.Player.Interfaces;

namespace Game.Core.Player
{
    public class Player: IPlayer
	{
	    public Player(int playerId)
	    {
		    this.Id = playerId;
	    }

		public int Id { get; private set; }

		readonly Position _currentPosition =new Position();
		public IPosition CurentPosition
	    {
		    get { return _currentPosition; }
	    }

	    public void SetPosition(IPosition newPosition)
	    {
		    _currentPosition.X = newPosition.X;
			_currentPosition.Y = newPosition.Y;
		}
	}
}
