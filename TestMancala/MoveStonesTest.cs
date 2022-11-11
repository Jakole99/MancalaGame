
public class MoveStonesTest
{
    [Theory]
    [InlineData(8, 4, true, 2, Player.Numb.P1, new int[] { 4, 4, 0, 1, 5, 5, 5, 0 })]
    [InlineData(8, 4, false, 2, Player.Numb.P1, new int[] { 4, 4, 0, 5, 5, 5, 5, 4 })]
    [InlineData(8, 18, true, 0, Player.Numb.P1, new int[] { 2, 21, 21, 3, 21, 20, 20, 0 })]
    [InlineData(8, 18, true, 4, Player.Numb.P2, new int[] { 21, 20, 20, 0, 2, 21, 21, 3 })]
    [InlineData(8, 18, false, 0, Player.Numb.P1, new int[] {2, 21, 21, 20, 20, 20, 20, 20})]
    [InlineData(4, 1, true, 0, Player.Numb.P1, new int[] {0, 1, 1, 0})]
    [InlineData(4, 1, true, 2, Player.Numb.P2, new int[] {1,0,0,1})]

    public void MoveStonesTest1(int pits, int stones, bool hasHomePit, int moveFrom, Player.Numb playerNumb, int[] expectedanswer)
    {
        
        //arrange
        Board board = new Board(pits, stones, hasHomePit);
        int[] expectedAnswer = expectedanswer;
        int[] intBoard;

        //act
        board.MoveStones(moveFrom, playerNumb);
        intBoard = Array.ConvertAll(board.Pits, Pit => Pit.GetStoneAmount());

        //assert
        Assert.Equal(intBoard, expectedAnswer);
    }
}

public class GetOppositeTest
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
    public void getOppositeTest1(int pits, bool hasHomePit, int chosenIndex, int excpectedOpposite)
    {
        //arrange
        Board board = new Board(pits, 4, hasHomePit);
        Pit expectedPit = board.Pits[excpectedOpposite];

        //act
        Pit oppositPit = board.GetOppositePit(board.Pits[chosenIndex]);

        //assert
        Assert.Equal(oppositPit, expectedPit);
    }
}

public class DrawBoardTest
{
    [Theory]
    [InlineData(0, "0:    ")]
    public void DawBoardTest(int number, string expectedString)
    {
        //arrange 
        Board board = new Board(2, 3, true);

        //act
        TextWriter t = new StringWriter();
        
    }
}



