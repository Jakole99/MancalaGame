using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WarCaliTemplate :  GameTemplate
{
    public override Player MoveResult(Board board, Player player, Pit EndPit, int chosenPitNumber)
    {
        Player nextPlayer = Game.gameSettings.NextPlayer(player.PlayerNumb);

        //These are some of the rules of Mancala.
        if (EndPit.IsHomePit)
        {
            player.score += 1;
            return player;
        }

        //Last Stone ends in an empty pit of the player, it check if the opposite pit of the opponent is empty or not.
        if (EndPit.GetStoneAmount() == 1 && EndPit.GetOwner() == player.PlayerNumb)  //The Last stone ended in here, that's why we check for == 1.
        {
            int oppositeStoneAmount = board.GetOppositePit(EndPit).GetStoneAmount();

            if (oppositeStoneAmount != 0)
            {
                player.score += oppositeStoneAmount + 1;
                board.GetOppositePit(EndPit).EmptyPit();
                EndPit.EmptyPit();
            }
        }
 

        //This is the rule we made up. If the last stone ends in the pit it started from, the player may play again. 
        if (EndPit.index == chosenPitNumber)
        {
            return player;
        }

        //These are the rules of the Wari game.
        if (EndPit.GetOwner() == nextPlayer.PlayerNumb)
        {
            if (EndPit.GetStoneAmount() == 2 || EndPit.GetStoneAmount() == 3)
            {
                player.score = +EndPit.GetStoneAmount();
                EndPit.EmptyPit();
            }
        }

        return nextPlayer;

    }


}