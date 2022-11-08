
public class CheckEndConditionTest
{
    [Theory]
    [InlineData(8, 0, true, true)]
    [InlineData(4, 0, true, true)]
    [InlineData(6, 0, true, true)]
    [InlineData(14, 0, true, true)]

    public void CheckEndConditionTest1(int pits, int stones, bool hasHomePit, bool expectedAnswer)
    {
        //arrange
        Player player = new Player("Jan", Player.Numb.P1);
        Player player2 = new Player("Peter", Player.Numb.P1);
        
        GameTemplate gameTemplate = new MancalaTemplate(); 
        Board board = new Board(pits, 0, hasHomePit);


        //act
        bool answer = gameTemplate.CheckEndCondition(board, player);

        //assert
        Assert.Equal(answer, expectedAnswer);
    }

}

