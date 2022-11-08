
public class MoveStonesTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    public void MoveStonesTest1(int i)
    {
        //arrange
        Board board = new Board(8, 4, true);
        int[] testboard = new int[] { 4, 4, 0, 1, 5, 5, 5, 0 };

        //act
        board.MoveStones(2, Player.Numb.P1);

        //assert
        Assert.Equal(board.Pits[i].GetStoneAmount(), testboard[i]);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    public void MoveStonesTest2(int i)
    {
        //arrange
        Board board = new Board(8, 4, false);
        int[] testboard = new int[] { 4, 4, 0, 5, 5, 5, 5, 4 };

        //act
        board.MoveStones(2, Player.Numb.P1);

        //assert
        Assert.Equal(board.Pits[i].GetStoneAmount(), testboard[i]);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    public void MoveStonesTest3(int i)
    {
        //arrange
        Board board = new Board(8, 18, true);
        int[] testboard = new int[] { 2, 21, 21, 3, 21, 20, 20, 0 };

        //act
        board.MoveStones(0, Player.Numb.P1);

        //assert
        Assert.Equal(board.Pits[i].GetStoneAmount(), testboard[i]);
    }
}

public class GetOppositeTest
{
    [Fact]
    public void getOppositeTest1()
    {
        //arrange
        Board board = new Board(8, 4, true);
        Pit expectedPit = board.Pits[4];

        //act
        Pit oppositPit = board.GetOppositePit(board.Pits[2]);

        //assert
        Assert.Equal(expectedPit, oppositPit);
    }

    [Fact]
    public void getOppositeTest2()
    {
        //arrange
        Board board = new Board(4, 0, true);
        Pit expectedPit = board.Pits[0];

        //act
        Pit oppositPit = board.GetOppositePit(board.Pits[2]);

        //assert
        Assert.Equal(expectedPit, oppositPit);
    }

    [Fact]
    public void getOppositeTest3()
    {
        //arrange
        Board board = new Board(8, 4, false);
        Pit expectedPit = board.Pits[4];

        //act
        Pit oppositPit = board.GetOppositePit(board.Pits[3]);

        //assert
        Assert.Equal(expectedPit, oppositPit);
    }

    [Fact]
    public void getOppositeTest4()
    {
        //arrange
        Board board = new Board(8, 4, false);
        Pit expectedPit = board.Pits[0];

        //act
        Pit oppositPit = board.GetOppositePit(board.Pits[7]);

        //assert
        Assert.Equal(expectedPit, oppositPit);
    }
}

