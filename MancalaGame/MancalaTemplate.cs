using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MancalaTemplate : GameTemplate
{

    public override Player MoveResult(Board board, Player player, Pit EndPit)
    {
        //We use the recursion rule of mancala.
        EndPit = ContinueMove(board, player, EndPit);


        ///Now we check what happens next, what is the result of that move which has been played.
        ///Last Stone ends in Nyumba of the player. Player can play again.
        if (EndPit.IsHomePit)
        {
            player.score = board.GetHomePit(player.PlayerNumb).GetStoneAmount();
            return player;
        }
        


        ///Last Stone ends in an empty pit and Its the players pit
        if (EndPit.GetStoneAmount() == 1 && EndPit.GetOwner() == player.PlayerNumb)  //The Last stone ended in here, that's why we check for == 1.
        {
            int oppositeStoneAmount = board.GetOppositePit(EndPit).GetStoneAmount();

            ///Last Stone ends in an empty Pit of the player and the opposite pit of the opponent is not empty
            ///, player grabs all stones from these two pits and collects them in their Nyumba.
            ///
            if (oppositeStoneAmount != 0)
            {
                board.GetOppositePit(EndPit).EmptyPit();


                board.GetHomePit(player.PlayerNumb).AddStones(oppositeStoneAmount);
                board.GetHomePit(player.PlayerNumb).AddStones(1);

                EndPit.EmptyPit();

            }


            ///Last Stone ends in an empty Pit of the player and the opposite pit of the opponent is empty
            ///, next players turn.
            player.score = board.GetHomePit(player.PlayerNumb).GetStoneAmount();
            return Game.gameSettings.NextPlayer(player.PlayerNumb);

          
        }
        /// Its the opponents pit
        else
        {
            player.score = board.GetHomePit(player.PlayerNumb).GetStoneAmount();
            return Game.gameSettings.NextPlayer(player.PlayerNumb);      ///Last Stone ends in an empty Pit of the opponent. Next players turn.
        }


    }

    public Pit ContinueMove(Board board, Player player, Pit EndPit)
    {
        if (EndPit.GetStoneAmount() != 1 && !EndPit.IsHomePit)
        {
            return ContinueMove(board, player, board.MoveStones(EndPit.index, player.PlayerNumb));
        }

        return EndPit;
    }
}