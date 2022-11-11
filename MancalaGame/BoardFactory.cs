using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoardFactory
{
    private readonly int standardPitAmountManacala = 8;
    private readonly int standardPitAmountWari = 6;
    private readonly int standardStoneAmount = 4;

    public Board GetCustomBoard(int pits, int stones, Game.Variant variant)
    {
        if (variant == Game.Variant.Mancala)
            return new Board(pits, stones, true);

        if (variant == Game.Variant.Wari)
            return new Board(pits, stones, false);

        if (variant == Game.Variant.WarCali)
            return new Board(pits, stones, true);
        return null;
    }

    public Board GetStandardBoard(Game.Variant variant)
    {
        if (variant == Game.Variant.Mancala)
            return new Board(standardPitAmountManacala, standardStoneAmount, true);
        if (variant == Game.Variant.Wari)
            return new Board(standardPitAmountWari, standardStoneAmount, false);
        if (variant == Game.Variant.WarCali)
            return new Board(standardPitAmountWari, standardStoneAmount,true);
        return null;
    }

}

