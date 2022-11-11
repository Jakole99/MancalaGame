
public class CheckEndConditionTest
{
    [Theory]
    [InlineData(8, 2, true, false)]
    [InlineData(4, 0, false, true)]
    [InlineData(6, 4, true, false)]
    [InlineData(14, 0, false, true)]

    public void CheckEndConditionTest1(int pits, int stones, bool expectedAnswer)
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

    [Theory]
    [InlineData(4, 16, true)]
    [InlineData(4, 2, true)]
    [InlineData(4, 7, true)]
    [InlineData(4, 8, true)]

    public void CheckEndConditionTest2(int pits, int stones, bool expectedAnswer)
    {
        //arrange
        Player player = new Player("Peter", Player.Numb.P1);
        GameTemplate gameTemplate = new WariTemplate();
        Board board = new Board(pits, stones, true);

        
        //act
        //board.Pits[0].EmptyPit();
        //board.Pits[1].EmptyPit();
        //board.Pits[2].EmptyPit();
        //board.Pits[3].EmptyPit();
        bool answer = gameTemplate.CheckEndCondition(board, player);

        //assert
        Assert.Equal(answer, expectedAnswer);
    }

}

