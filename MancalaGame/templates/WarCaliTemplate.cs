using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WarCaliTemplate :  GameTemplate
{

    public override Player MoveResult(Player player, Pit EndPit, int chosenPitNumber, GameSettings gameSettings)
    {
        Player nextPlayer = gameSettings.NextPlayer(player.PlayerNumb);

        //These are some of the rules of Mancala.
        if (EndPit.IsHomePit)
        {
            UpdateScore(player, gameSettings.GameBoard);
            return player;
        }

        if (EndPit.GetStoneAmount() == 1 && EndPit.GetOwner() == player.PlayerNumb) 
        {
            int oppositeStoneAmount = gameSettings.GameBoard.GetOppositePit(EndPit).GetStoneAmount();

            if (oppositeStoneAmount != 0)
            {
                gameSettings.GameBoard.GetHomePit(player.PlayerNumb).AddStones(oppositeStoneAmount);
                gameSettings.GameBoard.GetHomePit(player.PlayerNumb).AddStones(1);
                gameSettings.GameBoard.GetOppositePit(EndPit).EmptyPit();
                EndPit.EmptyPit();
            }
        }
 

        //This is the rule we made up. If the last stone ends in the pit it started from, the player may play again. 
        if (EndPit.Index == chosenPitNumber)
        {
            UpdateScore(player, gameSettings.GameBoard);
            return player;
        }

        //These are the rules of the Wari game.
        if (EndPit.GetOwner() == nextPlayer.PlayerNumb)
        {
            if (EndPit.GetStoneAmount() == 2 || EndPit.GetStoneAmount() == 3)   //3 might be a magic number, but its much simpler.
            {
                gameSettings.GameBoard.GetHomePit(player.PlayerNumb).AddStones(EndPit.GetStoneAmount());
                UpdateScore(player, gameSettings.GameBoard);
                EndPit.EmptyPit();
            }
        }

        UpdateScore(player, gameSettings.GameBoard);
        return nextPlayer;

    }

    private void UpdateScore(Player player, Board board)
    {
        player.score = board.GetHomePit(player.PlayerNumb).GetStoneAmount();
    }

}