
public class CheckEndConditionTest
{
    [Theory]
    [InlineData(8, 4, true, false)]
    [InlineData(4, 0, true, true)]
    [InlineData(6, 1, false, false)]
    [InlineData(14, 0, false, true)]

    public void CheckEndConditionTest1(int pits, int stones, bool hasHomePit, bool expectedAnswer)
    {
        //arrange
        Player player = new Player("Jan", Player.Numb.P1);
        GameTemplate gameTemplate = new MancalaTemplate(); 
        Board board = new Board(pits, stones, true);


        //act
        bool answer = gameTemplate.CheckEndCondition(board, player);

        //assert
        Assert.Equal(answer, expectedAnswer);
    }

}

