
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

    public void MoveStonesTest1(int pits, int stones, bool hasHomePit, int moveFrom, Player.Numb playerNumb, int[] expectedAnswer)
    {
        
        //arrange
        Board board = new Board(pits, stones, hasHomePit);
        int[] intBoard;

        //act
        board.MoveStones(moveFrom, playerNumb);
        intBoard = Array.ConvertAll(board.Pits, Pit => Pit.GetStoneAmount());

        //assert
        Assert.Equal(expectedAnswer, intBoard);
    }
}





