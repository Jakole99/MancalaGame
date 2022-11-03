﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class WariTemplate : GameTemplate
{

    public override Player MoveResult(Board board, Player player, Pit EndPit) 
    {
        Player nextPlayer = Game.gameSettings.NextPlayer(player.PlayerNumb);
        
        //These are the rules of the Wari game. Which will check if the last stone ended in an opponents pit with initially 1 or 2 stones.
        if (EndPit.GetOwner() == nextPlayer.PlayerNumb)
        {
            if (EndPit.GetStoneAmount() == 2 || EndPit.GetStoneAmount() == 3)
            {
                player.score += EndPit.GetStoneAmount();
                EndPit.EmptyPit();
            }
        }
            return nextPlayer;
    }
}



