using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Interfaces.GameSession;
using Game.Core.Interfaces.GameSession.Models;

namespace Game.Core.GameSession
{
    public class GameSession:IGameSession
    {
		
	    public ICurrentGame NewGame(NewGameParams param)
	    {
		    throw new NotImplementedException();
	    }
    }
}
