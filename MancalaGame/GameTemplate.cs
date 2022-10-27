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
        DoTurn(board, player);
        if (CheckEndCondition(board))
        {
            return GetWinner(board);
        }
        return playGame(board, MoveResult(board, player));
    }

    public abstract void DoTurn(Board board, Player player);
    public abstract Player MoveResult(Board board, Player player);
    public abstract bool CheckEndCondition(Board board);
    public abstract Player GetWinner(Board board);
}