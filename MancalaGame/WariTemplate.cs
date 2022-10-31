using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class WariTemplate : GameTemplate
{

    public override Player MoveResult(Board board, Player player, Pit EndPit) 
    {
        Player nextPlayer = Game.gameSettings.NextPlayer(player.PlayerNumb);


        //Check if the last stone landed in an opponents Pit.
        if (EndPit.GetOwner() == nextPlayer.PlayerNumb)
        {
            //The last stone lands in a pit with 1 or 2 stones. So now the last Pit has has 2 or 3 stones in it.
            if (EndPit.GetStoneAmount() == 2 || EndPit.GetStoneAmount() == 3)
            {
                //Grab the stones, and put them in the HomePit of the player.
                board.GetHomePit(player.PlayerNumb).AddStones(EndPit.GetStoneAmount());
                EndPit.EmptyPit();
            }
        }
            //No matter what happens, it will be the opponents turn.
            return nextPlayer;
        
    }
}



