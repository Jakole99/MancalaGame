using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class WariTemplate : GameTemplate
{

    public override Player MoveResult(Player player, Pit EndPit, int chosenNumber, GameSettings gameSettings) 
    {
        Player nextPlayer = gameSettings.NextPlayer(player.PlayerNumb);
        
        //These are the rules of the Wari game. Which will check if the last stone ended in an opponents pit with initially 1 or 2 stones.
        if (EndPit.GetOwner() == nextPlayer.PlayerNumb)
        {
            if (EndPit.GetStoneAmount() == 2 || EndPit.GetStoneAmount() == 3) //3 might be a magic number, but its much simpler.
            {
                player.score += EndPit.GetStoneAmount();
                EndPit.EmptyPit();
            }
        } 
        return nextPlayer;
    }
}



