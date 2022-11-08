
public class ChoosePitTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
 

    public void ChoosePitTest1(int i)
    {
        //arrange
        Game game = new Game();
        Player player = new Player("Jan", Player.Numb.P1);
        GameTemplate gameTemplate = new MancalaTemplate();

        Board board = new Board(8, 4, true);
        int[] testboard = new int[] { 4, 4, 4, 0, 5, 5, 0, 0 };

        //act
        int x = gameTemplate.ChoosePit(board, player);

        //assert
        Assert.Equal(x,i);
    }
}

