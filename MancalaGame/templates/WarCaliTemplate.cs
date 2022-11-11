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
            UpdateScore(player, board);
            return player;
        }

        if (EndPit.GetStoneAmount() == 1 && EndPit.GetOwner() == player.PlayerNumb) 
        {
            int oppositeStoneAmount = board.GetOppositePit(EndPit).GetStoneAmount();

            if (oppositeStoneAmount != 0)
            {
                board.GetHomePit(player.PlayerNumb).AddStones(oppositeStoneAmount);
                board.GetHomePit(player.PlayerNumb).AddStones(1);
                board.GetOppositePit(EndPit).EmptyPit();
                EndPit.EmptyPit();
            }
        }
 

        //This is the rule we made up. If the last stone ends in the pit it started from, the player may play again. 
        if (EndPit.Index == chosenPitNumber)
        {
            UpdateScore(player, board);
            return player;
        }

        //These are the rules of the Wari game.
        if (EndPit.GetOwner() == nextPlayer.PlayerNumb)
        {
            if (EndPit.GetStoneAmount() == 2 || EndPit.GetStoneAmount() == 3)
            {
                board.GetHomePit(player.PlayerNumb).AddStones(EndPit.GetStoneAmount());
                UpdateScore(player, board);
                EndPit.EmptyPit();
            }
        }

        UpdateScore(player, board);
        return nextPlayer;

    }

    private void UpdateScore(Player player, Board board)
    {
        player.score = board.GetHomePit(player.PlayerNumb).GetStoneAmount();
    }

}