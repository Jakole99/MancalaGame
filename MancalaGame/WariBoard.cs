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

    public override Pit MoveStones(int startIndex, Player.Numb player)
    {
        int stoneValue;

        stoneValue = Pits[startIndex].GetStoneAmount();
        Pits[startIndex].EmptyPit();

        int currentIndex = 0;
        for (int i = startIndex + 1; i < stoneValue + startIndex + 1; i++)
        {
            currentIndex = i % Pits.Length;

            if (Pits[currentIndex].IsHomePit)
            {
                stoneValue += 1;
                continue;
            }
            Pits[currentIndex].AddStones(1);
        }

        return Pits[currentIndex];
    }

}

