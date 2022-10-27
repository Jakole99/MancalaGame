using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class GameTemplate 
{ 

    public Player playGame(Board board, Player player)
    {
        // algoritme logica
        if (CheckEndCondition(board))
        {
            return GetWinner(board);
        }
        return playGame(board, MoveResult(board, player, DoTurn(board, player)));
    }

    public abstract Pit DoTurn(Board board, Player player);
    public abstract Player MoveResult(Board board, Player player, Pit EndPit);
    public abstract bool CheckEndCondition(Board board);
    public abstract Player GetWinner(Board board);
}