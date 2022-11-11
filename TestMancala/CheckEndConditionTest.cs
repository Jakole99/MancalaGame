
public class CheckEndConditionTest
{
    [Theory]
    [InlineData(8, 4, false)]
    [InlineData(4, 3, false)]
    [InlineData(6, 1, false)]
    [InlineData(14, 4, false)]

    public void CheckEndConditionTest1(int pits, int stones, bool expectedAnswer)
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

