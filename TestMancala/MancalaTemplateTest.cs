using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MancalaTemplateTest
{
    [Theory]
    [InlineData(new int[] { 0, 0, 0, 1, 0, 0, 0, 0 }, 3, Player.Numb.P1, Player.Numb.P1, new int[] { 0, 0, 0, 1, 0, 0, 0, 0 })]
    [InlineData(new int[] { 0, 0, 1, 1, 0, 0, 0, 0 }, 2, Player.Numb.P1, Player.Numb.P2, new int[] { 0, 0, 1, 1, 0, 0, 0, 0 })]
    [InlineData(new int[] { 0, 2, 0, 1, 0, 0, 0, 0 }, 1, Player.Numb.P1, Player.Numb.P1, new int[] { 0, 0, 1, 2, 0, 0, 0, 0 })]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 0, 1 }, 7, Player.Numb.P2, Player.Numb.P2, new int[] { 0, 0, 0, 0, 0, 0, 0, 1 })]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 1, 1 }, 6, Player.Numb.P2, Player.Numb.P1, new int[] { 0, 0, 0, 0, 0, 0, 1, 1 })]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 2, 0, 1 }, 5, Player.Numb.P2, Player.Numb.P2, new int[] { 0, 0, 0, 0, 0, 0, 1, 2 })]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 2, 0, 1 }, 5, Player.Numb.P1, Player.Numb.P2, new int[] { 0, 0, 0, 2, 0, 0, 0, 1 })]
    [InlineData(new int[] { 2, 0, 1, 0, 1, 0, 1, 0 }, 0, Player.Numb.P1, Player.Numb.P1, new int[] { 1, 0, 1, 2, 0, 1, 0, 0 })]
    public void MoveResultMancalaTest(int[] pits, int indexFinalPit, Player.Numb playersTurn, Player.Numb ExpectedplayerNumb, int[] transformed)
    {
        //Arrange
        Board board = new BoardFactory().GetCustomBoard(8, 6, Game.Variant.Mancala);
        board.ChangeBoard(pits);
        GameTemplate GameTemplate = new MancalaTemplate();
        GameSettings gameSettings = new GameSettings(Game.Variant.Mancala, "bob", "pop", false);

        //Act
        Player result = GameTemplate.MoveResult(board, gameSettings.GetPlayer(playersTurn), board.Pits[indexFinalPit], 0, gameSettings);

        //Assert
        //Assertion that determinse for the right return player
        Assert.Equal(gameSettings.GetPlayer(ExpectedplayerNumb), result);
        int[] intBoard = Array.ConvertAll(board.Pits, Pit => Pit.GetStoneAmount());

        //Assertion for the right board transformation
        Assert.Equal(intBoard, transformed);
    }


}

public class WariTemplateTest
{
    [Theory]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 5, 0 }, 6, Player.Numb.P1, Player.Numb.P2, new int[] { 0, 0, 0, 0, 0, 0, 5, 0 })]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 1, 0 }, 6, Player.Numb.P1, Player.Numb.P2, new int[] { 0, 0, 0, 0, 0, 0, 1, 0 })]
    [InlineData(new int[] { 0, 0, 2, 1, 0, 0, 0, 0 }, 2, Player.Numb.P1, Player.Numb.P2, new int[] { 0, 0, 2, 1, 0, 0, 0, 0 })]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 3, 0 }, 6, Player.Numb.P1, Player.Numb.P2, new int[] { 0, 0, 0, 0, 0, 0, 0, 0 })]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 3, 0 }, 6, Player.Numb.P2, Player.Numb.P1, new int[] { 0, 0, 0, 0, 0, 0, 3, 0 })]
    [InlineData(new int[] { 0, 2, 0, 0, 0, 0, 3, 0 }, 1, Player.Numb.P2, Player.Numb.P1, new int[] { 0, 0, 0, 0, 0, 0, 3, 0 })]
    public void WariMoveResultWariTest(int[] pits, int indexFinalPit, Player.Numb playersTurn, Player.Numb ExpectedplayerNumb, int[] transformed)
    {
        //Arrange
        Board board = new BoardFactory().GetCustomBoard(8, 6, Game.Variant.Wari);
        board.ChangeBoard(pits);
        GameTemplate GameTemplate = new WariTemplate();
        GameSettings gameSettings = new GameSettings(Game.Variant.WarCali, "Walter", "Maluigi", false);

        // Act
        Player result = GameTemplate.MoveResult(board, gameSettings.GetPlayer(playersTurn), board.Pits[indexFinalPit], 0, gameSettings);

        //Assert
        //Assertion that determinse for the right return player
        Assert.Equal(gameSettings.GetPlayer(ExpectedplayerNumb), result);
        int[] intBoard = Array.ConvertAll(board.Pits, Pit => Pit.GetStoneAmount());

        //Assertion for the right board transformation
        Assert.Equal(intBoard, transformed);
    }
}

public class WarCaliTemplateTest
{
    [Theory]
    [InlineData(new int[] { 1, 0, 2, 4, 2, 1, 2, 1 }, 2, Player.Numb.P1, Player.Numb.P1, new int[] { 1, 0, 2, 4, 2, 1, 2, 1 }, 2)]
    [InlineData(new int[] { 1, 0, 1, 4, 2, 1, 2, 1 }, 2, Player.Numb.P1, Player.Numb.P1, new int[] { 1, 0, 0, 7, 0, 1, 2, 1 }, 2)]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 2, 0 }, 6, Player.Numb.P1, Player.Numb.P2, new int[] { 0, 0, 0, 2, 0, 0, 0, 0 }, 2)]
    [InlineData(new int[] { 0, 2, 0, 0, 0, 0, 0, 0 }, 1, Player.Numb.P1, Player.Numb.P2, new int[] { 0, 2, 0, 0, 0, 0, 0, 0 }, 2)]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 2, 0 }, 6, Player.Numb.P2, Player.Numb.P1, new int[] { 0, 0, 0, 0, 0, 0, 2, 0 }, 0)]
    [InlineData(new int[] { 0, 2, 0, 0, 0, 0, 0, 0 }, 1, Player.Numb.P2, Player.Numb.P1, new int[] { 0, 0, 0, 0, 0, 0, 0, 2 }, 0)]
    public void MoveResultTestWariCaliTest(int[] pits, int indexFinalPit, Player.Numb playersTurn, Player.Numb ExpectedplayerNumb, int[] transformed, int chosenPitNumber)
    {
        //Arrange
        Board board = new BoardFactory().GetCustomBoard(8, 6, Game.Variant.WarCali);
        board.ChangeBoard(pits);
        GameTemplate GameTemplate = new WarCaliTemplate();
        GameSettings gameSettings = new GameSettings(Game.Variant.WarCali, "Wari", "Cali", false);

        //Act
        Player result = GameTemplate.MoveResult(board, gameSettings.GetPlayer(playersTurn), board.Pits[indexFinalPit], chosenPitNumber, gameSettings);

        //Assert
        //Assertion that determinse for the right return player
        Assert.Equal(gameSettings.GetPlayer(ExpectedplayerNumb), result);
        int[] intBoard = Array.ConvertAll(board.Pits, Pit => Pit.GetStoneAmount());

        //Assertion for the right board transformation
        Assert.Equal(intBoard, transformed);
    }
}
