
public class CheckEndConditionTest
{
    [Theory]
    [InlineData(8, 2, true, false)]
    [InlineData(4, 0, false, true)]
    [InlineData(6, 4, true, false)]
    [InlineData(14, 0, false, true)]

    public void CheckEndConditionTest1(int pits, int stones, bool hasHomePit, bool expectedAnswer)
    {
        //arrange
        Player player = new Player("Jan", Player.Numb.P1);
        Player player2 = new Player("Peter", Player.Numb.P1);
        
        GameTemplate gameTemplate = new MancalaTemplate(); 
        Board board = new Board(pits, stones, hasHomePit);


        //act
        bool answer = gameTemplate.CheckEndCondition(board, player);

        //assert
        Assert.Equal(answer, expectedAnswer);
    }

}

