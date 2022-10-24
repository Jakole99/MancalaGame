using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mancala : Board
{ 
    
    public Mancala(int pits, int stones) : base(pits, stones)
    {
        FillBoard(stones);
    }

    public override void FillBoard(int stones)
    {
        foreach (Pit p in Pits)
        {
            if (!p.IsHomePit)
                p.AddStones(stones);
        }
    }
}
