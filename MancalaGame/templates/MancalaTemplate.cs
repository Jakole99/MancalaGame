using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MancalaTemplate : GameTemplate
{

    public override Player MoveResult(Board board, Player player, Pit EndPit, int chosenPitNumber, GameSettings gameSettings)
    {
        //We use the recursion rule of Mancala.
        EndPit = ContinueMove(board, player, EndPit);


        //Now we check what happens next, what is the result of that move which has been played.
        //Last Stone ends in Nyumba of the player. Player can play again.
        if (EndPit.IsHomePit)
        {
            UpdateScore(player, board);
            return player;
        }
        


        //Last Stone ends in an empty pit and it is the players pit.
        if (EndPit.GetStoneAmount() == 1 && EndPit.GetOwner() == player.PlayerNumb)  //The Last stone ended in here, that's why we check for == 1.
        {
            int oppositeStoneAmount = board.GetOppositePit(EndPit).GetStoneAmount();

            //Last Stone ends in an empty Pit of the player and the opposite pit of the opponent is not empty,
            //player grabs all stones from these two pits and collects them in their Nyumba.
            
            if (oppositeStoneAmount != 0)
            {
                board.GetOppositePit(EndPit).EmptyPit();

                board.GetHomePit(player.PlayerNumb).AddStones(oppositeStoneAmount);
                board.GetHomePit(player.PlayerNumb).AddStones(1);

                EndPit.EmptyPit();

            }

        }

        UpdateScore(player, board);
        return gameSettings.NextPlayer(player.PlayerNumb);      


    }

    private void UpdateScore(Player player, Board board)
    {
        player.score = board.GetHomePit(player.PlayerNumb).GetStoneAmount();
    }

    public Pit ContinueMove(Board board, Player player, Pit EndPit)
    {
        if (EndPit.GetStoneAmount() != 1 && !EndPit.IsHomePit)
        {
            return ContinueMove(board, player, board.MoveStones(EndPit.Index, player.PlayerNumb));
        }

        return EndPit;
    }
}