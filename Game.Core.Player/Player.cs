using Game.Player.Interfaces;

namespace Game.Core.Player
{
    public class Player: IPlayer
	{
	    public Player(int id)
	    {
		    Id = id;
	    }
		public int Id { get; private set; }

	    public int XPosition { get;  set; }

	    public int YPosition { get;  set; }
	    public void MoveTo(int x, int y)
		{
			XPosition = x;
			YPosition = y;
		}
	
}
}
