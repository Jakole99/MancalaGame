using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetOppositePitTest
{
    [Theory]
    [InlineData(8, true, 2, 4)]
    [InlineData(8, true, 4, 2)]
    [InlineData(8, false, 2, 5)]
    [InlineData(8, false, 5, 2)]
    [InlineData(6, true, 0, 4)]
    [InlineData(6, true, 4, 0)]
    [InlineData(6, false, 2, 3)]
    [InlineData(6, false, 3, 2)]
    public void GetOppositePitTest1(int pits, bool hasHomePit, int chosenIndex, int expectedOpposite)
    {
        //arrange
        Board board = new Board(pits, 4, hasHomePit);
        Pit expectedPit = board.Pits[expectedOpposite];

        //act
        Pit oppositPit = board.GetOppositePit(board.Pits[chosenIndex]);

        //assert
        Assert.Equal(expectedPit, oppositPit);
    }
}

