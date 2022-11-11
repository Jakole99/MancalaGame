using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MancalaTemplateTest
{
    [Theory]
    [InlineData(new int[] {0, 0, 0, 1, 0, 0, 0, 0}, 3, Player.Numb.P1, Player.Numb.P1)]
    [InlineData(new int[] { 0, 0, 1, 1, 0, 0, 0, 0 }, 2, Player.Numb.P1, Player.Numb.P2)]
    [InlineData(new int[] { 0, 2, 0, 1, 0, 0, 0, 0 }, 1, Player.Numb.P1, Player.Numb.P1)]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 0, 1 }, 7, Player.Numb.P2, Player.Numb.P2)]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 1, 1 }, 6, Player.Numb.P2, Player.Numb.P1)]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 2, 0, 1 }, 5, Player.Numb.P2, Player.Numb.P2)]
    [InlineData(new int[] { 0, 0, 0, 0, 0, 2, 0, 1 }, 5, Player.Numb.P1, Player.Numb.P2)]
    [InlineData(new int[] { 2, 0, 1, 0, 1, 0, 1, 0 }, 0, Player.Numb.P1, Player.Numb.P1)]
    public void MoveResultTest1(int[] pits, int indexFinalPit, Player.Numb playersTurn, Player.Numb ExpectedplayerNumb)
    {
        //Arrange
        Board board = new Board(8, 6, true);
        board.ChangeBoard(pits);
        GameTemplate GameTemplate = new MancalaTemplate();
        GameSettings gameSettings = new GameSettings(Game.Variant.Mancala, "bob", "pop", false);

        //Act
        Player result = GameTemplate.MoveResult(board, gameSettings.GetPlayer(playersTurn), board.Pits[indexFinalPit], 0, gameSettings);

        //Assert
        Assert.Equal(gameSettings.GetPlayer(ExpectedplayerNumb), result);
    }
}
