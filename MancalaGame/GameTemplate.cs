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
        // MoveResult();
        // CheckEndCondition();
        // GetWinner();
        return null;
    }

    public abstract Player MoveResult(Board board, Player player);
    public abstract bool CheckEndCondition(Board board);
    public abstract Player GetWinner(Board board);
}