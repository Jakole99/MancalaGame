using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WariBoard : Board
{
    public WariBoard(int pits, int stones) : base(pits, stones)
    {

    }

    public override void MoveStones(int numb, Player.Numb player)
    {
        int stoneValue;
        int startingIndex;

        if (player == Player.Numb.P1)
        {
            startingIndex = numb;
        }
        else if (player == Player.Numb.P2)
        {
            startingIndex = numb + Pits.Length / 2;
        }
        else
            return;

        stoneValue = Pits[startingIndex - 1].GetStoneAmount();
        Pits[startingIndex - 1].EmptyPit();

        int currentIndex;
        for (int i = startingIndex; i < stoneValue + startingIndex; i++)
        {
            currentIndex = i % Pits.Length;

            if (Pits[currentIndex].IsHomePit)
            {
                stoneValue += 1;
                continue;
            }
            Pits[currentIndex].AddStones(1);
        }
    }

    public override Pit GetLastMovePit(int numb, Player.Numb player)
    {
        int stoneValue;
        int startingIndex;

        if (player == Player.Numb.P1)
        {
            startingIndex = numb;
        }
        else if (player == Player.Numb.P2)
        {
            startingIndex = numb + Pits.Length / 2;
        }
        else
            return null;

        stoneValue = Pits[startingIndex - 1].GetStoneAmount();

        int currentIndex = 0;
        for (int i = startingIndex; i < stoneValue + startingIndex; i++)
        {
            currentIndex = i % Pits.Length;
            if (Pits[currentIndex].IsHomePit)
            {
                stoneValue += 1;
                continue;
            }
        }
        return Pits[currentIndex];
    }
}

