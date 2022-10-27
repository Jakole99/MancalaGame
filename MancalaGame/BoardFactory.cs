using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoardFactory 
{ 

    public Board GetBoard(int pits, int stones, Game.Variant variant)
    {
        if (variant == Game.Variant.Mancala)
            return new MancalaBoard(pits, stones);
        else if (variant == Game.Variant.Wari)
            return new WariBoard(pits, stones);
        else return null;

    }


}

