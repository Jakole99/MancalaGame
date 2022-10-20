using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Board
{
    public Pit[] Pits;

    public Board(int size)
    {
        Pits = new Pit[size];
    }

    public abstract void FillBoard();

    public virtual void MakeBoard()
    {

    }
    public virtual void MoveStones()
    {

    }
    public virtual void DrawBoard()
    {

    }

} 
