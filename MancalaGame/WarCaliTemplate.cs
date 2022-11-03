using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WarCaliTemplate :  GameTemplate
{
    public override Player MoveResult(Board board, Player player, Pit EndPit)
    {
        Player nextPlayer = Game.gameSettings.NextPlayer(player.PlayerNumb);

        //These are the rules of the Wari game.
        if (EndPit.GetOwner() == nextPlayer.PlayerNumb)
        {
            if (EndPit.GetStoneAmount() == 2 || EndPit.GetStoneAmount() == 3)
            {
                board.GetHomePit(player.PlayerNumb).AddStones(EndPit.GetStoneAmount());
                EndPit.EmptyPit();
            }
        }
        return nextPlayer;


        //These are some of the rules of Mancala.
        if (EndPit.IsHomePit)
        {
            return player;
        }


    }


}