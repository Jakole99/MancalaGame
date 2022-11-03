using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoardFactory 
{ 

    public Board GetCustomBoard(int pits, int stones, Game.Variant variant)
    {
        if (variant == Game.Variant.Mancala)
            return new Board(pits, stones, true);

        else if (variant == Game.Variant.Wari)
            return new Board(pits, stones, false);

        else if (variant == Game.Variant.WarCali)
            return new Board(pits, stones, true);

        else 
            return null;
    }
    public Board GetStanderdBoard(Game.Variant variant)
    {
        if (variant == Game.Variant.Mancala)
            return new Board(8, 4, true);
        else if (variant == Game.Variant.Wari)
            return new Board(6, 4, false);
        else if (variant == Game.Variant.WarCali)
            return new Board(6, 4, true);
        else
            return null;
    }

}

